Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddMembershipModel
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Memberships",
                Function(c) New With
                    {
                        .MembershipID = c.Int(nullable := False, identity := True),
                        .UserID = c.String(),
                        .UserName = c.String(),
                        .CreateDate = c.DateTime(),
                        .LastLoginDate = c.DateTime(),
                        .PasswordChangedDate = c.DateTime()
                    }) _
                .PrimaryKey(Function(t) t.MembershipID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.Memberships")
        End Sub
    End Class
End Namespace
