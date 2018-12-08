Imports System.Web.Mvc
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web


Public Class MembersController
    Inherits Controller
    Dim db As New ApplicationDbContext()

    Dim roleStore As New RoleStore(Of IdentityRole)(db)
    Dim roleManager As New RoleManager(Of IdentityRole)(roleStore)
    Dim userStore As New UserStore(Of ApplicationUser)(db)

    Dim UserManager As New UserManager(Of ApplicationUser)(userStore)

    ' GET: /Members
    Function Index() As ActionResult
        Return View()
    End Function
    'GET: Members/RegisterMember
    Function RegisterMember() As ActionResult

        Return View()
    End Function


    <HttpPost()>
    <ValidateAntiForgeryToken()>
    Function RegisterMember(model As RegisterViewModel) As ActionResult
        If model.Kind = 2 Then
            If ModelState.IsValid Then
                ' Create a local login before signing in the user
                Dim user = New ApplicationUser() With {.UserName = model.UserName}
                Dim pass As String = model.Password
                Dim result = UserManager.Create(user, pass)
                Dim UserToAdd = UserManager.FindByName(user.UserName)
                UserManager.AddToRole(user.Id, "Konsult")
                Dim member As New Membership() With {
                    .UserID = user.Id,
                    .UserName = user.UserName,
                    .CreateDate = Date.Now}
                db.Memberships.Add(member)
                db.SaveChanges()

                Dim userSetting As New UserSetting() With {
                    .UserName = user.UserName,
                    .Initials = Nothing,
                    .ExtTravelTimeID = Nothing,
                    .ExtResourc = Nothing,
                    .ExtNoOfK = Nothing,
                    .ExtOtherExpencesID = Nothing,
                    .Active = True}
                db.UserSettings.Add(userSetting)
                db.SaveChanges()

                Return RedirectToAction("AllUsers")
            End If
        Else
            If ModelState.IsValid Then
                ' Create a local login before signing in the user
                Dim user = New ApplicationUser() With {.UserName = model.UserName}
                Dim pass As String = model.Password
                Dim result = UserManager.Create(user, pass)
                Dim UserToAdd = UserManager.FindByName(user.UserName)
                UserManager.AddToRole(user.Id, "Admin")
                Dim member As New Membership() With {
                    .UserID = user.Id,
                    .UserName = user.UserName,
                    .CreateDate = Date.Now}
                db.Memberships.Add(member)
                db.SaveChanges()


                Dim userSetting As New UserSetting() With {
                    .UserName = user.UserName,
                    .Initials = Nothing,
                    .ExtTravelTimeID = Nothing,
                    .ExtResourc = Nothing,
                    .ExtNoOfK = Nothing,
                    .ExtOtherExpencesID = Nothing,
                    .Active = True}
                db.UserSettings.Add(userSetting)
                db.SaveChanges()
                Return RedirectToAction("AllUsers")
            End If

        End If


        ' If we got this far, something failed, redisplay form
        Return View(model)
    End Function


    'GET: /Members/ChangePassword
    Function ChangePassword(ByVal id As String) As ActionResult
        If IsNothing(id) Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim user As ApplicationUser = db.Users.Find(id)
        If IsNothing(user) Then
            Return HttpNotFound()
        End If

        Dim model As New UserView() With {
            .Id = user.Id,
            .UserName = user.UserName,
            .Password = "",
            .ConfirmPassword = ""}
        Return View(model)
    End Function

    ' POST: /Companies/Edit/5
    'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    <HttpPost()>
    <ValidateAntiForgeryToken()>
    Function ChangePassword(ByVal user As UserView) As ActionResult
        If ModelState.IsValid Then
            'Dim CurrentUser = UserManager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId())
            'System.Web.HttpContext.Current.User.Identity.GetUserId()
            UserManager.RemovePassword(user.Id)
            UserManager.AddPassword(user.Id, user.Password)
            Return RedirectToAction("Index", "Home")
        End If
        Return View(user)
    End Function

    'GET: /Members/AllUsers
    Function AllUsers() As ActionResult
        Dim usersList As New List(Of AllUsersView)
        Dim users = db.Users.Where(Function(u) u.UserName <> "").ToList()
        For Each user As ApplicationUser In users

            If UserManager.IsInRole(user.Id, "Admin") And UserManager.IsInRole(user.Id, "Konsult") Then
                usersList.Add(New AllUsersView() With
                          {.Id = user.Id,
                            .UserName = user.UserName,
                           .Role = "Admin & Konsult"
                           })

            ElseIf UserManager.IsInRole(user.Id, "Admin") Then
                usersList.Add(New AllUsersView() With
                          {.Id = user.Id,
                            .UserName = user.UserName,
                           .Role = "Admin"
                           })
            Else
                usersList.Add(New AllUsersView() With
                         {.Id = user.Id,
                           .UserName = user.UserName,
                          .Role = "Konsult"
                          })

            End If





                    Next
        Return View(usersList)
    End Function


    ' GET: /Members/Delete/5
    Function Delete(ByVal id As String) As ActionResult
        If IsNothing(id) Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim user As ApplicationUser = db.Users.Find(id)
        If IsNothing(user) Then
            Return HttpNotFound()
        End If
        Dim model As New UserView() With {
            .Id = user.Id,
            .ConfirmPassword = user.SecurityStamp,
            .Password = user.PasswordHash,
            .UserName = user.UserName}
        Return View(model)
    End Function

    ' POST: /Members/Delete/5
    <HttpPost()>
    <ActionName("Delete")>
    <ValidateAntiForgeryToken()>
    Function DeleteConfirmed(ByVal id As String) As ActionResult
        Dim user As ApplicationUser = db.Users.Find(id)
        user.UserName = ""
        user.PasswordHash = ""
        user.SecurityStamp = ""
        db.Entry(user).State = EntityState.Modified
        db.SaveChanges()
        Return RedirectToAction("AllUsers")
    End Function


    'url: Members/UniqueUserName
    Function UniqueUserName(ByVal DataName As String, ByVal Text As String) As JsonResult
        If DataName = "UserName" Then
            Dim data = (From u In db.Users
                        Where u.UserName = Text).ToList()
            Return Json(data)
        End If
        Return Nothing
        Return Nothing
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If (disposing) Then
            db.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' GET: /Members/MembershipDetails/5
    Function MembershipDetails(Optional ByVal id As String = "") As ActionResult
        If IsNothing(id) Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If

        Dim member As Membership = db.Memberships.Where(Function(c) c.UserID = id).FirstOrDefault
        If IsNothing(member) Then
            Return HttpNotFound()
        End If
        Return View(member)
    End Function



    ' GET: /Members/AddToRole/5
    Function AddToRole(ByVal id As String) As ActionResult
        If IsNothing(id) Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim user As ApplicationUser = db.Users.Find(id)
        If IsNothing(user) Then
            Return HttpNotFound()
        End If
        Dim role As String = ""

        If UserManager.IsInRole(user.Id, "Admin") Then
            Dim model As New UserRoleView() With {
          .Id = user.Id,
          .UserName = user.UserName,
          .Kind = 1}
            Return View(model)
        Else
            Dim model As New UserRoleView() With {
          .Id = user.Id,
          .UserName = user.UserName,
          .Kind = 2}
            Return View(model)
        End If




    End Function

    ' POST: /Members/AddToRole/5
    'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    <HttpPost()>
    <ValidateAntiForgeryToken()>
    Function AddToRole(<Bind(Include:="Id,UserName,Kind")> ByVal user As UserRoleView) As ActionResult
        If user.Kind = 1 Then
            UserManager.AddToRole(user.Id, "Admin")
        Else
            UserManager.AddToRole(user.Id, "Konsult")

        End If

        Return RedirectToAction("AllUsers")
    End Function


End Class