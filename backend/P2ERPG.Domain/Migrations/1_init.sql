CREATE SCHEMA P2ERPG
GO
CREATE TABLE [P2ERPG].[AppConfigurations](
	[AppConfigurationId] [int] IDENTITY(1,1) NOT NULL,
	[FieldName] [nvarchar](255) NOT NULL,
	[FieldValue] [nvarchar](max) NOT NULL,
 CONSTRAINT [P2ERPG_PrimayKey_AppConfigurations_AppConfigurationId] PRIMARY KEY CLUSTERED 
(
	[AppConfigurationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
Create procedure [P2ERPG].[appconfigs_get]
@FieldName nvarchar(255)
as
begin
	select * from [P2ERPG].AppConfigurations with(Nolock) where FieldName = @FieldName
end
GO

Create procedure [P2ERPG].[appconfigs_update]
@FieldName nvarchar(255),
@FieldValue nvarchar(max)
as
begin
	if exists (select 1 from [P2ERPG].AppConfigurations with(nolock) where FieldName = @FieldName)
	begin
		update [P2ERPG].AppConfigurations set FieldValue = @FieldValue where FieldName = @FieldName
		return;
	end

	insert into [P2ERPG].AppConfigurations(FieldName, FieldValue) select @FieldName, @FieldValue
end
GO