CREATE TABLE [P2ERPG].[Shields]
(
	[ShieldId] [int] IDENTITY(1,1) NOT NULL,
	[MintId] [BigInt] not null,
	[Wallet] [nvarchar](100) NOT NULL,
	[ShieldType] int not null,
	[Roll] int not null
 CONSTRAINT [P2ERPG_PrimayKey_Shields_ShieldId] PRIMARY KEY CLUSTERED 
(
	[ShieldId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] 
GO

CREATE  PROCEDURE [P2ERPG].[shields_get]
@ShieldId int,
@MintId bigint,
@Wallet nvarchar(100)
as
begin
	if @Wallet is not null and len(@Wallet) > 0
	begin
		select * from [P2ERPG].[Shields] where Wallet = @Wallet
		return;
	end
	select * from [P2ERPG].[Shields] with(Nolock) where ShieldId = @ShieldId or MintId = @mintId
end

GO
CREATE TYPE [P2ERPG].[ShieldTVP] AS TABLE(
	[ShieldId] int not null,
	[MintId] [BigInt] not null,
	[Wallet] [nvarchar](100) NOT NULL,
	[ShieldType] int not null,
	[Roll] int not null
)
GO

CREATE PROCEDURE [P2ERPG].[shields_update]
@Shields as [P2ERPG].[ShieldTVP]  readonly
as
begin
	select * into #tmp_shields from @Shields

	MERGE INTO [P2ERPG].[Shields] AS tgt
USING (
    select * from #tmp_shields
    ) AS src
    ON tgt.[ShieldId] = src.[ShieldId] or tgt.MintId = src.MintId
WHEN MATCHED
    THEN
        UPDATE
        set Wallet = src.Wallet,
			ShieldType = src.ShieldType,
			Roll = src.Roll
WHEN NOT MATCHED BY TARGET
    THEN
        INSERT (MintId, Wallet, ShieldType, Roll )
        VALUES (MintId, Wallet, ShieldType, Roll );	
end
GO