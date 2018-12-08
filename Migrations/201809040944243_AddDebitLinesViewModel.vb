Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddDebitLinesViewModel
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.DebitLinesViews",
                Function(c) New With
                    {
                        .LineID = c.Int(nullable := False, identity := True),
                        .DebDate = c.DateTime(nullable := False),
                        .UserName = c.String(),
                        .CustomerID = c.Int(),
                        .NoOfHours = c.Decimal(precision := 18, scale := 2),
                        .NoOfTravelHours = c.Decimal(precision := 18, scale := 2),
                        .NoOfKm = c.Int(),
                        .OtherExpences = c.Decimal(precision := 18, scale := 2),
                        .ProjectID = c.Int(),
                        .Description = c.String(),
                        .Invoiced = c.DateTime(),
                        .Regesterad = c.DateTime(),
                        .PricePerHoure = c.Decimal(precision := 18, scale := 2),
                        .TravelPrice = c.Decimal(precision := 18, scale := 2),
                        .PricePerKm = c.Int(),
                        .Status = c.Int(),
                        .Comission = c.Decimal(precision := 18, scale := 2),
                        .Subscription = c.Int(),
                        .CompanyCar = c.Boolean(),
                        .Year = c.String(),
                        .Month = c.String(),
                        .LineTotal = c.Decimal(precision := 18, scale := 2),
                        .ComissionBased = c.Decimal(precision := 18, scale := 2),
                        .KmAndOther = c.Decimal(precision := 18, scale := 2)
                    }) _
                .PrimaryKey(Function(t) t.LineID) _
                .ForeignKey("dbo.Customers", Function(t) t.CustomerID) _
                .ForeignKey("dbo.Projects", Function(t) t.ProjectID) _
                .Index(Function(t) t.CustomerID) _
                .Index(Function(t) t.ProjectID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.DebitLinesViews", "ProjectID", "dbo.Projects")
            DropForeignKey("dbo.DebitLinesViews", "CustomerID", "dbo.Customers")
            DropIndex("dbo.DebitLinesViews", New String() { "ProjectID" })
            DropIndex("dbo.DebitLinesViews", New String() { "CustomerID" })
            DropTable("dbo.DebitLinesViews")
        End Sub
    End Class
End Namespace
