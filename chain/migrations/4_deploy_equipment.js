const { deployProxy } = require('@openzeppelin/truffle-upgrades');
var Shields = artifacts.require('Shields');
var Armors = artifacts.require('Armors');
var Weapons = artifacts.require('Weapons');

module.exports = async function (deployer) {
    await deployProxy(Shields, [], { deployer });
    await deployProxy(Armors, [], { deployer });
    await deployProxy(Weapons, [], { deployer });
}