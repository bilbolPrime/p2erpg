CREATE TYPE [P2ERPG].[NFTOwnershipTVP] AS TABLE(
	[MintId] [BigInt] not null,
	[Wallet] [nvarchar](100) NOT NULL
)
GO

CREATE PROCEDURE [P2ERPG].[characters_updateOwnserhip]
@NFTOwnerships as [P2ERPG].[NFTOwnershipTVP]  readonly
as
begin
	select * into #tmp_ownerships from @NFTOwnerships

	MERGE INTO [P2ERPG].[Characters] AS tgt
USING (
    select * from #tmp_ownerships
    ) AS src
    ON tgt.MintId = src.MintId
WHEN MATCHED
    THEN
        UPDATE
        set Wallet = src.Wallet;
GO

CREATE PROCEDURE [P2ERPG].[armors_updateOwnserhip]
@NFTOwnerships as [P2ERPG].[NFTOwnershipTVP]  readonly
as
begin
	select * into #tmp_ownerships from @NFTOwnerships

	MERGE INTO [P2ERPG].[Armors] AS tgt
USING (
    select * from #tmp_ownerships
    ) AS src
    ON tgt.MintId = src.MintId
WHEN MATCHED
    THEN
        UPDATE
        set Wallet = src.Wallet;
end
GO


CREATE PROCEDURE [P2ERPG].[shields_updateOwnserhip]
@NFTOwnerships as [P2ERPG].[NFTOwnershipTVP]  readonly
as
begin
	select * into #tmp_ownerships from @NFTOwnerships

	MERGE INTO [P2ERPG].[Shields] AS tgt
USING (
    select * from #tmp_ownerships
    ) AS src
    ON tgt.MintId = src.MintId
WHEN MATCHED
    THEN
        UPDATE
        set Wallet = src.Wallet;
end
GO
CREATE PROCEDURE [P2ERPG].[weapons_updateOwnserhip]
@NFTOwnerships as [P2ERPG].[NFTOwnershipTVP]  readonly
as
begin
	select * into #tmp_ownerships from @NFTOwnerships

	MERGE INTO [P2ERPG].[Weapons] AS tgt
USING (
    select * from #tmp_ownerships
    ) AS src
    ON tgt.MintId = src.MintId
WHEN MATCHED
    THEN
        UPDATE
        set Wallet = src.Wallet;
end
GO


