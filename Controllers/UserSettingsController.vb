Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace BitLogTimeProject
    Public Class UserSettingsController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: /UserSettings/
        Function Index() As ActionResult
            Return View(db.UserSettings.ToList())
        End Function

        ' GET: /UserSettings/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim usersetting As UserSetting = db.UserSettings.Find(id)
            If IsNothing(usersetting) Then
                Return HttpNotFound()
            End If
            Return View(usersetting)
        End Function

        ' GET: /UserSettings/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: /UserSettings/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include := "UserSettingID,UserName,Initials,ExtResourc,ExtTravelTimeID,ExtNoOfK,ExtOtherExpencesID,Active")> ByVal usersetting As UserSetting) As ActionResult
            If ModelState.IsValid Then
                db.UserSettings.Add(usersetting)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If 
            Return View(usersetting)
        End Function

        ' GET: /UserSettings/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim usersetting As UserSetting = db.UserSettings.Find(id)
            If IsNothing(usersetting) Then
                Return HttpNotFound()
            End If
            Return View(usersetting)
        End Function

        ' POST: /UserSettings/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include := "UserSettingID,UserName,Initials,ExtResourc,ExtTravelTimeID,ExtNoOfK,ExtOtherExpencesID,Active")> ByVal usersetting As UserSetting) As ActionResult
            If ModelState.IsValid Then
                db.Entry(usersetting).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(usersetting)
        End Function

        ' GET: /UserSettings/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim usersetting As UserSetting = db.UserSettings.Find(id)
            If IsNothing(usersetting) Then
                Return HttpNotFound()
            End If
            Return View(usersetting)
        End Function

        ' POST: /UserSettings/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim usersetting As UserSetting = db.UserSettings.Find(id)
            db.UserSettings.Remove(usersetting)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
