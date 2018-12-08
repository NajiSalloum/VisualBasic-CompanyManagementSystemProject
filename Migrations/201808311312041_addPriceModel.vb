Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class addPriceModel
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Prices",
                Function(c) New With
                    {
                        .PriceID = c.Int(nullable := False, identity := True),
                        .PriceListID = c.Int(nullable := False),
                        .UserID = c.String(maxLength := 128),
                        .PricePerHour = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .TravelPrice = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .PricePerKm = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .Commission = c.Decimal(nullable := False, precision := 18, scale := 2)
                    }) _
                .PrimaryKey(Function(t) t.PriceID) _
                .ForeignKey("dbo.PriceLists", Function(t) t.PriceListID, cascadeDelete := True) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.UserID) _
                .Index(Function(t) t.PriceListID) _
                .Index(Function(t) t.UserID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Prices", "UserID", "dbo.AspNetUsers")
            DropForeignKey("dbo.Prices", "PriceListID", "dbo.PriceLists")
            DropIndex("dbo.Prices", New String() { "UserID" })
            DropIndex("dbo.Prices", New String() { "PriceListID" })
            DropTable("dbo.Prices")
        End Sub
    End Class
End Namespace
