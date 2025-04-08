using AutoMapper;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Wallets;
using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Crypto.Validator;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Security
{
    public class SecurityManager : ISecurityManager
    {
        private const long TOKEN_SPAN = 60 * 60 * 24;
        private const string CLAIM_WALLET = "wallet";
        private const string CLAIM_NONCE = "nonce";

        private readonly string _jwtSecret;
        private readonly string _challengeMessage;

        private IWalletsManager _walletManager;
        private IChainValidator _chainValidator;
        private readonly IMapper _mapper;

        public SecurityManager(IMapper mapper, IOptions<CryptoJWTOptions> jwtSecret, IWalletsManager walletManager, IChainValidator chainValidator)
        {
            _walletManager = walletManager;
            _chainValidator = chainValidator;
            _jwtSecret = jwtSecret.Value.Secret;
            _challengeMessage = jwtSecret.Value.ChallengeMessage;
            _mapper = mapper;
        }

        public async Task<string> GetChallenge(string wallet)
        {
            if (!_chainValidator.ValidateWallet(wallet))
            {
                throw new ArgumentException($"{wallet} is not a valid wallet");
            }

            var userWallet = await _walletManager.GetAsync(-1, wallet);

            if (userWallet == null)
            {
                await _walletManager.CreateAsync(wallet);
                userWallet = await _walletManager.GetAsync(-1, wallet);
            }


            return string.Format(_challengeMessage, userWallet, userWallet.activeNonce);
        }


        public async Task<string> SignIn(string wallet, string signature)
        {
            if (!_chainValidator.ValidateWallet(wallet))
            {
                throw new ArgumentException($"{wallet} is not a valid wallet");
            }

            var userWallet = await _walletManager.GetAsync(-1, wallet);

            if (userWallet == null)
            {
                throw new ArgumentException("Wallet not found");
            }

            if (!_chainValidator.ValidateSignature(wallet, string.Format(_challengeMessage, wallet, userWallet.activeNonce), signature))
            {
                throw new UnauthorizedAccessException($"Signature is not valid!");
            }

            await _walletManager.SignAsync(new Records.Wallets.Wallet(wallet, userWallet.activeNonce, userWallet.lastSignedNonce));

            var expiresOn = DateTime.UtcNow.AddSeconds(TOKEN_SPAN);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(CLAIM_WALLET, wallet), new Claim(CLAIM_NONCE, userWallet.activeNonce) }),
                Expires = expiresOn,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task AssertAccess(string wallet, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSecret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.FromMinutes(1)
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                if (jwtToken.Claims.First(x => x.Type == CLAIM_WALLET).Value != wallet)
                {
                    throw new UnauthorizedAccessException($"Signature is not valid!");
                }

                var userWallet = await _walletManager.GetAsync(-1, wallet);
                if (jwtToken.Claims.First(x => x.Type == CLAIM_NONCE).Value != userWallet.lastSignedNonce)
                {
                    throw new UnauthorizedAccessException($"Signature is not valid!");
                }
            }
            catch (SecurityTokenException ex)
            {
                throw new UnauthorizedAccessException($"Access denied!");
            }
        }
    }
}
