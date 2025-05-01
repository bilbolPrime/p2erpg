const { deployProxy } = require('@openzeppelin/truffle-upgrades');
var Characters = artifacts.require('Characters');
module.exports = async function (deployer) {
    await deployProxy(Characters, [], { deployer });
}