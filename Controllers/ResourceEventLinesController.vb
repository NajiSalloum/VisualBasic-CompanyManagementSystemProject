Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace BitLogTimeProject
    Public Class ResourceEventLinesController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: /ResourceEventLines/
        Function Index() As ActionResult
            Dim recourseeventlines = db.RecourseEventLines.Include(Function(r) r.ResourceEvent)
            Return View(recourseeventlines.ToList())
        End Function

        ' GET: /ResourceEventLines/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim recourseeventline As RecourseEventLine = db.RecourseEventLines.Find(id)
            If IsNothing(recourseeventline) Then
                Return HttpNotFound()
            End If
            Return View(recourseeventline)
        End Function

        ' GET: /ResourceEventLines/Create
        Function Create() As ActionResult
            ViewData("Users") = db.Users.Where(Function(c) c.UserName IsNot Nothing).[Select](Function(c) New SelectListItem With
                 {
                 .Text = c.UserName,
                 .Value = c.UserName
                 })
            ViewData("Events") = db.ResourceEvents.[Select](Function(c) New SelectListItem With
                 {
                 .Text = c.EventName,
                 .Value = c.ResourceEventID
                 })
            Dim modelres As New RecourseEventLine() With
                {
                    .EventDate = Date.Now.ToShortDateString
                }
            ViewBag.ResourceEventID = New SelectList(db.ResourceEvents, "ResourceEventID", "EventName")
            Dim resourceEventLineList As New List(Of AllResourceEventLinesView)
            Dim resourceeventlines = Nothing
            resourceeventlines = db.RecourseEventLines.ToList()



            For Each rseventLine As RecourseEventLine In resourceeventlines
                Dim resourceEvent = (From c In db.ResourceEvents
                                  Where c.ResourceEventID = rseventLine.ResourceEventID
                                  Select c).FirstOrDefault


                resourceEventLineList.Add(New AllResourceEventLinesView() With
                              {.EventDate = rseventLine.EventDate.Value.Date,
                               .UserName = rseventLine.UserName,
                               .ResourceEventName = resourceEvent.EventName,
                               .RecourseEventLineID = rseventLine.RecourseEventLineID})
            Next

            Dim model As New CreateAndAllSourceEventLinesView()
            model.ResourceEventLine = modelres
            model.AllRecourseEventLines = resourceEventLineList
            Return View(model)
        End Function

        ' POST: /ResourceEventLines/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal recourseeventline As CreateAndAllSourceEventLinesView) As ActionResult
            If ModelState.IsValid Then
                Dim user = db.Users.Where(Function(u) u.UserName = recourseeventline.ResourceEventLine.UserName).FirstOrDefault
                recourseeventline.ResourceEventLine.UserID = user.Id
                db.RecourseEventLines.Add(recourseeventline.ResourceEventLine)
                db.SaveChanges()
                Return RedirectToAction("Create")
            End If
            ViewBag.ResourceEventID = New SelectList(db.ResourceEvents, "ResourceEventID", "EventName", recourseeventline.ResourceEventLine.ResourceEventID)
            Return View(recourseeventline)
           End Function

        ' GET: /ResourceEventLines/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim recourseeventline As RecourseEventLine = db.RecourseEventLines.Find(id)
            If IsNothing(recourseeventline) Then
                Return HttpNotFound()
            End If
            ViewBag.ResourceEventID = New SelectList(db.ResourceEvents, "ResourceEventID", "EventName", recourseeventline.ResourceEventID)
            Return View(recourseeventline)
        End Function

        ' POST: /ResourceEventLines/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="RecourseEventLineID,UserID,UserName,EventDate,ResourceEventID")> ByVal recourseeventline As RecourseEventLine) As ActionResult
            If ModelState.IsValid Then
                db.Entry(recourseeventline).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.ResourceEventID = New SelectList(db.ResourceEvents, "ResourceEventID", "EventName", recourseeventline.ResourceEventID)
            Return View(recourseeventline)
        End Function

        ' GET: /ResourceEventLines/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim recourseeventline As RecourseEventLine = db.RecourseEventLines.Find(id)
            Dim resourceevent = db.ResourceEvents.Where(Function(r) r.ResourceEventID = recourseeventline.ResourceEventID).FirstOrDefault
            recourseeventline.ResourceEvent = resourceevent
            If IsNothing(recourseeventline) Then
                Return HttpNotFound()
            End If
            Return View(recourseeventline)
        End Function

        ' POST: /ResourceEventLines/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim recourseeventline As RecourseEventLine = db.RecourseEventLines.Find(id)
            db.RecourseEventLines.Remove(recourseeventline)
            db.SaveChanges()
            Return RedirectToAction("Create")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Get: /ResourceEventLines/AllResourceEventLines
        Function AllResourceEventLines() As ActionResult
            Dim resourceEventLineList As New List(Of AllResourceEventLinesView)
            Dim resourceeventlines = Nothing
            resourceeventlines = db.RecourseEventLines.ToList()
            


            For Each rseventLine As RecourseEventLine In resourceeventlines
                Dim resourceEvent = (From c In db.ResourceEvents
                                  Where c.ResourceEventID = rseventLine.ResourceEventID
                                  Select c).FirstOrDefault

                
                resourceEventLineList.Add(New AllResourceEventLinesView() With
                              {.EventDate = rseventLine.EventDate,
                               .UserName = rseventLine.UserName,
                               .ResourceEventName = resourceEvent.EventName,
                               .RecourseEventLineID = rseventLine.RecourseEventLineID})
            Next
            Return View(resourceEventLineList)
        End Function

        Function Schedule() As ActionResult
            Dim model As New List(Of DatesView)
            Dim users = db.Users.Where(Function(u) u.UserName IsNot Nothing).ToList()

            For Each user As ApplicationUser In users
                Dim dModel As New DatesView
                Dim resourceevenlines = db.RecourseEventLines.Where(Function(r) r.UserName = user.UserName).ToList()
                For Each item As RecourseEventLine In resourceevenlines
                    If item.EventDate = Date.Now.Date Then
                        Dim rsEvent = db.ResourceEvents.Where(Function(r) r.ResourceEventID = item.ResourceEventID).FirstOrDefault
                        dModel.ResourceEvent0 = rsEvent.EventName
                    End If
                    If item.EventDate = Date.Now.Date.AddDays(1) Then
                        Dim rsEvent = db.ResourceEvents.Where(Function(r) r.ResourceEventID = item.ResourceEventID).FirstOrDefault
                        dModel.ResourceEvent1 = rsEvent.EventName
                    End If
                    If item.EventDate = Date.Now.Date.AddDays(2) Then
                        Dim rsEvent = db.ResourceEvents.Where(Function(r) r.ResourceEventID = item.ResourceEventID).FirstOrDefault
                        dModel.ResourceEvent2 = rsEvent.EventName
                    End If
                    If item.EventDate = Date.Now.Date.AddDays(3) Then
                        Dim rsEvent = db.ResourceEvents.Where(Function(r) r.ResourceEventID = item.ResourceEventID).FirstOrDefault
                        dModel.ResourceEvent3 = rsEvent.EventName
                    End If
                    If item.EventDate = Date.Now.Date.AddDays(4) Then
                        Dim rsEvent = db.ResourceEvents.Where(Function(r) r.ResourceEventID = item.ResourceEventID).FirstOrDefault
                        dModel.ResourceEvent4 = rsEvent.EventName
                    End If
                    If item.EventDate = Date.Now.Date.AddDays(5) Then
                        Dim rsEvent = db.ResourceEvents.Where(Function(r) r.ResourceEventID = item.ResourceEventID).FirstOrDefault
                        dModel.ResourceEvent5 = rsEvent.EventName
                    End If
                    If item.EventDate = Date.Now.Date.AddDays(6) Then
                        Dim rsEvent = db.ResourceEvents.Where(Function(r) r.ResourceEventID = item.ResourceEventID).FirstOrDefault
                        dModel.ResourceEvent6 = rsEvent.EventName
                    End If
                    If item.EventDate = Date.Now.Date.AddDays(7) Then
                        Dim rsEvent = db.ResourceEvents.Where(Function(r) r.ResourceEventID = item.ResourceEventID).FirstOrDefault
                        dModel.ResourceEvent7 = rsEvent.EventName
                    End If
                    If item.EventDate = Date.Now.Date.AddDays(8) Then
                        Dim rsEvent = db.ResourceEvents.Where(Function(r) r.ResourceEventID = item.ResourceEventID).FirstOrDefault
                        dModel.ResourceEvent8 = rsEvent.EventName
                    End If
                    If item.EventDate = Date.Now.Date.AddDays(9) Then
                        Dim rsEvent = db.ResourceEvents.Where(Function(r) r.ResourceEventID = item.ResourceEventID).FirstOrDefault
                        dModel.ResourceEvent9 = rsEvent.EventName
                    End If
                    If item.EventDate = Date.Now.Date.AddDays(10) Then
                        Dim rsEvent = db.ResourceEvents.Where(Function(r) r.ResourceEventID = item.ResourceEventID).FirstOrDefault
                        dModel.ResourceEvent10 = rsEvent.EventName
                    End If
                    If item.EventDate = Date.Now.Date.AddDays(11) Then
                        Dim rsEvent = db.ResourceEvents.Where(Function(r) r.ResourceEventID = item.ResourceEventID).FirstOrDefault
                        dModel.ResourceEvent11 = rsEvent.EventName
                    End If
                    If item.EventDate = Date.Now.Date.AddDays(12) Then
                        Dim rsEvent = db.ResourceEvents.Where(Function(r) r.ResourceEventID = item.ResourceEventID).FirstOrDefault
                        dModel.ResourceEvent12 = rsEvent.EventName
                    End If
                    If item.EventDate = Date.Now.Date.AddDays(13) Then
                        Dim rsEvent = db.ResourceEvents.Where(Function(r) r.ResourceEventID = item.ResourceEventID).FirstOrDefault
                        dModel.ResourceEvent13 = rsEvent.EventName
                    End If

                Next

                dModel.UserName = user.UserName

                If Date.Today.DayOfWeek.ToString = "Sunday" Or Date.Today.DayOfWeek.ToString = "Saturday" Then
                    dModel.ResourceEvent0 = "XXXXX"
                End If
                If Date.Today.AddDays(1).DayOfWeek.ToString = "Sunday" Or Date.Today.AddDays(1).DayOfWeek.ToString = "Saturday" Then
                    dModel.ResourceEvent1 = "XXXXX"
                End If
                If Date.Today.AddDays(2).DayOfWeek.ToString = "Sunday" Or Date.Today.AddDays(2).DayOfWeek.ToString = "Saturday" Then
                    dModel.ResourceEvent2 = "XXXXX"
                End If
                If Date.Today.AddDays(3).DayOfWeek.ToString = "Sunday" Or Date.Today.AddDays(3).DayOfWeek.ToString = "Saturday" Then
                    dModel.ResourceEvent3 = "XXXXX"
                End If
                If Date.Today.AddDays(4).DayOfWeek.ToString = "Sunday" Or Date.Today.AddDays(4).DayOfWeek.ToString = "Saturday" Then
                    dModel.ResourceEvent4 = "XXXXX"
                End If
                If Date.Today.AddDays(5).DayOfWeek.ToString = "Sunday" Or Date.Today.AddDays(5).DayOfWeek.ToString = "Saturday" Then
                    dModel.ResourceEvent5 = "XXXXX"
                End If
                If Date.Today.AddDays(6).DayOfWeek.ToString = "Sunday" Or Date.Today.AddDays(6).DayOfWeek.ToString = "Saturday" Then
                    dModel.ResourceEvent6 = "XXXXX"
                End If
                If Date.Today.AddDays(7).DayOfWeek.ToString = "Sunday" Or Date.Today.AddDays(7).DayOfWeek.ToString = "Saturday" Then
                    dModel.ResourceEvent7 = "XXXXX"
                End If
                If Date.Today.AddDays(8).DayOfWeek.ToString = "Sunday" Or Date.Today.AddDays(8).DayOfWeek.ToString = "Saturday" Then
                    dModel.ResourceEvent8 = "XXXXX"
                End If
                If Date.Today.AddDays(9).DayOfWeek.ToString = "Sunday" Or Date.Today.AddDays(9).DayOfWeek.ToString = "Saturday" Then
                    dModel.ResourceEvent9 = "XXXXX"
                End If
                If Date.Today.AddDays(10).DayOfWeek.ToString = "Sunday" Or Date.Today.AddDays(10).DayOfWeek.ToString = "Saturday" Then
                    dModel.ResourceEvent10 = "XXXXX"
                End If
                If Date.Today.AddDays(11).DayOfWeek.ToString = "Sunday" Or Date.Today.AddDays(11).DayOfWeek.ToString = "Saturday" Then
                    dModel.ResourceEvent11 = "XXXXX"
                End If
                If Date.Today.AddDays(12).DayOfWeek.ToString = "Sunday" Or Date.Today.AddDays(12).DayOfWeek.ToString = "Saturday" Then
                    dModel.ResourceEvent12 = "XXXXX"
                End If
                If Date.Today.AddDays(13).DayOfWeek.ToString = "Sunday" Or Date.Today.AddDays(13).DayOfWeek.ToString = "Saturday" Then
                    dModel.ResourceEvent13 = "XXXXX"
                End If

                model.Add(dModel)

            Next

            Return View(model)
        End Function
    End Class
End Namespace
