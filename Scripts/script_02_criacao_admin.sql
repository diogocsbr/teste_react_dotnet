USE [teste_leilao]
GO

INSERT INTO [dbo].[usuario]
           ([nome]
           ,[usuario]
           ,[senha]
           ,[idade]
           ,[administrador])
     VALUES
           ('admin',
			'admin',
            'admin',
            '50',
           1)
GO
