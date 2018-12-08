Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddEventLineModel
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.RecourseEventLines",
                Function(c) New With
                    {
                        .RecourseEventLineID = c.Int(nullable := False, identity := True),
                        .UserID = c.Int(),
                        .UserName = c.String(),
                        .EventDate = c.DateTime(),
                        .ResourceEventID = c.Int(),
                        .User_Id = c.String(maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.RecourseEventLineID) _
                .ForeignKey("dbo.ResourceEvents", Function(t) t.ResourceEventID) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.User_Id) _
                .Index(Function(t) t.ResourceEventID) _
                .Index(Function(t) t.User_Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.RecourseEventLines", "User_Id", "dbo.AspNetUsers")
            DropForeignKey("dbo.RecourseEventLines", "ResourceEventID", "dbo.ResourceEvents")
            DropIndex("dbo.RecourseEventLines", New String() { "User_Id" })
            DropIndex("dbo.RecourseEventLines", New String() { "ResourceEventID" })
            DropTable("dbo.RecourseEventLines")
        End Sub
    End Class
End Namespace
