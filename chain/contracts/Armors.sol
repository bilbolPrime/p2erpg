// SPDX-License-Identifier: GPL-3.0
pragma solidity ^0.8.0;

import "@openzeppelin/contracts-upgradeable/proxy/utils/Initializable.sol";
import "@openzeppelin/contracts-upgradeable/token/ERC721/extensions/ERC721EnumerableUpgradeable.sol";
import "@openzeppelin/contracts-upgradeable/access/AccessControlUpgradeable.sol";
import "@openzeppelin/contracts/utils/math/SafeMath.sol";

contract Armors is Initializable, ERC721EnumerableUpgradeable, AccessControlUpgradeable  {

    using SafeMath for uint256;
    using SafeMath for uint8;

    bytes32 public constant GAME_ADMIN = keccak256("GAME_ADMIN");

    uint8 public constant ARMOR_TYPE = 0;
    uint8 public constant ROLL = 1;

    mapping(uint256 => mapping(uint256 => uint256)) public nftVars;


    function initialize () public initializer {
        __ERC721_init("P2E RPG Armor", "P2ERPGA");
        __AccessControl_init_unchained();

        _setupRole(DEFAULT_ADMIN_ROLE, msg.sender);
        _setupRole(GAME_ADMIN, msg.sender);
    }

    modifier restricted() {
        _restricted();
        _;
    }

    function _restricted() internal view {
        require(hasRole(GAME_ADMIN, msg.sender), "NGA");
    }

    function get(uint256 id) public view returns (uint256) {
        return nftVars[id][ARMOR_TYPE] | 
                nftVars[id][ROLL] << 8;
    }

    function mint(address owner, uint256 armorType, uint256 roll) public restricted returns (uint256 id) {
        id = totalSupply() + 1;
        nftVars[id][ARMOR_TYPE] = armorType;
        nftVars[id][ROLL] = roll;
         _safeMint(owner, id);
    }


    function getArmorsOwnedBy(address wallet) public view returns(uint256[] memory chars) {
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