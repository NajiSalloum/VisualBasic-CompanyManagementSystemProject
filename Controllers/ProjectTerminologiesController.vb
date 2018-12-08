Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace BitLogTimeProject
    Public Class ProjectTerminologiesController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: /ProjectTerminologies/
        Function Index() As ActionResult
            Return View(db.ProjectTerminologies.ToList())
        End Function

        ' GET: /ProjectTerminologies/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim projectterminology As ProjectTerminology = db.ProjectTerminologies.Find(id)
            If IsNothing(projectterminology) Then
                Return HttpNotFound()
            End If
            Return View(projectterminology)
        End Function

        ' GET: /ProjectTerminologies/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: /ProjectTerminologies/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include := "ProjectTerminologyID,ProjectTerminologyName,ProjectTerminologyDescription")> ByVal projectterminology As ProjectTerminology) As ActionResult
            If ModelState.IsValid Then
                db.ProjectTerminologies.Add(projectterminology)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If 
            Return View(projectterminology)
        End Function

        ' GET: /ProjectTerminologies/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim projectterminology As ProjectTerminology = db.ProjectTerminologies.Find(id)
            If IsNothing(projectterminology) Then
                Return HttpNotFound()
            End If
            Return View(projectterminology)
        End Function

        ' POST: /ProjectTerminologies/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include := "ProjectTerminologyID,ProjectTerminologyName,ProjectTerminologyDescription")> ByVal projectterminology As ProjectTerminology) As ActionResult
            If ModelState.IsValid Then
                db.Entry(projectterminology).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(projectterminology)
        End Function

        ' GET: /ProjectTerminologies/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim projectterminology As ProjectTerminology = db.ProjectTerminologies.Find(id)
            If IsNothing(projectterminology) Then
                Return HttpNotFound()
            End If
            Return View(projectterminology)
        End Function

        ' POST: /ProjectTerminologies/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim projectterminology As ProjectTerminology = db.ProjectTerminologies.Find(id)
            db.ProjectTerminologies.Remove(projectterminology)
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
