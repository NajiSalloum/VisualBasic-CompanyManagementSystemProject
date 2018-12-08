Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace BitlogTime
    Public Class PriceListsController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: /PriceLists/
        Function Index() As ActionResult
            Return View(db.PriiceLists.ToList())
        End Function

        ' GET: /PriceLists/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim pricelist As PriceList = db.PriiceLists.Find(id)
            If IsNothing(pricelist) Then
                Return HttpNotFound()
            End If
            Return View(pricelist)
        End Function

        ' GET: /PriceLists/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: /PriceLists/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="PriceListID,PriceListName")> ByVal pricelist As PriceList) As ActionResult
            If ModelState.IsValid Then
                db.PriiceLists.Add(pricelist)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(pricelist)
        End Function

        ' GET: /PriceLists/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim pricelist As PriceList = db.PriiceLists.Find(id)
            If IsNothing(pricelist) Then
                Return HttpNotFound()
            End If
            Return View(pricelist)
        End Function

        ' POST: /PriceLists/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="PriceListID,PriceListName")> ByVal pricelist As PriceList) As ActionResult
            If ModelState.IsValid Then
                db.Entry(pricelist).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(pricelist)
        End Function

        ' GET: /PriceLists/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim pricelist As PriceList = db.PriiceLists.Find(id)
            If IsNothing(pricelist) Then
                Return HttpNotFound()
            End If
            Return View(pricelist)
        End Function

        ' POST: /PriceLists/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim pricelist As PriceList = db.PriiceLists.Find(id)
            db.PriiceLists.Remove(pricelist)
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
