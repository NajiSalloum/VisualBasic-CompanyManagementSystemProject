Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class MoidfyPropperityIsApartner
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.Customers", "IsAPartner", Function(c) c.Boolean(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.Customers", "IsAPartner", Function(c) c.Boolean())
        End Sub
    End Class
End Namespace
