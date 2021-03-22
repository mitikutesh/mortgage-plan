
/****** Object:  Table [dbo].[Prospects]    Script Date: 22/03/2021 08.28.19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Prospects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](60) NOT NULL,
	[LoanAmount] [decimal](18, 2) NOT NULL,
	[AnnualInterest] [decimal](18, 2) NOT NULL,
	[LoanTerm] [int] NOT NULL,
 CONSTRAINT [PK_Prospects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

