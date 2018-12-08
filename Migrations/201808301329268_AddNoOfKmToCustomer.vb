Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddNoOfKmToCustomer
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Customers", "NoOfKm", Function(c) c.Int())
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.Customers", "NoOfKm")
        End Sub
    End Class
End Namespace
