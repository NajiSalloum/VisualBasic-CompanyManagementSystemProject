Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework

Namespace Migrations

    Friend NotInheritable Class Configuration
        Inherits DbMigrationsConfiguration(Of ApplicationDbContext)

        Public Sub New()
            AutomaticMigrationsEnabled = False
        End Sub

        Protected Overrides Sub Seed(context As ApplicationDbContext)
            '  This method will be called after migrating to the latest version.

            '  You can use the DbSet(Of T).AddOrUpdate() helper extension method 
            '  to avoid creating duplicate seed data. E.g.
            '
            '    context.People.AddOrUpdate(
            '       Function(c) c.FullName,
            '       New Customer() With {.FullName = "Andrew Peters"},
            '       New Customer() With {.FullName = "Brice Lambson"},
            '       New Customer() With {.FullName = "Rowan Miller"})



            Dim roleStore As New RoleStore(Of IdentityRole)(context)
            Dim roleManager As New RoleManager(Of IdentityRole)(roleStore)
            Dim roleNames() As String = {"Admin", "Konsult"}

            For Each roleName As String In roleNames
                If (context.Roles.Any(Function(r) r.Name = roleName)) Then
                    Continue For
                Else
                    Dim role As New IdentityRole With {.Name = roleName}
                    Dim result = roleManager.Create(role)

                End If



            Next


        End Sub

    End Class

End Namespace
