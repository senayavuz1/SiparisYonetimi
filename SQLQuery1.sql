USE [Northwind]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[CalisanlarinYillarGoreDagilimi]

SELECT	@return_value as 'Return Value'

GO
