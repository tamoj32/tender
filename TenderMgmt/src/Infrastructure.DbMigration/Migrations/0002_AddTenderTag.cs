using SimpleMigrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DbMigration.Migrations
{
    [Migration(2)]
    public partial class _0002_AddTenderTag : Migration
    {
        protected override void Up()
        {
            Execute(@"
                    CREATE TABLE [dbo].[TenderTags](
	                    [Id] [int] IDENTITY(1,1) NOT NULL,
	                    [Name] [nvarchar](255) NOT NULL,
	                    [TenderId] [int] NOT NULL,
                     CONSTRAINT [PK_TenderTags] PRIMARY KEY CLUSTERED 
                    (
	                    [Id] ASC
                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                    ) ON [PRIMARY]

                    ALTER TABLE [dbo].[TenderTags]  WITH CHECK ADD  CONSTRAINT [FK_TenderTags_Tenders] FOREIGN KEY([TenderId])
                    REFERENCES [dbo].[Tenders] ([Id])

                    ALTER TABLE [dbo].[TenderTags] CHECK CONSTRAINT [FK_TenderTags_Tenders]
                ");
        }

        protected override void Down()
        {
            Execute("DROP TABLE TenderTags");
        }
    }
}
