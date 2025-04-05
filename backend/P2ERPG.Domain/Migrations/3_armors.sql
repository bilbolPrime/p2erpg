CREATE TABLE [P2ERPG].[Armors]
(
	[ArmorId] [int] IDENTITY(1,1) NOT NULL,
	[MintId] [BigInt] not null,
	[Wallet] [nvarchar](100) NOT NULL,
	[ArmorType] int not null,
	[Roll] int not null
 CONSTRAINT [P2ERPG_PrimayKey_Armors_ArmorId] PRIMARY KEY CLUSTERED 
(
	[ArmorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] 
GO

CREATE  PROCEDURE [P2ERPG].[armors_get]
@ArmorId int,
@MintId bigint,
@Wallet nvarchar(100)
as
begin
	if @Wallet is not null and len(@Wallet) > 0
	begin
		select * from [P2ERPG].[Armors] where Wallet = @Wallet
		return;
	end
	select * from [P2ERPG].[Armors] with(Nolock) where ArmorId = @ArmorId or MintId = @mintId
end

GO
CREATE TYPE [P2ERPG].[ArmorTVP] AS TABLE(
	[ArmorId] int not null,
	[MintId] [BigInt] not null,
	[Wallet] [nvarchar](100) NOT NULL,
	[ArmorType] int not null,
	[Roll] int not null
)
GO

CREATE PROCEDURE [P2ERPG].[armors_update]
@Armors as [P2ERPG].[ArmorTVP]  readonly
as
begin
	select * into #tmp_armors from @Armors

	MERGE INTO [P2ERPG].[Armors] AS tgt
USING (
    select * from #tmp_armors
    ) AS src
    ON tgt.[ArmorId] = src.[ArmorId] or tgt.MintId = src.MintId
WHEN MATCHED
    THEN
        UPDATE
        set Wallet = src.Wallet,
			ArmorType = src.ArmorType,
			Roll = src.Roll
WHEN NOT MATCHED BY TARGET
    THEN
        INSERT (MintId, Wallet, ArmorType, Roll )
        VALUES (MintId, Wallet, ArmorType, Roll );	
end
GO