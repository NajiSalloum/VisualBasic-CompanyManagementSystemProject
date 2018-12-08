Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddPropertiesToCustomer
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Customers", "IsAPartner", Function(c) c.Boolean())
            AddColumn("dbo.Customers", "KopplatPartnerID", Function(c) c.Int())
            AddColumn("dbo.Customers", "KopplatPartner_CustomerID", Function(c) c.Int())
            CreateIndex("dbo.Customers", "KopplatPartner_CustomerID")
            AddForeignKey("dbo.Customers", "KopplatPartner_CustomerID", "dbo.Customers", "CustomerID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Customers", "KopplatPartner_CustomerID", "dbo.Customers")
            DropIndex("dbo.Customers", New String() { "KopplatPartner_CustomerID" })
            DropColumn("dbo.Customers", "KopplatPartner_CustomerID")
            DropColumn("dbo.Customers", "KopplatPartnerID")
            DropColumn("dbo.Customers", "IsAPartner")
        End Sub
    End Class
End Namespace
