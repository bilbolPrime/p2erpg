// SPDX-License-Identifier: MIT
pragma solidity ^0.8.0;


import "@openzeppelin/contracts/token/ERC20/ERC20.sol";

contract TestToken is ERC20 {
    constructor() public ERC20("Test Token", "TST") {
		_mint(msg.sender, 1_000_000_000e18);
	}

    function mint() public {
        _mint(msg.sender, 1_000e18);
    }
}