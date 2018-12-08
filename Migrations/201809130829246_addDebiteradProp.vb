Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class addDebiteradProp
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Subscriptions", "Debiterad", Function(c) c.Boolean(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.Subscriptions", "Debiterad")
        End Sub
    End Class
End Namespace
