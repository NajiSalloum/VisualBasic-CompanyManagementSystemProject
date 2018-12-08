Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Imports Microsoft.AspNet.Identity
Namespace BitLogTimeProject
    Public Class SubscriptionsController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: /Subscriptions/
        Function Index() As ActionResult
            Dim subscriptions = db.Subscriptions.Include(Function(s) s.Customer).Include(Function(s) s.PeriodType).Include(Function(s) s.Project)
            Return View(subscriptions.ToList())
        End Function

        ' GET: /Subscriptions/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim subscription As Subscription = db.Subscriptions.Find(id)
            If IsNothing(subscription) Then
                Return HttpNotFound()
            End If
            Return View(subscription)
        End Function

        ' GET: /Subscriptions/Create
        Function Create(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim customer As Customer = db.Customers.Find(id)
            ViewBag.CustomerID = New SelectList(db.Customers, "CustomerID", "ExtCustID")
            ViewBag.ProjectID = New SelectList(db.Projects, "ProjectID", "ProjectName")
            ViewBag.PeriodTypeID = New SelectList(db.Projects, "PeriodTypeID", "PeriodTypeName")

            ViewData("Customers") = db.Customers.Where(Function(c) c.CustomerID = id).[Select](Function(c) New SelectListItem With
            {
                .Text = c.CustName,
                .Value = c.CustomerID
            })

            ViewData("Projects") = db.Projects.Where(Function(c) c.CustomerID = id).[Select](Function(c) New SelectListItem With
            {
                .Text = c.ProjectName,
                .Value = c.ProjectID
            })
            ViewData("PeriodTypes") = New SelectList(db.PeriodTypes, "PeriodTypeID", "PeriodTypeName")

            Dim modelSubscription As New Subscription() With {
                .Customer = customer,
                .CustomerID = customer.CustomerID,
                .AutoDeb = False,
                .LockedToUser = True,
                .Commission = 0,
                .NoOfHours = 1,
                .PricePerHour = 0,
                .StartDate = Date.Now.ToLocalTime
            }

            Dim model As New AddAndAllSubscriptionsView()
            model.Subscription = modelSubscription
            Dim subscriptionsList As New List(Of AllSubscriptionsView)
            Dim subscriptions = Nothing
            subscriptions = db.Subscriptions.Where(Function(c) c.CustomerID = id And c.Debiterad = False).ToList()



            For Each subscription As Subscription In subscriptions
                Dim project = (From c In db.Projects
                                  Where c.ProjectID = subscription.ProjectID
                                  Select c).FirstOrDefault

                Dim cust = (From c In db.Customers
                                 Where c.CustomerID = subscription.CustomerID
                                 Select c).FirstOrDefault

                Dim period = (From c In db.PeriodTypes
                                                 Where c.PeriodTypeID = subscription.PeriodTypeID
                                                 Select c).FirstOrDefault

                subscriptionsList.Add(New AllSubscriptionsView() With
                              {.AutoDeb = subscription.AutoDeb,
                               .Commission = subscription.Commission,
                               .Customer = cust,
                               .CustomerID = cust.CustomerID,
                               .Description = subscription.Description,
                               .LastInvoiced = subscription.LastInvoiced,
                               .LockedToUser = subscription.LockedToUser,
                               .NoOfHours = subscription.NoOfHours,
                               .PeriodType = period,
                               .PeriodTypeID = period.PeriodTypeID,
                               .PricePerHour = subscription.PricePerHour,
                               .Project = project,
                               .ProjectID = project.ProjectID,
                               .RegisteredDate = subscription.RegisteredDate,
                               .StartDate = subscription.StartDate,
                               .SubscriptionID = subscription.SubscriptionID,
                               .UserName = subscription.UserName
                               })
            Next

            model.AllSubscriptions = subscriptionsList
            Return View(model)
        End Function

        ' POST: /Subscriptions/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="SubscriptionID,ProjectID,CustomerID,PeriodTypeID,UserName,NoOfHours,PricePerHour,RegisteredDate,Description,LastInvoiced,LockedToUser,StartDate,AutoDeb,Commission")> ByVal subscription As Subscription) As ActionResult
            If ModelState.IsValid Then
                subscription.UserName = User.Identity.GetUserName
                subscription.RegisteredDate = Date.Now
                subscription.LastInvoiced = Nothing
                If subscription.PeriodTypeID = 1 Then
                    subscription.LastInvoiced = subscription.StartDate.Value.AddMonths(1)
                ElseIf subscription.PeriodTypeID = 2 Then
                    subscription.LastInvoiced = subscription.StartDate.Value.AddMonths(2)
                ElseIf subscription.PeriodTypeID = 3 Then
                    subscription.LastInvoiced = subscription.StartDate.Value.AddMonths(4)
                ElseIf subscription.PeriodTypeID = 4 Then
                    subscription.LastInvoiced = subscription.StartDate.Value.AddMonths(6)
                ElseIf subscription.PeriodTypeID = 5 Then
                    subscription.LastInvoiced = subscription.StartDate.Value.AddYears(1)
                ElseIf subscription.PeriodTypeID = 6 Then
                    subscription.LastInvoiced = subscription.StartDate.Value.AddDays(1)
                ElseIf subscription.PeriodTypeID = 7 Then
                    subscription.LastInvoiced = Date.Now.AddDays(7)
                ElseIf subscription.PeriodTypeID = 8 Then
                    subscription.LastInvoiced = Date.Now.AddDays(14)
                Else
                    subscription.LastInvoiced = Nothing

                End If


                db.Subscriptions.Add(subscription)
                db.SaveChanges()
                Return RedirectToAction("Create")
            End If
            ViewBag.CustomerID = New SelectList(db.Customers, "CustomerID", "ExtCustID", subscription.CustomerID)
            ViewBag.PeriodTypeID = New SelectList(db.PeriodTypes, "ID", "PeriodTypeName", subscription.PeriodTypeID)
            ViewBag.ProjectID = New SelectList(db.Projects, "ProjectID", "ProjectName", subscription.ProjectID)
            Return View(subscription)
        End Function

        ' GET: /Subscriptions/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim subscription As Subscription = db.Subscriptions.Find(id)
            If IsNothing(subscription) Then
                Return HttpNotFound()
            End If
            ViewData("Customers") = db.Customers.Where(Function(c) c.CustomerID = subscription.CustomerID).[Select](Function(c) New SelectListItem With
                {
                .Text = c.CustName,
                .Value = c.CustomerID
                })

            ViewData("Projects") = db.Projects.Where(Function(c) c.ProjectID = subscription.ProjectID).[Select](Function(c) New SelectListItem With
                {
                .Text = c.ProjectName,
                .Value = c.ProjectID
                })
            ViewData("PeriodTypes") = New SelectList(db.PeriodTypes, "PeriodTypeID", "PeriodTypeName")

            ViewBag.CustomerID = New SelectList(db.Customers, "CustomerID", "ExtCustID", subscription.CustomerID)
            ViewBag.PeriodTypeID = New SelectList(db.PeriodTypes, "ID", "PeriodTypeName", subscription.PeriodTypeID)
            ViewBag.ProjectID = New SelectList(db.Projects, "ProjectID", "ProjectName", subscription.ProjectID)
            Return View(subscription)
        End Function

        ' POST: /Subscriptions/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="SubscriptionID,ProjectID,CustomerID,PeriodTypeID,UserName,NoOfHours,PricePerHour,RegisteredDate,Description,LastInvoiced,LockedToUser,StartDate,AutoDeb,Commission")> ByVal subscription As Subscription) As ActionResult
            If ModelState.IsValid Then
                db.Entry(subscription).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("AllCustomers", "Customers")
            End If
            ViewBag.CustomerID = New SelectList(db.Customers, "CustomerID", "ExtCustID", subscription.CustomerID)
            ViewBag.PeriodTypeID = New SelectList(db.PeriodTypes, "ID", "PeriodTypeName", subscription.PeriodTypeID)
            ViewBag.ProjectID = New SelectList(db.Projects, "ProjectID", "ProjectName", subscription.ProjectID)
            Return View(subscription)
        End Function

        ' GET: /Subscriptions/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim subscription As Subscription = db.Subscriptions.Find(id)
            Dim customer = db.Customers.Where(Function(c) c.CustomerID = subscription.CustomerID).FirstOrDefault
            Dim project = db.Projects.Where(Function(c) c.ProjectID = subscription.ProjectID).FirstOrDefault
            Dim period = db.PeriodTypes.Where(Function(c) c.PeriodTypeID = subscription.PeriodTypeID).FirstOrDefault
            subscription.Customer = customer
            subscription.Project = project
            subscription.PeriodType = period
            If IsNothing(subscription) Then
                Return HttpNotFound()
            End If
            Return View(subscription)
        End Function

        ' POST: /Subscriptions/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim subscription As Subscription = db.Subscriptions.Find(id)
            db.Subscriptions.Remove(subscription)
            db.SaveChanges()
            Return RedirectToAction("AllSubsicriptions")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub


        'GET: Subscriptions/AllCustomers
        Function AllCustomers(ByVal SearchName As String) As ActionResult
            Dim customersList As New List(Of AllCustomersView)
            Dim customers = Nothing
            If SearchName Is Nothing Then
                customers = db.Customers.Where(Function(c) c.Deleted = False).ToList()
            Else
                customers = (From u In db.Customers
                         Where u.Deleted = False And u.CustName.Contains(SearchName)
                         ).ToList()
            End If



            For Each customer As Customer In customers
                Dim company = (From c In db.Companies
                                  Where c.CompanyID = customer.CompanyID
                                  Select c).First

                Dim priceList = (From c In db.PriiceLists
                                 Where c.PriceListID = customer.PriceListID
                                 Select c).First

                customersList.Add(New AllCustomersView() With
                              {.CustID = customer.CustomerID,
                                .CustName = customer.CustName,
                               .CustRef = customer.CustRef,
                               .PriceList = priceList,
                               .PartnerLevel = customer.PartnerLevel,
                               .IinternalCustomer = customer.InternalCustomer})
            Next
            Return View(customersList)
        End Function
        'GET: Subscriptions/AllSubsicriptions
        Function AllSubsicriptions() As ActionResult
            Dim subscriptionsList As New List(Of AllSubscriptionsView)
            Dim subscriptions = Nothing
            subscriptions = db.Subscriptions.Where(Function(s) s.Debiterad = False).ToList()



            For Each subscription As Subscription In subscriptions
                Dim project = (From c In db.Projects
                                  Where c.ProjectID = subscription.ProjectID
                                  Select c).FirstOrDefault

                Dim customer = (From c In db.Customers
                                 Where c.CustomerID = subscription.CustomerID
                                 Select c).FirstOrDefault

                Dim period = (From c In db.PeriodTypes
                                                 Where c.PeriodTypeID = subscription.PeriodTypeID
                                                 Select c).FirstOrDefault
                If subscription.LastInvoiced Is Nothing Then
                    subscriptionsList.Add(New AllSubscriptionsView() With
                              {.AutoDeb = subscription.AutoDeb,
                               .Commission = subscription.Commission,
                               .Customer = customer,
                               .CustomerID = customer.CustomerID,
                               .Description = subscription.Description,
                               .LastInvoiced = "1900/01/01",
                               .LockedToUser = subscription.LockedToUser,
                               .NoOfHours = subscription.NoOfHours,
                               .PeriodType = period,
                               .PeriodTypeID = period.PeriodTypeID,
                               .PricePerHour = subscription.PricePerHour,
                               .Project = project,
                               .ProjectID = project.ProjectID,
                               .RegisteredDate = subscription.RegisteredDate,
                               .StartDate = subscription.StartDate,
                               .SubscriptionID = subscription.SubscriptionID,
                               .UserName = subscription.UserName})
                Else
                    subscriptionsList.Add(New AllSubscriptionsView() With
                              {.AutoDeb = subscription.AutoDeb,
                               .Commission = subscription.Commission,
                               .Customer = customer,
                               .CustomerID = customer.CustomerID,
                               .Description = subscription.Description,
                               .LastInvoiced = subscription.LastInvoiced,
                               .LockedToUser = subscription.LockedToUser,
                               .NoOfHours = subscription.NoOfHours,
                               .PeriodType = period,
                               .PeriodTypeID = period.PeriodTypeID,
                               .PricePerHour = subscription.PricePerHour,
                               .Project = project,
                               .ProjectID = project.ProjectID,
                               .RegisteredDate = subscription.RegisteredDate,
                               .StartDate = subscription.StartDate,
                               .SubscriptionID = subscription.SubscriptionID,
                               .UserName = subscription.UserName})

                End If

            Next
            Return View(subscriptionsList)
        End Function
        'GET: Subscriptions/AllSubsicriptionsInDebitLines
        Function AllSubsicriptionsInDebitLines() As ActionResult
            Dim subscriptionsList As New List(Of AllSubscriptionsInDebitLinesView)
            Dim subscriptions = Nothing
            subscriptions = db.Subscriptions.ToList()



            For Each subscription As Subscription In subscriptions
                Dim project = (From c In db.Projects
                                  Where c.ProjectID = subscription.ProjectID
                                  Select c).FirstOrDefault

                Dim customer = (From c In db.Customers
                                 Where c.CustomerID = subscription.CustomerID
                                 Select c).FirstOrDefault


                subscriptionsList.Add(New AllSubscriptionsInDebitLinesView() With
                          {.AutoDeb = subscription.AutoDeb,
                           .Commission = subscription.Commission,
                           .Customer = customer,
                           .CustomerID = customer.CustomerID,
                           .Description = subscription.Description,
                           .LockedToUser = subscription.LockedToUser,
                           .NoOfHours = subscription.NoOfHours,
                           .PricePerHour = subscription.PricePerHour,
                           .Project = project,
                           .ProjectID = project.ProjectID,
                           .StartDate = subscription.StartDate,
                           .SubscriptionID = subscription.SubscriptionID,
                           .SubscriptionName = project.ProjectName.ToUpper
                          })

            Next
            Return View(subscriptionsList)
        End Function

        'url: Subsicription/DebiteraASubsicription
        Function DebiteraASubsicription(ByVal Text As Integer, ByVal status As Boolean) As JsonResult
            Dim subsic = db.Subscriptions.Where(Function(s) s.SubscriptionID = Text).FirstOrDefault
            If status = True Then
                Dim sumNoOfHours As Decimal = subsic.NoOfHours
                Dim debitliness = db.DebitLines.Where(Function(d) d.Subscription = subsic.SubscriptionID).ToList()
                For Each item As DebitLine In debitliness
                    sumNoOfHours = sumNoOfHours - item.NoOfHours
                Next
                subsic.Debiterad = True

                Dim customer As Customer = db.Customers.Find(subsic.CustomerID)

                'Dim debit As New DebitLine() With {
                '    .Comission = subsic.Commission,
                '    .CompanyCar = False,
                '    .Customer = customer,
                '    .CustomerID = customer.CustomerID,
                '    .DebDate = Date.Now,
                '    .Description = subsic.Description,
                '    .Invoiced = #8/13/2008#,
                '    .NoOfHours = sumNoOfHours,
                '    .TravelPrice = customer.TravelPrice,
                '    .NoOfKm = customer.NoOfKm,
                '    .NoOfTravelHours = customer.NoOfTravelHour,
                '    .OtherExpences = 0,
                '    .PricePerHoure = subsic.PricePerHour,
                '    .PricePerKm = customer.PricePerKm,
                '    .Project = subsic.Project,
                '    .ProjectID = subsic.ProjectID,
                '    .Regesterad = Date.Now,
                '    .Status = 2,
                '    .Subscription = subsic.SubscriptionID,
                '    .UserName = subsic.UserName}

                Dim debit As New DebitLine() With {
                .Comission = subsic.Commission,
                    .CompanyCar = False,
                    .Customer = customer,
                    .CustomerID = customer.CustomerID,
                    .DebDate = Date.Now,
                    .Description = subsic.Description + ".",
                    .Invoiced = #8/13/2008#,
                    .NoOfHours = sumNoOfHours,
                    .TravelPrice = customer.TravelPrice,
                    .NoOfKm = customer.NoOfKm,
                    .NoOfTravelHours = customer.NoOfTravelHour,
                    .OtherExpences = 0,
                    .PricePerHoure = subsic.PricePerHour,
                    .PricePerKm = customer.PricePerKm,
                    .Project = subsic.Project,
                    .ProjectID = subsic.ProjectID,
                    .Regesterad = Date.Now,
                    .Status = 2,
                    .Subscription = subsic.SubscriptionID,
                .UserName = subsic.UserName}
                db.DebitLines.Add(debit)
                db.SaveChanges()

                Dim debitline = db.DebitLines.Where(Function(d) d.Subscription = Text).FirstOrDefault
                Dim debitlinesview As New DebitLinesView() With {
                .UserName = subsic.UserName,
                .Invoiced = #8/13/2002#,
                .Regesterad = Date.Now,
                .PricePerHoure = subsic.PricePerHour,
                .PricePerKm = customer.PricePerKm,
                .Status = 2,
                .Subscription = subsic.SubscriptionID,
                .TravelPrice = customer.TravelPrice,
                .NoOfTravelHours = customer.NoOfTravelHour,
                .NoOfKm = customer.NoOfKm,
                .Comission = subsic.Commission,
                .CompanyCar = debitline.CompanyCar,
                .CustomerID = customer.CustomerID,
                .DebDate = debitline.DebDate,
                .Description = debitline.Description,
                .NoOfHours = sumNoOfHours,
                .OtherExpences = debitline.OtherExpences,
                .ProjectID = subsic.ProjectID,
                .LineTotal = (subsic.NoOfHours * subsic.PricePerHour + customer.NoOfTravelHour * customer.TravelPrice) + customer.NoOfKm * customer.PricePerKm + debitline.OtherExpences,
                .ComissionBased = subsic.NoOfHours * subsic.PricePerHour + customer.NoOfTravelHour * customer.TravelPrice,
                .KmAndOther = customer.PricePerKm + debitline.OtherExpences,
                .Year = debitline.DebDate.Year.ToString(),
                .Month = debitline.DebDate.Month.ToString(),
                .DebLineID = debit.LineID}

                db.DebtitLinesViews.Add(debitlinesview)
                db.SaveChanges()

            Else
                Dim debit = db.DebitLines.Where(Function(d) d.Subscription = Text).FirstOrDefault
                db.DebitLines.Remove(debit)
                db.SaveChanges()

                Dim debitview = db.DebtitLinesViews.Where(Function(d) d.Subscription = Text).FirstOrDefault
                db.DebtitLinesViews.Remove(debitview)
                db.SaveChanges()
                subsic.Debiterad = False


            End If


            db.Entry(subsic).State = EntityState.Modified
            db.SaveChanges()

            Return Nothing

        End Function
        'GET: Subscriptions/AllSubsicriptionsWithDebitLinesOverview
        Function AllSubsicriptionsWithDebitLinesOverview() As ActionResult
            UpadateSub()
            Dim subscriptionsList As New List(Of AllSubscriptionsView)
            Dim subscriptions = Nothing
            subscriptions = db.Subscriptions.Where(Function(s) s.Debiterad = False).ToList()



            For Each subscription As Subscription In subscriptions
                Dim project = (From c In db.Projects
                                  Where c.ProjectID = subscription.ProjectID
                                  Select c).FirstOrDefault

                Dim customer = (From c In db.Customers
                                 Where c.CustomerID = subscription.CustomerID
                                 Select c).FirstOrDefault

                Dim period = (From c In db.PeriodTypes
                                                 Where c.PeriodTypeID = subscription.PeriodTypeID
                                                 Select c).FirstOrDefault
                If subscription.LastInvoiced Is Nothing Then
                    subscriptionsList.Add(New AllSubscriptionsView() With
                              {.AutoDeb = subscription.AutoDeb,
                               .Commission = subscription.Commission,
                               .Customer = customer,
                               .CustomerID = customer.CustomerID,
                               .Description = subscription.Description,
                               .LastInvoiced = "1900/01/01",
                               .LockedToUser = subscription.LockedToUser,
                               .NoOfHours = subscription.NoOfHours,
                               .PeriodType = period,
                               .PeriodTypeID = period.PeriodTypeID,
                               .PricePerHour = subscription.PricePerHour,
                               .Project = project,
                               .ProjectID = project.ProjectID,
                               .RegisteredDate = subscription.RegisteredDate,
                               .StartDate = subscription.StartDate,
                               .SubscriptionID = subscription.SubscriptionID,
                               .UserName = subscription.UserName})
                Else
                    Dim sumNoOfHours As Decimal = subscription.NoOfHours
                    Dim debitliness = db.DebitLines.Where(Function(d) d.Subscription = subscription.SubscriptionID).ToList()
                    For Each item As DebitLine In debitliness
                        sumNoOfHours = sumNoOfHours - item.NoOfHours
                    Next

                    subscriptionsList.Add(New AllSubscriptionsView() With
                              {.AutoDeb = subscription.AutoDeb,
                               .Commission = subscription.Commission,
                               .Customer = customer,
                               .CustomerID = customer.CustomerID,
                               .Description = subscription.Description,
                               .LastInvoiced = subscription.LastInvoiced,
                               .LockedToUser = subscription.LockedToUser,
                               .NoOfHours = sumNoOfHours,
                               .PeriodType = period,
                               .PeriodTypeID = period.PeriodTypeID,
                               .PricePerHour = subscription.PricePerHour,
                               .Project = project,
                               .ProjectID = project.ProjectID,
                               .RegisteredDate = subscription.RegisteredDate,
                               .StartDate = subscription.StartDate,
                               .SubscriptionID = subscription.SubscriptionID,
                               .UserName = subscription.UserName})

                End If

            Next
            Dim DebitLinesList As New List(Of DebitLinesOverview)
            Dim debitlines = Nothing
            Dim userName = User.Identity.GetUserName
            debitlines = (From d In db.DebtitLinesViews
                         Where d.UserName = userName And d.DebDate.Year = Date.Today.Year And d.DebDate.Month = Date.Today.Month And d.DebDate.Day = Date.Today.Day
                         ).ToList()


            Dim totalDebiterad As Decimal = 0

            For Each debitLine As DebitLinesView In debitlines
                totalDebiterad += debitLine.LineTotal
                Dim customer = (From c In db.Customers
                                  Where c.CustomerID = debitLine.CustomerID
                                  Select c).First

                Dim project = (From c In db.Projects
                                 Where c.ProjectID = debitLine.ProjectID
                                 Select c).First

                DebitLinesList.Add(New DebitLinesOverview() With
                              {.Comission = debitLine.Comission,
                               .Customer = customer,
                               .CustomerID = customer.CustomerID,
                               .DebDate = debitLine.DebDate,
                               .Description = debitLine.Description,
                               .LineID = debitLine.LineID,
                               .LineTotal = debitLine.LineTotal,
                               .NoOfHours = debitLine.NoOfHours,
                               .NoOfKm = debitLine.NoOfKm,
                               .NoOfTravelHours = debitLine.NoOfTravelHours,
                               .OtherExpences = debitLine.OtherExpences,
                               .PricePerHoure = debitLine.PricePerHoure,
                               .PricePerKm = debitLine.PricePerKm,
                               .Project = project,
                               .ProjectID = project.ProjectID,
                               .TravelPrice = debitLine.TravelPrice,
                               .DebLineID = debitLine.LineID,
                               .Total = 0
                               })
            Next

            ViewBag.theDate = Date.Now.Year.ToString + "/" + Date.Now.Month.ToString + "/" + Date.Now.Day.ToString
            ViewBag.totalDebiterat = totalDebiterad
            Dim model As New AllSubsicriptionsAndDebitLinesOverView()
            model.AllSubscriptions = subscriptionsList
            model.DebitLines = DebitLinesList
            Return View(model)
        End Function

        Public Sub UpadateSub()
            Dim subs = db.Subscriptions.ToList()
            For Each item As Subscription In subs
                If item.PeriodTypeID = 1 Then
                    If Date.Now > item.LastInvoiced Then
                        Dim s As New Subscription() With {.LastInvoiced = Date.Now.AddMonths(1), .Debiterad = False, .StartDate = Date.Now,
                                                          .CustomerID = item.CustomerID, .ProjectID = item.ProjectID, .PeriodTypeID = item.PeriodTypeID,
                                                          .AutoDeb = item.AutoDeb, .Commission = item.Commission, .Description = item.Description,
                                                          .RegisteredDate = item.RegisteredDate, .UserName = item.UserName, .LockedToUser = item.LockedToUser,
                                                          .NoOfHours = item.NoOfHours, .PricePerHour = item.PricePerHour}
                        db.Subscriptions.Add(s)
                        db.Subscriptions.Remove(item)
                        db.SaveChanges()
                    End If
                End If
                If item.PeriodTypeID = 2 Then
                    If Date.Now > item.LastInvoiced Then
                        Dim s As New Subscription() With {.LastInvoiced = Date.Now.AddMonths(2), .Debiterad = False, .StartDate = Date.Now,
                                                          .CustomerID = item.CustomerID, .ProjectID = item.ProjectID, .PeriodTypeID = item.PeriodTypeID,
                                                          .AutoDeb = item.AutoDeb, .Commission = item.Commission, .Description = item.Description,
                                                          .RegisteredDate = item.RegisteredDate, .UserName = item.UserName, .LockedToUser = item.LockedToUser,
                                                          .NoOfHours = item.NoOfHours, .PricePerHour = item.PricePerHour}
                        db.Subscriptions.Add(s)
                        db.Subscriptions.Remove(item)
                        db.SaveChanges()
                    End If
                End If
                If item.PeriodTypeID = 3 Then
                    If Date.Now > item.LastInvoiced Then
                        Dim s As New Subscription() With {.LastInvoiced = Date.Now.AddMonths(4), .Debiterad = False, .StartDate = Date.Now,
                                                          .CustomerID = item.CustomerID, .ProjectID = item.ProjectID, .PeriodTypeID = item.PeriodTypeID,
                                                          .AutoDeb = item.AutoDeb, .Commission = item.Commission, .Description = item.Description,
                                                          .RegisteredDate = item.RegisteredDate, .UserName = item.UserName, .LockedToUser = item.LockedToUser,
                                                          .NoOfHours = item.NoOfHours, .PricePerHour = item.PricePerHour}
                        db.Subscriptions.Add(s)
                        db.Subscriptions.Remove(item)
                        db.SaveChanges()
                    End If
                End If
                If item.PeriodTypeID = 4 Then
                    If Date.Now > item.LastInvoiced Then
                        Dim s As New Subscription() With {.LastInvoiced = Date.Now.AddMonths(6), .Debiterad = False, .StartDate = Date.Now,
                                                          .CustomerID = item.CustomerID, .ProjectID = item.ProjectID, .PeriodTypeID = item.PeriodTypeID,
                                                          .AutoDeb = item.AutoDeb, .Commission = item.Commission, .Description = item.Description,
                                                          .RegisteredDate = item.RegisteredDate, .UserName = item.UserName, .LockedToUser = item.LockedToUser,
                                                          .NoOfHours = item.NoOfHours, .PricePerHour = item.PricePerHour}
                        db.Subscriptions.Add(s)
                        db.Subscriptions.Remove(item)
                        db.SaveChanges()
                    End If
                End If
                If item.PeriodTypeID = 5 Then
                    If Date.Now > item.LastInvoiced Then
                        Dim s As New Subscription() With {.LastInvoiced = Date.Now.AddYears(1), .Debiterad = False, .StartDate = Date.Now,
                                                          .CustomerID = item.CustomerID, .ProjectID = item.ProjectID, .PeriodTypeID = item.PeriodTypeID,
                                                          .AutoDeb = item.AutoDeb, .Commission = item.Commission, .Description = item.Description,
                                                          .RegisteredDate = item.RegisteredDate, .UserName = item.UserName, .LockedToUser = item.LockedToUser,
                                                          .NoOfHours = item.NoOfHours, .PricePerHour = item.PricePerHour}
                        db.Subscriptions.Add(s)
                        db.Subscriptions.Remove(item)
                        db.SaveChanges()
                    End If
                End If
                If item.PeriodTypeID = 6 Then
                    If Date.Now > item.LastInvoiced Then
                        Dim s As New Subscription() With {.LastInvoiced = Date.Now.AddDays(1), .Debiterad = False, .StartDate = Date.Now,
                                                          .CustomerID = item.CustomerID, .ProjectID = item.ProjectID, .PeriodTypeID = item.PeriodTypeID,
                                                          .AutoDeb = item.AutoDeb, .Commission = item.Commission, .Description = item.Description,
                                                          .RegisteredDate = item.RegisteredDate, .UserName = item.UserName, .LockedToUser = item.LockedToUser,
                                                          .NoOfHours = item.NoOfHours, .PricePerHour = item.PricePerHour}
                        db.Subscriptions.Add(s)
                        db.Subscriptions.Remove(item)
                        db.SaveChanges()
                    End If
                End If
                If item.PeriodTypeID = 7 Then
                    If Date.Now > item.LastInvoiced Then
                        Dim s As New Subscription() With {.LastInvoiced = Date.Now.AddDays(7), .Debiterad = False, .StartDate = Date.Now,
                                                          .CustomerID = item.CustomerID, .ProjectID = item.ProjectID, .PeriodTypeID = item.PeriodTypeID,
                                                          .AutoDeb = item.AutoDeb, .Commission = item.Commission, .Description = item.Description,
                                                          .RegisteredDate = item.RegisteredDate, .UserName = item.UserName, .LockedToUser = item.LockedToUser,
                                                          .NoOfHours = item.NoOfHours, .PricePerHour = item.PricePerHour}
                        db.Subscriptions.Add(s)
                        db.Subscriptions.Remove(item)
                        db.SaveChanges()
                    End If
                End If

            Next

        End Sub


    End Class



End Namespace
