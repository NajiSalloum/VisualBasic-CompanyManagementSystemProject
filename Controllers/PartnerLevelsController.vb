Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace BitlogTime
    Public Class PartnerLevelsController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: /PartnerLevels/
        Function Index() As ActionResult
            Return View(db.PartnerLevels.ToList())
        End Function

        ' GET: /PartnerLevels/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim partnerlevel As PartnerLevel = db.PartnerLevels.Find(id)
            If IsNothing(partnerlevel) Then
                Return HttpNotFound()
            End If
            Return View(partnerlevel)
        End Function

        ' GET: /PartnerLevels/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: /PartnerLevels/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="PartnerLevelID,PartnerLevelName")> ByVal partnerlevel As PartnerLevel) As ActionResult
            If ModelState.IsValid Then
                db.PartnerLevels.Add(partnerlevel)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(partnerlevel)
        End Function

        ' GET: /PartnerLevels/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim partnerlevel As PartnerLevel = db.PartnerLevels.Find(id)
            If IsNothing(partnerlevel) Then
                Return HttpNotFound()
            End If
            Return View(partnerlevel)
        End Function

        ' POST: /PartnerLevels/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="PartnerLevelID,PartnerLevelName")> ByVal partnerlevel As PartnerLevel) As ActionResult
            If ModelState.IsValid Then
                db.Entry(partnerlevel).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(partnerlevel)
        End Function

        ' GET: /PartnerLevels/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim partnerlevel As PartnerLevel = db.PartnerLevels.Find(id)
            If IsNothing(partnerlevel) Then
                Return HttpNotFound()
            End If
            Return View(partnerlevel)
        End Function

        ' POST: /PartnerLevels/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim partnerlevel As PartnerLevel = db.PartnerLevels.Find(id)
            db.PartnerLevels.Remove(partnerlevel)
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
