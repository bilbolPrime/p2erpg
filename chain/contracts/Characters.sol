// SPDX-License-Identifier: GPL-3.0
pragma solidity ^0.8.0;

import "@openzeppelin/contracts-upgradeable/proxy/utils/Initializable.sol";
import "@openzeppelin/contracts-upgradeable/token/ERC721/extensions/ERC721EnumerableUpgradeable.sol";
import "@openzeppelin/contracts-upgradeable/access/AccessControlUpgradeable.sol";
import "@openzeppelin/contracts/utils/math/SafeMath.sol";

contract Characters is Initializable, ERC721EnumerableUpgradeable, AccessControlUpgradeable {

    using SafeMath for uint256;
    using SafeMath for uint8;

    bytes32 public constant GAME_ADMIN = keccak256("GAME_ADMIN");

    uint8 public constant CHARACTER_TYPE = 0;
    uint8 public constant HP = 1;
    uint8 public constant STRENGTH = 2;
    uint8 public constant SPEED = 3;
    uint8 public constant AGILITY = 4;
    uint8 public constant CONCENTRATION = 5;
    uint8 public constant ENDURANCE = 6;
    uint8 public constant SKILL_POINTS = 7;
    uint8 public constant POTENTIAL = 8;
    uint8 public constant LEVEL = 9; 
    uint8 public constant EXPERIENCE = 10;

    function initialize () public initializer {
        __ERC721_init("P2E RPG character", "P2ERPGC");
        __AccessControl_init_unchained();

        _setupRole(DEFAULT_ADMIN_ROLE, msg.sender);
        _setupRole(GAME_ADMIN, msg.sender);
    }

    mapping(uint256 => mapping(uint256 => uint256)) public nftVars;

    modifier restricted() {
        _restricted();
        _;
    }

    function _restricted() internal view {
        require(hasRole(GAME_ADMIN, msg.sender), "NGA");
    }

    function get(uint256 id) public view returns (uint256) {
        return nftVars[id][CHARACTER_TYPE] | 
                nftVars[id][HP] << 8 | 
                nftVars[id][STRENGTH] << 24 |
                nftVars[id][SPEED] << 32 |
                nftVars[id][AGILITY] << 40 |
                nftVars[id][CONCENTRATION] << 48 |
                nftVars[id][ENDURANCE] << 56 |
                nftVars[id][SKILL_POINTS] << 64 |
                nftVars[id][POTENTIAL] << 72 |
                nftVars[id][LEVEL] << 80 |
                nftVars[id][EXPERIENCE] << 88;
    }

    function mint(address owner, uint256 characterType, uint256 potential) public restricted returns (uint256 id) {
        id = totalSupply() + 1;
        nftVars[id][CHARACTER_TYPE] = characterType;
        nftVars[id][HP] = 5;
        nftVars[id][STRENGTH] = 1;
        nftVars[id][SPEED] = 1;
        nftVars[id][AGILITY] = 1;
        nftVars[id][CONCENTRATION] = 1;
        nftVars[id][ENDURANCE] = 10;
        nftVars[id][POTENTIAL] = potential;
        nftVars[id][LEVEL] = 1;
         _safeMint(owner, id);
    }


    function getCharactersOwnedBy(address wallet) public view returns(uint256[] memory chars) {
        uint256 count = balanceOf(wallet);
        chars = new uint256[](count);
        for(uint256 i = 0; i < count; i++)
            chars[i] = tokenOfOwnerByIndex(wallet, i);
    }

    function setNFTVars(uint256 id, uint256[] memory fields, uint256[] memory values) public restricted {
        for(uint i = 0; i < fields.length; i++)
            nftVars[id][fields[i]] = values[i];
    }

    function supportsInterface(bytes4 interfaceId)
        public
        view
        override(ERC721EnumerableUpgradeable, AccessControlUpgradeable)
        returns (bool)
    {
        return super.supportsInterface(interfaceId);
    }
}
