Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class addModlesPeriodtypeAndSubscription
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.PeriodTypes",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .PeriodTypeID = c.Int(nullable := False),
                        .PeriodTypeName = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.Subscriptions",
                Function(c) New With
                    {
                        .SubscriptionID = c.Int(nullable := False, identity := True),
                        .ProjectID = c.Int(),
                        .CustomerID = c.Int(),
                        .PeriodTypeID = c.Int(),
                        .UserName = c.String(),
                        .NoOfHours = c.Decimal(precision := 18, scale := 2),
                        .PricePerHour = c.Decimal(precision := 18, scale := 2),
                        .RegisteredDate = c.DateTime(),
                        .Description = c.String(),
                        .LastInvoiced = c.DateTime(),
                        .LockedToUser = c.Boolean(),
                        .StartDate = c.DateTime(),
                        .AutoDeb = c.Boolean(nullable := False),
                        .Commission = c.Decimal(precision := 18, scale := 2)
                    }) _
                .PrimaryKey(Function(t) t.SubscriptionID) _
                .ForeignKey("dbo.Customers", Function(t) t.CustomerID) _
                .ForeignKey("dbo.PeriodTypes", Function(t) t.PeriodTypeID) _
                .ForeignKey("dbo.Projects", Function(t) t.ProjectID) _
                .Index(Function(t) t.CustomerID) _
                .Index(Function(t) t.PeriodTypeID) _
                .Index(Function(t) t.ProjectID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Subscriptions", "ProjectID", "dbo.Projects")
            DropForeignKey("dbo.Subscriptions", "PeriodTypeID", "dbo.PeriodTypes")
            DropForeignKey("dbo.Subscriptions", "CustomerID", "dbo.Customers")
            DropIndex("dbo.Subscriptions", New String() { "ProjectID" })
            DropIndex("dbo.Subscriptions", New String() { "PeriodTypeID" })
            DropIndex("dbo.Subscriptions", New String() { "CustomerID" })
            DropTable("dbo.Subscriptions")
            DropTable("dbo.PeriodTypes")
        End Sub
    End Class
End Namespace
