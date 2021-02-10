using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IsuCorpTest.Migrations
{
    public partial class spGetContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetContact]
                    @ContactId BIGINT = NULL
                AS
                BEGIN
                    SET NOCOUNT ON;
                    SELECT A.ContactId, A.ContactName, A.PhoneNumber, 
	                    A.BirthDate, B.ContactTypeId, B.ContactTypeName
                    FROM IsuCorpTestDB.[dbo].[Contact] A
	                    INNER JOIN IsuCorpTestDB.[dbo].[ContactType] B ON A.ContactTypeId = B.ContactTypeId
                    WHERE (A.ContactId = @ContactId OR @ContactId IS NULL)
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
