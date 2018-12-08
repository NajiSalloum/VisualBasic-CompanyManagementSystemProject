Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class UpdateEventModeUserID
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropColumn("dbo.RecourseEventLines", "UserID")
            RenameColumn(table := "dbo.RecourseEventLines", name := "User_Id", newName := "UserID")
            AlterColumn("dbo.RecourseEventLines", "UserID", Function(c) c.String(maxLength := 128))
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.RecourseEventLines", "UserID", Function(c) c.Int())
            RenameColumn(table := "dbo.RecourseEventLines", name := "UserID", newName := "User_Id")
            AddColumn("dbo.RecourseEventLines", "UserID", Function(c) c.Int())
        End Sub
    End Class
End Namespace
