CREATE TABLE [P2ERPG].[Weapons]
(
	[WeaponId] [int] IDENTITY(1,1) NOT NULL,
	[MintId] [BigInt] not null,
	[Wallet] [nvarchar](100) NOT NULL,
	[WeaponType] int not null,
	[Roll] int not null
 CONSTRAINT [P2ERPG_PrimayKey_Weapons_WeaponId] PRIMARY KEY CLUSTERED 
(
	[WeaponId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] 
GO

CREATE  PROCEDURE [P2ERPG].[weapons_get]
@WeaponId int,
@MintId bigint,
@Wallet nvarchar(100)
as
begin
	if @Wallet is not null and len(@Wallet) > 0
	begin
		select * from [P2ERPG].[Weapons] where Wallet = @Wallet
		return;
	end
	select * from [P2ERPG].[Weapons] with(Nolock) where WeaponId = @WeaponId or MintId = @mintId
end

GO
CREATE TYPE [P2ERPG].[WeaponTVP] AS TABLE(
	[WeaponId] int not null,
	[MintId] [BigInt] not null,
	[Wallet] [nvarchar](100) NOT NULL,
	[WeaponType] int not null,
	[Roll] int not null
)
GO

CREATE PROCEDURE [P2ERPG].[weapons_update]
@Weapons as [P2ERPG].[WeaponTVP]  readonly
as
begin
	select * into #tmp_weapons from @Weapons

	MERGE INTO [P2ERPG].[Weapons] AS tgt
USING (
    select * from #tmp_weapons
    ) AS src
    ON tgt.[WeaponId] = src.[WeaponId] or tgt.MintId = src.MintId
WHEN MATCHED
    THEN
        UPDATE
        set Wallet = src.Wallet,
			WeaponType = src.WeaponType,
			Roll = src.Roll
WHEN NOT MATCHED BY TARGET
    THEN
        INSERT (MintId, Wallet, WeaponType, Roll )
        VALUES (MintId, Wallet, WeaponType, Roll );	
end
GO

