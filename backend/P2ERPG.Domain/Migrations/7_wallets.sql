CREATE TABLE [P2ERPG].[Wallets](
	[WalletId] [int] IDENTITY(1,1) NOT NULL,
	[Wallet] [nvarchar](100) NOT NULL CONSTRAINT [P2ERPG_Wallets_Wallet_unique] unique,
	[ActiveNonce] [nvarchar](20) NULL,
	[LastSignIn] [datetime] NULL,
	[LastSignedNonce] [nvarchar](20) NULL
 CONSTRAINT [P2ERPG_Wallets_WalletId] PRIMARY KEY CLUSTERED 
(
	[WalletId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE PROCEDURE [P2ERPG].[wallets_get] 
@WalletId int,
@Wallet nvarchar(100)
as 
begin
	if @WalletId <> -1
	begin
		select * from [P2ERPG].Wallets with(nolock) where WalletId = @WalletId
		return
	end

	select * from [P2ERPG].Wallets with(nolock) where Wallet = @Wallet
end
GO

CREATE PROCEDURE [P2ERPG].[wallets_create]
@Wallet nvarchar(100)
as
begin
	declare @nonce as bigint = rand() * POWER(10, 5) * POWER(10, 5) * POWER(10, 5)
	insert into [P2ERPG].Wallets(Wallet,  ActiveNonce) select @Wallet, Cast(@nonce as nvarchar(40))
end
GO

CREATE PROCEDURE [P2ERPG].[wallets_sign]
@WalletId int,
@SignedNonce nvarchar(40)
as
begin
	declare @nonce as bigint = rand() * POWER(10, 5) * POWER(10, 5) * POWER(10, 5)
	update [P2ERPG].Wallets set ActiveNonce = CAST(@nonce as nvarchar(20)), LastSignedNonce = @SignedNonce, LastSignIn =  GETUTCDATE() where WalletId = @WalletId
end

GO
