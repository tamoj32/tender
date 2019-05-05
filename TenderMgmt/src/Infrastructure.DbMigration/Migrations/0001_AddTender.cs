using SimpleMigrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DbMigration.Migrations
{
    [Migration(1)]
    public partial class _0001_AddTender : Migration
    {
        protected override void Up()
        {
            Execute(@"
                    CREATE TABLE [dbo].[Tenders](
	                    [Id] [int] IDENTITY(1,1) NOT NULL,
                        [ReferenceNumber] [nvarchar](255) NOT NULL,
	                    [Name] [nvarchar](255) NOT NULL,
	                    [ReleaseDate] [DateTime] NOT NULL,
	                    [ClosingDate] [DateTime] NOT NULL,
	                    [Description] [nvarchar](255) NULL,
	                    [UserId] [int] NOT NULL,
                     CONSTRAINT [PK_Tenders] PRIMARY KEY CLUSTERED 
                    (
	                    [Id] ASC
                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                    ) ON [PRIMARY]
                ");
        }

        protected override void Down()
        {
            Execute("DROP TABLE Tenders");
        }
    }
}
