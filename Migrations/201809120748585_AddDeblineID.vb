Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddDeblineID
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.DebitLinesViews", "DebLineID", Function(c) c.Int())
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.DebitLinesViews", "DebLineID")
        End Sub
    End Class
End Namespace
