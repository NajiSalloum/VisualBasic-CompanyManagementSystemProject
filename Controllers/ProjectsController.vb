Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace BitLogTimeProject
    Public Class ProjectsController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: /Projects/
        Function Index() As ActionResult
            Dim projects = db.Projects.Where(Function(p) p.Customer.Deleted = False).OrderBy(Function(c) c.CustomerID).Include(Function(p) p.Customer)
            Return View(projects.ToList())
        End Function

        ' GET: /Projects/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim project As Project = db.Projects.Find(id)
            If IsNothing(project) Then
                Return HttpNotFound()
            End If
            Return View(project)
        End Function

        ' GET: /Projects/Create
        Function Create(ByVal id As String) As ActionResult
            ViewBag.CustomerID = New SelectList(db.Customers, "CustomerID", "ExtCustID")
            If IsNothing(id) Then
                ViewData("Customers") = db.Customers.[Select](Function(c) New SelectListItem With
            {
                .Text = c.CustName,
                .Value = c.CustomerID
            })
            Else
                ViewData("Customers") = db.Customers.Where(Function(c) c.CustomerID = id).[Select](Function(c) New SelectListItem With
            {
                .Text = c.CustName,
                .Value = c.CustomerID
            })
            End If



            Return View()
        End Function

        ' POST: /Projects/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include := "ProjectID,ProjectName,CustomerID")> ByVal project As Project) As ActionResult
            If ModelState.IsValid Then
                db.Projects.Add(project)
                db.SaveChanges()
                Return RedirectToAction("Create", "Subscriptions", New With {.id = project.CustomerID})
            End If 
            ViewBag.CustomerID = New SelectList(db.Customers, "CustomerID", "ExtCustID", project.CustomerID)
            Return View(project)
        End Function

        ' GET: /Projects/Create
        Function CreateAndBackToDebitLine(ByVal id As String) As ActionResult
            ViewBag.CustomerID = New SelectList(db.Customers, "CustomerID", "ExtCustID")
            If IsNothing(id) Then
                ViewData("Customers") = db.Customers.[Select](Function(c) New SelectListItem With
            {
                .Text = c.CustName,
                .Value = c.CustomerID
            })
            Else
                ViewData("Customers") = db.Customers.Where(Function(c) c.CustomerID = id).[Select](Function(c) New SelectListItem With
            {
                .Text = c.CustName,
                .Value = c.CustomerID
            })
            End If



            Return View()
        End Function

        ' POST: /Projects/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function CreateAndBackToDebitLine(<Bind(Include:="ProjectID,ProjectName,CustomerID")> ByVal project As Project) As ActionResult
            If ModelState.IsValid Then
                db.Projects.Add(project)
                db.SaveChanges()
                Return RedirectToAction("Create", "DebitLines", New With {.id = project.CustomerID})
            End If
            ViewBag.CustomerID = New SelectList(db.Customers, "CustomerID", "ExtCustID", project.CustomerID)
            Return View(project)
        End Function



        ' GET: /Projects/AddCustomerToProject
        Function AddCustomerToProject(ByVal id As Integer?) As ActionResult
            ViewBag.CustomerID = New SelectList(db.Customers, "CustomerID", "ExtCustID")

            If id Is Nothing Then
                ViewData("Customers") = db.Customers.Where(Function(c) c.Deleted = False).[Select](Function(c) New SelectListItem With
            {
                .Text = c.CustName,
            .Value = c.CustomerID
            })
            Else
                ViewData("Customers") = db.Customers.Where(Function(c) c.CustomerID = id).[Select](Function(c) New SelectListItem With
            {
                .Text = c.CustName,
            .Value = c.CustomerID
            })
            End If


            Dim ProjectsList = db.ProjectTerminologies.ToList()

            ViewBag.Projects = New SelectList(db.Projects, "ProjectID", "ProjectName")

            ViewData("Projects") = db.ProjectTerminologies.[Select](Function(p) New SelectListItem With
            {
                .Text = p.ProjectTerminologyName,
                .Value = p.ProjectTerminologyName
            })
            ViewData("PeriodTypes") = New SelectList(db.Projects, "ProjectID", "ProjectName")
            Return View()
        End Function

        ' POST: /Projects/AddCustomerToProject
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function AddCustomerToProject(<Bind(Include:="ProjectName,,CustomerID")> ByVal project As Project) As ActionResult
            If ModelState.IsValid Then
                Dim proj = db.Projects.Where(Function(p) p.CustomerID = project.CustomerID And p.ProjectName = project.ProjectName).FirstOrDefault
                If proj IsNot Nothing Then
                    Return RedirectToAction("AddCustomerToProject")
                End If

                db.Projects.Add(project)
                db.SaveChanges()
                Return RedirectToAction("Create", "DebitLines", New With {.id = Url.RequestContext.RouteData.Values("id")})
            End If
            ViewBag.CustomerID = New SelectList(db.Customers, "CustomerID", "ExtCustID", project.CustomerID)
            Return View(project)
        End Function



        ' GET: /Projects/AddCustomerToProjectAndBackToSubscription
        Function AddCustomerToProjectAndBackToSubscription(ByVal id As Integer?) As ActionResult
            ViewBag.CustomerID = New SelectList(db.Customers, "CustomerID", "ExtCustID")

            If id Is Nothing Then
                ViewData("Customers") = db.Customers.Where(Function(c) c.Deleted = False).[Select](Function(c) New SelectListItem With
            {
                .Text = c.CustName,
            .Value = c.CustomerID
            })
            Else
                ViewData("Customers") = db.Customers.Where(Function(c) c.CustomerID = id).[Select](Function(c) New SelectListItem With
            {
                .Text = c.CustName,
            .Value = c.CustomerID
            })
            End If


            Dim ProjectsList = db.ProjectTerminologies.ToList()

            ViewBag.Projects = New SelectList(db.Projects, "ProjectID", "ProjectName")

            ViewData("Projects") = db.ProjectTerminologies.[Select](Function(p) New SelectListItem With
            {
                .Text = p.ProjectTerminologyName,
                .Value = p.ProjectTerminologyName
            })
            ViewData("PeriodTypes") = New SelectList(db.Projects, "ProjectID", "ProjectName")
            Return View()
        End Function

        ' POST: /Projects/AddCustomerToProject
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function AddCustomerToProjectAndBackToSubscription(<Bind(Include:="ProjectName,,CustomerID")> ByVal project As Project) As ActionResult
            If ModelState.IsValid Then
                Dim proj = db.Projects.Where(Function(p) p.CustomerID = project.CustomerID And p.ProjectName = project.ProjectName).FirstOrDefault
                If proj IsNot Nothing Then
                    Return RedirectToAction("AddCustomerToProjectAndBackToSubscription")
                End If

                db.Projects.Add(project)
                db.SaveChanges()
                Return RedirectToAction("Create", "Subscriptions", New With {.id = Url.RequestContext.RouteData.Values("id")})
            End If
            ViewBag.CustomerID = New SelectList(db.Customers, "CustomerID", "ExtCustID", project.CustomerID)
            Return View(project)
        End Function


        ' GET: /Projects/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim project As Project = db.Projects.Find(id)
            If IsNothing(project) Then
                Return HttpNotFound()
            End If
            ViewBag.CustomerID = New SelectList(db.Customers, "CustomerID", "ExtCustID", project.CustomerID)
            ViewData("Customers") = db.Customers.Where(Function(c) c.CustomerID = project.CustomerID).[Select](Function(c) New SelectListItem With
            {
            .Text = c.CustName,
            .Value = c.CustomerID
            })
            ViewData("Projects") = db.ProjectTerminologies.[Select](Function(p) New SelectListItem With
            {
                .Text = p.ProjectTerminologyName,
                .Value = p.ProjectTerminologyName
            })
            Return View(project)
        End Function

        ' POST: /Projects/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include := "ProjectID,ProjectName,CustomerID")> ByVal project As Project) As ActionResult
            If ModelState.IsValid Then
                Dim proj = db.Projects.Where(Function(p) p.CustomerID = project.CustomerID And p.ProjectName = project.ProjectName).FirstOrDefault
                If proj IsNot Nothing Then
                    Return RedirectToAction("Edit", "Projects", New With {.id = project.ProjectID})
                End If
                db.Entry(project).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.CustomerID = New SelectList(db.Customers, "CustomerID", "ExtCustID", project.CustomerID)
            Return View(project)
        End Function

        ' GET: /Projects/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim project As Project = db.Projects.Find(id)
            Dim customer = db.Customers.Where(Function(c) c.CustomerID = project.CustomerID).First
            ViewBag.CustomerName = customer.CustName
            If IsNothing(project) Then
                Return HttpNotFound()
            End If
            Return View(project)
        End Function

        ' POST: /Projects/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim project As Project = db.Projects.Find(id)
            db.Projects.Remove(project)
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
