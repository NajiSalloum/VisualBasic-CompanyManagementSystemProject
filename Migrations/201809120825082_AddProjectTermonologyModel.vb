Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddProjectTermonologyModel
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.ProjectTerminologies",
                Function(c) New With
                    {
                        .ProjectTerminologyID = c.Int(nullable := False, identity := True),
                        .ProjectTerminologyName = c.Int(nullable := False),
                        .ProjectTerminologyDescription = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ProjectTerminologyID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.ProjectTerminologies")
        End Sub
    End Class
End Namespace
