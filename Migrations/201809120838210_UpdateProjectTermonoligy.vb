Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class UpdateProjectTermonoligy
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.ProjectTerminologies", "ProjectTerminologyName", Function(c) c.String(nullable := False))
            AlterColumn("dbo.ProjectTerminologies", "ProjectTerminologyDescription", Function(c) c.String(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.ProjectTerminologies", "ProjectTerminologyDescription", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.ProjectTerminologies", "ProjectTerminologyName", Function(c) c.Int(nullable := False))
        End Sub
    End Class
End Namespace
