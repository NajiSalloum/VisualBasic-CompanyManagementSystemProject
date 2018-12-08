Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddUserSettingsModel
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.UserSettings",
                Function(c) New With
                    {
                        .UserSettingID = c.Int(nullable := False, identity := True),
                        .UserName = c.String(),
                        .Initials = c.String(),
                        .ExtResourc = c.String(),
                        .ExtTravelTimeID = c.String(),
                        .ExtNoOfK = c.String(),
                        .ExtOtherExpencesID = c.String(),
                        .Active = c.Boolean(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.UserSettingID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.UserSettings")
        End Sub
    End Class
End Namespace
