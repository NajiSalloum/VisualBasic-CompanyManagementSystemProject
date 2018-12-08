Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class UpdateProjectInDebitLine
        Inherits DbMigration
    
        Public Overrides Sub Up()
            RenameColumn(table := "dbo.DebitLines", name := "Project_ProjectID", newName := "ProjectID")
            DropColumn("dbo.DebitLines", "ProjectName")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.DebitLines", "ProjectName", Function(c) c.String())
            RenameColumn(table := "dbo.DebitLines", name := "ProjectID", newName := "Project_ProjectID")
        End Sub
    End Class
End Namespace
