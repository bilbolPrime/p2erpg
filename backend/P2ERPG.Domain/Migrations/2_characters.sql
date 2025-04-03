CREATE TABLE [P2ERPG].[Characters]
(
	[CharacterId] [int] IDENTITY(1,1) NOT NULL,
	[MintId] [BigInt] not null,
	[Wallet] [nvarchar](100) NOT NULL,
	[CharacterType] int not null,
	[HP] int not null,
	[Strength] int not null,
	[Speed] int not null,
	[Agility] int not null,
	[Concentration] int not null,
	[Endurance] int not null,
	[SkillPoints] int not null,
	[Potential] int not null,
	[Experience] int not null,
	[Level] int not null
 CONSTRAINT [P2ERPG_PrimayKey_Characters_CharacterId] PRIMARY KEY CLUSTERED 
(
	[CharacterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] 
GO

CREATE  PROCEDURE [P2ERPG].[characters_get]
@CharacterId int,
@MintId bigint,
@Wallet nvarchar(100)
as
begin
	if @Wallet is not null and len(@Wallet) > 0
	begin
		select * from [P2ERPG].[Characters] where Wallet = @Wallet
		return;
	end
	select * from [P2ERPG].[Characters] with(Nolock) where CharacterId = @CharacterId or MintId = @mintId
end

GO
CREATE TYPE [P2ERPG].[CharacterTVP] AS TABLE(
	[CharacterId] int not null,
	[MintId] [BigInt] not null,
	[Wallet] [nvarchar](100) NOT NULL,
	[CharacterType] int not null,
	[HP] int not null,
	[Strength] int not null,
	[Speed] int not null,
	[Agility] int not null,
	[Concentration] int not null,
	[Endurance] int not null,
	[SkillPoints] int not null,
	[Potential] int not null,
	[Experience] int not null,
	[Level] int not null
)
GO

CREATE PROCEDURE [P2ERPG].[characters_update]
@Characters as [P2ERPG].[CharacterTVP]  readonly
as
begin
	select * into #tmp_characters from @Characters

	MERGE INTO [P2ERPG].[Characters] AS tgt
USING (
    select * from #tmp_characters
    ) AS src
    ON tgt.[CharacterId] = src.[CharacterId] or tgt.MintId = src.MintId
WHEN MATCHED
    THEN
        UPDATE
        set Wallet = src.Wallet,
			[CharacterType] = src.[CharacterType],
			HP = src.HP,
			Strength = src.Strength,
			Speed = src.Speed,
			Agility = src.Agility,
			Concentration = src.Concentration,
			Endurance = src.Endurance,
			SkillPoints = src.SkillPoints,
			Potential = src.Potential,
			Experience = src.Experience,
			[Level] = src.[Level]
WHEN NOT MATCHED BY TARGET
    THEN
        INSERT (MintId, Wallet, CharacterType, HP , Strength , Speed , Agility , Concentration, Endurance , SkillPoints, Potential , Experience , [Level] )
        VALUES (MintId, Wallet,  CharacterType, HP , Strength , Speed , Agility , Concentration, Endurance , SkillPoints, Potential , Experience , [Level] );
	
end
GO

