
using AutoMapper;
using BilbolStack.Boonamai.P2ERPG.Business.Records.Characters;
using Entities = BilbolStack.Boonamai.P2ERPG.Domain.Entities;
using BilbolStack.Boonamai.P2ERPG.Business.Records.Equipment;
using BilbolStack.Boonamai.P2ERPG.Business.Records.Wallets;
using BilbolStack.Boonamai.P2ERPG.Business.Records;


namespace BilbolStack.Boonamai.P2ERPG.Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Characters.Character, Character>();
            CreateMap<Entities.Characters.CharacterAssignedEquipment, CharacterAssignedEquipment>();
            CreateMap<Entities.Equipment.Armor, Armor>();
            CreateMap<Entities.Equipment.Shield, Shield>();
            CreateMap<Entities.Equipment.Weapon, Weapon>();

            CreateMap<Character, Entities.Characters.Character>();
            CreateMap<CharacterAssignedEquipment, Entities.Characters.CharacterAssignedEquipment>();
            CreateMap<Armor, Entities.Equipment.Armor>();
            CreateMap<Shield, Entities.Equipment.Shield>();
            CreateMap<Weapon, Entities.Equipment.Weapon>();

            CreateMap<NFTOwnership, Entities.NFTOwnership>();

            CreateMap<Entities.Wallets.WalletAccount, Wallet>();
            CreateMap<Wallet, Entities.Wallets.WalletAccount>();
        }
    }
}
