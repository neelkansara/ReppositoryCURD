using FluentMigrator;
using System;

namespace CURD.Migration.Migrations
{
    [Migration(20190201154100)]
    public class InitialScript : FluentMigrator.Migration
    {
        private readonly string script = @"GO
CREATE TABLE [dbo].[tbl_User](
	[userid] [bigint] IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[firstname] [varchar](50) NULL,
	[lastname] [varchar](50) NULL,
	[mobile] [varchar](10) NULL,
	[isactivated] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
";
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Execute.Sql(script);
            
        }
    }
}
