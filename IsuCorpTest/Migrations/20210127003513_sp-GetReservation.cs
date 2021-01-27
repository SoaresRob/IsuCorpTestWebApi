using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IsuCorpTest.Migrations
{
    public partial class spGetReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetReservation]
                    @ReservationId BIGINT = NULL
                AS
                BEGIN
                    SET NOCOUNT ON;
                    SELECT A.RevervationId, B.ContactId, B.ContactName, B.PhoneNumber, 
	                    B.BirthDate, A.ReservationDetails, C.ContactTypeId, C.ContactTypeName
                    FROM IsuCorpTestDB.[dbo].[Reservation] A
	                    INNER JOIN IsuCorpTestDB.[dbo].[Contact] B ON A.ContactId = b.ContactId
	                    INNER JOIN IsuCorpTestDB.[dbo].[ContactType] C ON B.ContactTypeId = C.ContactTypeId
                    WHERE (RevervationId = @ReservationId OR @ReservationId IS NULL)
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        
        }
    }
}
