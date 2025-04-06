CREATE TABLE [P2ERPG].[CharacterEquipment]
(
	[CharacterEquipmentId] [int] IDENTITY(1,1) NOT NULL,
	[CharacterId] [Int] not null CONSTRAINT [P2ERPG_ForeignKey_CharacterEquipment_Characters_CharacterId] 
	unique foreign key references [P2ERPG].[Characters](CharacterId),
	[WeaponId] [Int] NULL CONSTRAINT [P2ERPG_ForeignKey_CharacterEquipment_Weapons_WeaponId] 
	unique foreign key references [P2ERPG].[Weapons](WeaponId),
	[ArmorId] [int] CONSTRAINT [P2ERPG_ForeignKey_CharacterEquipment_Armors_ArmorId] 
	unique foreign key references [P2ERPG].[Armors](ArmorId),
	[ShieldId] [int] CONSTRAINT [P2ERPG_ForeignKey_CharacterEquipment_Shields_ShieldId] 
	unique foreign key references [P2ERPG].[Shields](ShieldId),
 CONSTRAINT [P2ERPG_PrimayKey_CharacterEquipment_CharacterEquipmentId] PRIMARY KEY CLUSTERED 
(
	[CharacterEquipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE  PROCEDURE [P2ERPG].[equipment_get]
@CharacterId int
as
begin
	select * from [P2ERPG].[CharacterEquipment] with(Nolock) where CharacterId = @CharacterId
end

GO

CREATE PROCEDURE [P2ERPG].[equipment_update]
@CharacterId int,
@WeaponId int,
@ArmorId int,
@ShieldId int
as
begin
	if not exists (select 1 from CharacterEquipment where CharacterId = @CharacterId)
	begin
		insert into CharacterEquipment(CharacterId) select @CharacterId
	end

	if @WeaponId <> -1
	begin
		update CharacterEquipment set WeaponId = @WeaponId where CharacterId = @CharacterId
	end

	if @ArmorId <> -1
	begin
		update CharacterEquipment set ArmorId = @ArmorId where CharacterId = @CharacterId
	end

	if @ShieldId <> -1
	begin
		update CharacterEquipment set ShieldId = @ShieldId where CharacterId = @CharacterId
	end
end
GO

