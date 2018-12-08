Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddEvents
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.ResourceEvents",
                Function(c) New With
                    {
                        .ResourceEventID = c.Int(nullable := False, identity := True),
                        .EventName = c.String(),
                        .EventType = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ResourceEventID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.ResourceEvents")
        End Sub
    End Class
End Namespace
