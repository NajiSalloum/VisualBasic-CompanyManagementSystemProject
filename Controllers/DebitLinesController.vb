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
    Public Class DebitLinesController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: /DebitLines/
        Function Index() As ActionResult
            Dim debitlines = db.DebitLines.Include(Function(d) d.Customer).Include(Function(d) d.Project)
            Return View(debitlines.ToList())
        End Function

        ' GET: /DebitLines/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim debitline As DebitLine = db.DebitLines.Find(id)
            If IsNothing(debitline) Then
                Return HttpNotFound()
            End If
            Return View(debitline)
        End Function

        '' GET: /DebitLines/Create
        'Function Create() As ActionResult
        '    ViewBag.CustomerID = New SelectList(db.Customers, "CustomerID", "ExtCustID")
        '    ViewBag.ProjectID = New SelectList(db.Projects, "ProjectID", "ProjectName")
        '    Return View()
        'End Function

        ' GET: /DebitLines/Create
        Function Create(ByVal id As Integer?, ByVal idSub As Integer?) As ActionResult


            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            Dim customer As Customer = db.Customers.Find(id)
            ViewBag.CustomerID = New SelectList(db.Customers, "CustomerID", "ExtCustID")
            ViewBag.ProjectID = New SelectList(db.Projects, "ProjectID", "ProjectName")

            ViewData("Customers") = db.Customers.Where(Function(c) c.CustomerID = id).[Select](Function(c) New SelectListItem With
            {
                .Text = c.CustName,
                .Value = c.CustomerID
            })


            ViewBag.NoOfTravelHour = customer.NoOfTravelHour
            ViewBag.NoOfKm = customer.NoOfKm
            Dim model As New CreateAndAllSubscriptionInDebitLinesView()

            If idSub IsNot Nothing Then
                Dim subsic As Subscription = db.Subscriptions.Find(idSub)
                Dim s = db.DebitLines.Where(Function(c) c.Subscription = subsic.SubscriptionID And c.CustomerID = subsic.CustomerID).FirstOrDefault
                Dim sumNoOfHours As Decimal = 0
                If s IsNot Nothing Then
                    sumNoOfHours = (From d In db.DebitLines
                                             Where d.Subscription = subsic.SubscriptionID And d.CustomerID = subsic.CustomerID
                                             Select d.NoOfHours).Sum

                End If
                Dim modelDebitLine As New DebitLine() With {
               .DebDate = Date.Now,
               .NoOfTravelHours = customer.NoOfTravelHour,
               .NoOfKm = customer.NoOfKm,
               .Comission = subsic.Commission,
               .CompanyCar = False,
               .OtherExpences = 0,
               .NoOfHours = subsic.NoOfHours - sumNoOfHours,
               .Description = subsic.Description,
               .Status = 2,
               .Subscription = subsic.SubscriptionID
               }
                model.DebitLine = modelDebitLine
                ViewData("Projects") = db.Projects.Where(Function(c) c.ProjectID = subsic.ProjectID).[Select](Function(c) New SelectListItem With
                 {
                    .Text = c.ProjectName,
                    .Value = c.ProjectID
                })


            Else
                Dim modelDebitLine As New DebitLine() With {
                .DebDate = Date.Now,
                .NoOfTravelHours = customer.NoOfTravelHour,
                .NoOfKm = customer.NoOfKm,
                .Comission = 0,
                .CompanyCar = False,
                .OtherExpences = 0,
                .NoOfHours = 0,
                .Status = 3
                }
                model.DebitLine = modelDebitLine
                ViewData("Projects") = db.Projects.Where(Function(c) c.CustomerID = id).[Select](Function(c) New SelectListItem With
                  {
                .Text = c.ProjectName,
                .Value = c.ProjectID
                  })
            End If


            Dim subscriptionsList As New List(Of AllSubscriptionsInDebitLinesView)

            Dim subscriptions = db.Subscriptions.Where(Function(s) s.CustomerID = id).ToList()



            For Each subscription As Subscription In subscriptions
                Dim project = (From c In db.Projects
                                  Where c.ProjectID = subscription.ProjectID
                                  Select c).FirstOrDefault

                Dim cust = (From c In db.Customers
                                 Where c.CustomerID = subscription.CustomerID
                                 Select c).FirstOrDefault



                Dim s = db.DebitLines.Where(Function(c) c.Subscription = subscription.SubscriptionID And c.CustomerID = subscription.CustomerID).FirstOrDefault
                

                Dim sumNoOfHours As Decimal = 0
                If s IsNot Nothing Then
                    sumNoOfHours = (From d In db.DebitLines
                                             Where d.Subscription = subscription.SubscriptionID And d.CustomerID = subscription.CustomerID
                                             Select d.NoOfHours).Sum

                End If
                If sumNoOfHours = subscription.NoOfHours Then
                    Continue For

                End If


                subscriptionsList.Add(New AllSubscriptionsInDebitLinesView() With
                          {.AutoDeb = subscription.AutoDeb,
                           .Commission = subscription.Commission,
                           .Customer = cust,
                           .CustomerID = cust.CustomerID,
                           .Description = subscription.Description,
                           .LockedToUser = subscription.LockedToUser,
                           .NoOfHours = subscription.NoOfHours,
                           .PricePerHour = subscription.PricePerHour,
                           .Project = project,
                           .ProjectID = project.ProjectID,
                           .StartDate = subscription.StartDate,
                           .SubscriptionID = subscription.SubscriptionID,
                           .SubscriptionName = project.ProjectName.ToUpper(),
                           .Debiterad = sumNoOfHours
                          })

            Next
            model.AllSubscriptionsInDebitLine = subscriptionsList
            Return View(model)
        End Function

        ' POST: /DebitLines/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="LineID,DebDate,UserName,CustomerID,NoOfHours,OtherExpences,ProjectID,Description,Comission,CompanyCar,NoOfTravelHours,NoOfKm,Status,Subscription,PricePerHoure")> ByVal debitline As DebitLine) As ActionResult
            If ModelState.IsValid Then
                Dim userName As String = User.Identity.GetUserName
                Dim customer As Customer = db.Customers.Find(debitline.CustomerID)
                debitline.UserName = userName
                debitline.Invoiced = #8/13/2002#
                debitline.Regesterad = Date.Now
                If debitline.Status = 2 Then

                    Dim subsic As Subscription = db.Subscriptions.Find(debitline.Subscription)
                    debitline.PricePerHoure = subsic.PricePerHour
                    debitline.Subscription = debitline.Subscription
                Else
                    debitline.PricePerHoure = customer.PricePerHour
                    debitline.Subscription = 0

                End If


                debitline.PricePerKm = customer.PricePerKm
                debitline.Status = debitline.Status

                debitline.TravelPrice = customer.TravelPrice
                debitline.NoOfTravelHours = debitline.NoOfTravelHours
                debitline.NoOfKm = debitline.NoOfKm
                db.DebitLines.Add(debitline)
                db.SaveChanges()


                If debitline.Status = 2 Then
                    Dim subsic As Subscription = db.Subscriptions.Find(debitline.Subscription)
                    Dim debitLinesView As New DebitLinesView() With {
                    .UserName = userName,
                    .Invoiced = #8/13/2002#,
                    .Regesterad = Date.Now,
                    .PricePerHoure = subsic.PricePerHour,
                    .PricePerKm = customer.PricePerKm,
                    .Status = 2,
                    .Subscription = debitline.Subscription,
                    .TravelPrice = customer.TravelPrice,
                    .NoOfTravelHours = debitline.NoOfTravelHours,
                    .NoOfKm = debitline.NoOfKm,
                    .Comission = debitline.Comission,
                    .CompanyCar = debitline.CompanyCar,
                    .CustomerID = debitline.CustomerID,
                    .DebDate = debitline.DebDate,
                    .Description = debitline.Description,
                    .NoOfHours = debitline.NoOfHours,
                    .OtherExpences = debitline.OtherExpences,
                    .ProjectID = debitline.ProjectID,
                    .LineTotal = (debitline.NoOfHours * subsic.PricePerHour + customer.NoOfTravelHour * customer.TravelPrice) + customer.NoOfKm * customer.PricePerKm + debitline.OtherExpences,
                    .ComissionBased = debitline.NoOfHours * subsic.PricePerHour + customer.NoOfTravelHour * customer.TravelPrice,
                    .KmAndOther = customer.PricePerKm + debitline.OtherExpences,
                    .Year = debitline.DebDate.Year.ToString(),
                    .Month = debitline.DebDate.Month.ToString(),
                    .DebLineID = debitline.LineID}
                    db.DebtitLinesViews.Add(debitLinesView)
                    db.SaveChanges()

                Else
                    Dim debitLinesView As New DebitLinesView() With {
                    .UserName = userName,
                    .Invoiced = #8/13/2002#,
                    .Regesterad = Date.Now,
                    .PricePerHoure = customer.PricePerHour,
                    .PricePerKm = customer.PricePerKm,
                    .Status = 3,
                    .Subscription = 0,
                    .TravelPrice = customer.TravelPrice,
                    .NoOfTravelHours = debitline.NoOfTravelHours,
                    .NoOfKm = debitline.NoOfKm,
                    .Comission = debitline.Comission,
                    .CompanyCar = debitline.CompanyCar,
                    .CustomerID = debitline.CustomerID,
                    .DebDate = debitline.DebDate,
                    .Description = debitline.Description,
                    .NoOfHours = debitline.NoOfHours,
                    .OtherExpences = debitline.OtherExpences,
                    .ProjectID = debitline.ProjectID,
                    .LineTotal = (debitline.NoOfHours * customer.PricePerHour + customer.NoOfTravelHour * customer.TravelPrice) + customer.NoOfKm * customer.PricePerKm + debitline.OtherExpences,
                    .ComissionBased = debitline.NoOfHours * customer.PricePerHour + customer.NoOfTravelHour * customer.TravelPrice,
                    .KmAndOther = customer.PricePerKm + debitline.OtherExpences,
                    .Year = debitline.DebDate.Year.ToString(),
                    .Month = debitline.DebDate.Month.ToString(),
                    .DebLineID = debitline.LineID}
                    db.DebtitLinesViews.Add(debitLinesView)
                    db.SaveChanges()


                End If
                If debitline.Status = 2 Then
                    Dim sumNoOfHours As Decimal = 0
                    Dim debitliness = db.DebitLines.Where(Function(d) d.Subscription = debitline.Subscription).ToList()
                    For Each item As DebitLine In debitliness
                        sumNoOfHours = sumNoOfHours + item.NoOfHours
                    Next
                    Dim subsic As Subscription = db.Subscriptions.Find(debitline.Subscription)
                    
                    If sumNoOfHours = subsic.NoOfHours Then
                        subsic.Debiterad = True
                        db.Entry(subsic).State = EntityState.Modified
                        db.SaveChanges()
                    End If

                End If


                '  Public Property LineTotal() As Decimal? = (NoOfHours * PricePerHoure + NoOfTravelHours * TravelPrice) + NoOfKm * PricePerKm + OtherExpences
                ' Public Property ComissionBased() As Decimal? = NoOfHours * PricePerHoure + NoOfTravelHours * TravelPrice
                'Public Property KmAndOther() As Decimal? = PricePerKm + OtherExpences
                Return RedirectToAction("AllCustomers", "Customers")
            End If
            ViewBag.CustomerID = New SelectList(db.Customers, "CustomerID", "ExtCustID", debitline.CustomerID)
            ViewBag.ProjectID = New SelectList(db.Projects, "ProjectID", "ProjectName", debitline.ProjectID)
            
            Return View(debitline)
        End Function


        ' GET: /DebitLines/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim debitline As DebitLine = db.DebitLines.Find(id)
            If IsNothing(debitline) Then
                Return HttpNotFound()
            End If
            ViewBag.CustomerID = New SelectList(db.Customers, "CustomerID", "ExtCustID", debitline.CustomerID)
            ViewBag.ProjectID = New SelectList(db.Projects, "ProjectID", "ProjectName", debitline.ProjectID)
            Return View(debitline)
        End Function

        ' POST: /DebitLines/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="LineID,DebDate,UserName,CustomerID,NoOfHours,NoOfTravelHours,NoOfKm,OtherExpences,ProjectID,Description,Invoiced,Regesterad,PricePerHoure,TravelPrice,PricePerKm,Status,Comission,Subscription,CompanyCar")> ByVal debitline As DebitLine) As ActionResult
            If ModelState.IsValid Then
                db.Entry(debitline).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.CustomerID = New SelectList(db.Customers, "CustomerID", "ExtCustID", debitline.CustomerID)
            ViewBag.ProjectID = New SelectList(db.Projects, "ProjectID", "ProjectName", debitline.ProjectID)
            Return View(debitline)
        End Function

        ' GET: /DebitLines/Delete/5
        Function Delete(ByVal id As Integer?, ByVal fromLink As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim debitline = db.DebtitLinesViews.Find(id)
            Dim cus = db.Customers.Where(Function(c) c.CustomerID = debitline.CustomerID).FirstOrDefault
            Dim pro = db.Projects.Where(Function(p) p.ProjectID = debitline.ProjectID).FirstOrDefault

            ViewBag.SubsicriptionName = pro.ProjectName.ToUpper()
            debitline.Customer = cus
            debitline.Project = pro
            If IsNothing(debitline) Then
                Return HttpNotFound()
            End If
            Return View(debitline)
        End Function

        ' POST: /DebitLines/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer, ByVal fromLink As Integer?) As ActionResult
            Dim debitlineview = db.DebtitLinesViews.Find(id)
            Dim debitline = db.DebitLines.Where(Function(d) d.LineID = debitlineview.DebLineID).FirstOrDefault
            Dim subsic = db.Subscriptions.Where(Function(s) s.SubscriptionID = debitlineview.Subscription).FirstOrDefault
            If debitline.Status = 2 Then

                subsic.Debiterad = False
                db.Entry(subsic).State = EntityState.Modified
                End If



            db.DebtitLinesViews.Remove(debitlineview)
            db.DebitLines.Remove(debitline)

            db.SaveChanges()
            If fromLink = 1 Then
                Return RedirectToAction("AllSubsicriptionsWithDebitLinesOverview", "Subscriptions")
            End If
            'MsgBox(id)
                Return RedirectToAction("AllCustomers", "Customers")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub



        'GET: DebitLines/DebitLinesOverview
        Function DebitLinesOverview() As ActionResult
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
                               .Total = 0
                               })
            Next

            ViewBag.theDate = Date.Now.Year.ToString + "/" + Date.Now.Month.ToString + "/" + Date.Now.Day.ToString
            ViewBag.totalDebiterat = totalDebiterad
            Return View(DebitLinesList)
        End Function

        Function DebitLinePerMonth(ByVal year As String, ByVal month As String) As ActionResult
            Dim debitlines = db.DebtitLinesViews.Where(Function(d) d.Year = year And d.Month = month).GroupBy(Function(u) u.UserName).Select(Function(s) New DebitLinePerMonthView With {
                                                                                                                                                 .UserName = s.Key,
                                                                                                                                                 .Month = month,
                                                                                                                                                 .TotalPerMonth = s.Sum(Function(x) x.NoOfHours * x.PricePerHoure)})
            
            Return View(debitlines)
        End Function
        Public monthss As New List(Of SelectListItem)()
        Dim yearss As New List(Of SelectListItem)()
        Sub YearAndMonthDropdownList()

            monthss.Add(New SelectListItem() With {
                           .Text = "Januari",
                           .Value = "1"})
            monthss.Add(New SelectListItem() With {
                           .Text = "Februari",
                           .Value = "2"})
            monthss.Add(New SelectListItem() With {
                           .Text = "Mars",
                           .Value = "3"})
            monthss.Add(New SelectListItem() With {
                           .Text = "April",
                           .Value = "4"})
            monthss.Add(New SelectListItem() With {
                           .Text = "Maj",
                           .Value = "5"})
            monthss.Add(New SelectListItem() With {
                           .Text = "Juni",
                           .Value = "6"})
            monthss.Add(New SelectListItem() With {
                           .Text = "Juli",
                           .Value = "7"})
            monthss.Add(New SelectListItem() With {
                           .Text = "Augusti",
                           .Value = "8"})
            monthss.Add(New SelectListItem() With {
                           .Text = "September",
                           .Value = "9"})
            monthss.Add(New SelectListItem() With {
                           .Text = "Oktober",
                           .Value = "10"})
            monthss.Add(New SelectListItem() With {
                          .Text = "November",
                          .Value = "11"})
            monthss.Add(New SelectListItem() With {
                          .Text = "December",
                          .Value = "12"})



            yearss.Add(New SelectListItem() With {.Text = "2000", .Value = "2000"})
            yearss.Add(New SelectListItem() With {.Text = "2001", .Value = "2001"})
            yearss.Add(New SelectListItem() With {.Text = "2002", .Value = "2002"})
            yearss.Add(New SelectListItem() With {.Text = "2003", .Value = "2003"})
            yearss.Add(New SelectListItem() With {.Text = "2004", .Value = "2004"})
            yearss.Add(New SelectListItem() With {.Text = "2005", .Value = "2005"})
            yearss.Add(New SelectListItem() With {.Text = "2006", .Value = "2006"})
            yearss.Add(New SelectListItem() With {.Text = "2007", .Value = "2007"})
            yearss.Add(New SelectListItem() With {.Text = "2008", .Value = "2008"})
            yearss.Add(New SelectListItem() With {.Text = "2009", .Value = "2009"})
            yearss.Add(New SelectListItem() With {.Text = "2010", .Value = "2010"})
            yearss.Add(New SelectListItem() With {.Text = "2011", .Value = "2011"})
            yearss.Add(New SelectListItem() With {.Text = "2012", .Value = "2012"})
            yearss.Add(New SelectListItem() With {.Text = "2013", .Value = "2013"})
            yearss.Add(New SelectListItem() With {.Text = "2014", .Value = "2014"})
            yearss.Add(New SelectListItem() With {.Text = "2015", .Value = "2015"})
            yearss.Add(New SelectListItem() With {.Text = "2016", .Value = "2016"})
            yearss.Add(New SelectListItem() With {.Text = "2017", .Value = "2017"})
            yearss.Add(New SelectListItem() With {.Text = "2018", .Value = "2018"})
            yearss.Add(New SelectListItem() With {.Text = "2019", .Value = "2019"})
            yearss.Add(New SelectListItem() With {.Text = "2020", .Value = "2020"})
            yearss.Add(New SelectListItem() With {.Text = "2021", .Value = "2021"})
            yearss.Add(New SelectListItem() With {.Text = "2022", .Value = "2022"})
            yearss.Add(New SelectListItem() With {.Text = "2023", .Value = "2023"})
            yearss.Add(New SelectListItem() With {.Text = "2024", .Value = "2024"})
            yearss.Add(New SelectListItem() With {.Text = "2025", .Value = "2025"})
            yearss.Add(New SelectListItem() With {.Text = "2026", .Value = "2026"})
            yearss.Add(New SelectListItem() With {.Text = "2027", .Value = "2027"})
            yearss.Add(New SelectListItem() With {.Text = "2028", .Value = "2028"})
            yearss.Add(New SelectListItem() With {.Text = "2029", .Value = "2029"})
            yearss.Add(New SelectListItem() With {.Text = "2030", .Value = "2030"})
            yearss.Add(New SelectListItem() With {.Text = "2031", .Value = "2031"})
            yearss.Add(New SelectListItem() With {.Text = "2032", .Value = "2032"})
            yearss.Add(New SelectListItem() With {.Text = "2033", .Value = "2033"})
            yearss.Add(New SelectListItem() With {.Text = "2034", .Value = "2034"})
            yearss.Add(New SelectListItem() With {.Text = "2035", .Value = "2035"})
            yearss.Add(New SelectListItem() With {.Text = "2036", .Value = "2036"})
            yearss.Add(New SelectListItem() With {.Text = "2037", .Value = "2037"})
            yearss.Add(New SelectListItem() With {.Text = "2038", .Value = "2038"})
            yearss.Add(New SelectListItem() With {.Text = "2039", .Value = "2039"})
            yearss.Add(New SelectListItem() With {.Text = "2040", .Value = "2040"})
        End Sub
        Function DebitLinePerCustomer(Optional ByVal months As String = "", Optional ByVal years As String = "") As ActionResult
            
            GlobalVariables.years = years
            GlobalVariables.months = months
            YearAndMonthDropdownList()
            ViewBag.months = New SelectList(monthss, "Value", "Text", GlobalVariables.currentMonth)
            ViewBag.years = New SelectList(yearss, "Value", "Text", GlobalVariables.currentYear)

            'Dim customer = db.Customers.Where(Function(c) c.CustName = custName).FirstOrDefault
            Dim debitlines = db.DebtitLinesViews.Where(Function(d) d.Year = years And d.Month = months).GroupBy(Function(u) u.CustomerID).Select(Function(s) New DebitLinePerCustomerView With {
                                                                                                                                                 .CustName = db.Customers.Where(Function(c) c.CustomerID = s.Key).FirstOrDefault.CustName,
                                                                                                                                                 .CustomerID = s.Key,
                                                                                                                                                 .Month = months,
                                                                                                                                                 .Year = years,
                                                                                                                                                 .TotalDebiterat = s.Sum(Function(x) x.NoOfHours * x.PricePerHoure),
                                                                                                                                                 .TotalDebiteratAndTravilPrice = s.Sum(Function(x) x.LineTotal)})
            



            Return View(debitlines)
        End Function
        Function DebiteratInfoPerCustomerName(ByVal id As Integer?) As ActionResult
            YearAndMonthDropdownList()
            ViewBag.months = New SelectList(monthss, "Value", "Text", GlobalVariables.months)
            ViewBag.years = New SelectList(yearss, "Value", "Text", GlobalVariables.years)
            Dim debitlinesPerCustomers = db.DebtitLinesViews.Where(Function(d) d.Year = GlobalVariables.years And d.Month = GlobalVariables.months).GroupBy(Function(u) u.CustomerID).Select(Function(s) New DebitLinePerCustomerView With {
                                                                                                                                                  .CustName = db.Customers.Where(Function(c) c.CustomerID = s.Key).FirstOrDefault.CustName,
                                                                                                                                                  .CustomerID = s.Key,
                                                                                                                                                  .Month = GlobalVariables.months,
                                                                                                                                                  .Year = GlobalVariables.years,
                                                                                                                                                  .TotalDebiterat = s.Sum(Function(x) x.NoOfHours * x.PricePerHoure),
                                                                                                                                                  .TotalDebiteratAndTravilPrice = s.Sum(Function(x) x.LineTotal)}).ToList()

            Dim debitlines = db.DebtitLinesViews.Where(Function(d) d.CustomerID = id).OrderBy(Function(d) d.DebDate).ToList()
            Dim debitlineslist As New List(Of DebitLinesOverview)
            For Each deb As DebitLinesView In debitlines

                Dim debOver As New DebitLinesOverview
                debOver.Comission = deb.Comission
                debOver.DebDate = deb.DebDate.ToShortDateString
                debOver.Description = deb.Description
                debOver.LineTotal = deb.LineTotal
                debOver.NoOfHours = deb.NoOfHours
                deb.KmAndOther = deb.KmAndOther
                deb.NoOfHours = deb.NoOfHours
                debOver.NoOfKm = deb.NoOfKm
                debOver.NoOfTravelHours = deb.NoOfTravelHours
                debOver.OtherExpences = deb.OtherExpences
                debOver.PricePerHoure = deb.PricePerHoure
                debOver.PricePerKm = deb.PricePerKm
                debOver.TravelPrice = deb.TravelPrice
                Dim customer = db.Customers.Where(Function(c) c.CustomerID = deb.CustomerID).FirstOrDefault
                Dim project = db.Projects.Where(Function(p) p.ProjectID = deb.ProjectID).FirstOrDefault
                debOver.Project = project
                debOver.Customer = customer
                debOver.UserName = deb.UserName
                debitlineslist.Add(debOver)

            Next
            Dim model As New DebitLinesPerCustomersAndDebitLinesOverView
            model.DebitLinesPerCustomers = debitlinesPerCustomers
            model.DebitLines = debitlineslist
            Return View(model)
            Return Nothing
        End Function

        Function MyDebitering(Optional ByVal months As String = "", Optional ByVal years As String = "") As ActionResult
            YearAndMonthDropdownList()
            
            ViewBag.months = New SelectList(monthss, "Value", "Text", GlobalVariables.currentMonth)
            ViewBag.years = New SelectList(yearss, "Value", "Text", GlobalVariables.currentYear)
            Dim userName = User.Identity.GetUserName
            Dim debitlines = db.DebtitLinesViews.Where(Function(d) d.UserName = userName And d.Month = months And d.Year = years).OrderBy(Function(d) d.DebDate).ToList()
            Dim totalDebiterat As Decimal = 0
            Dim totalHours As Decimal = 0
            Dim debitlineslist As New List(Of DebitLinesOverview)
            For Each deb As DebitLinesView In debitlines

                Dim debOver As New DebitLinesOverview
                debOver.Comission = deb.Comission
                debOver.DebDate = deb.DebDate
                debOver.Description = deb.Description
                debOver.LineTotal = deb.LineTotal
                debOver.NoOfHours = deb.NoOfHours
                deb.KmAndOther = deb.KmAndOther
                deb.NoOfHours = deb.NoOfHours
                debOver.NoOfKm = deb.NoOfKm
                debOver.NoOfTravelHours = deb.NoOfTravelHours
                debOver.OtherExpences = deb.OtherExpences
                debOver.PricePerHoure = deb.PricePerHoure
                debOver.PricePerKm = deb.PricePerKm
                debOver.TravelPrice = deb.TravelPrice
                Dim customer = db.Customers.Where(Function(c) c.CustomerID = deb.CustomerID).FirstOrDefault
                Dim project = db.Projects.Where(Function(p) p.ProjectID = deb.ProjectID).FirstOrDefault
                debOver.Project = project
                debOver.Customer = customer
                debOver.UserName = deb.UserName
                totalDebiterat = totalDebiterat + deb.LineTotal
                totalHours = totalHours + deb.NoOfHours
                debitlineslist.Add(debOver)

            Next
            ViewBag.TotalDebiterat = totalDebiterat
            ViewBag.TotalHours = totalHours
            Return View(debitlineslist)
        End Function
        Function MyDebiteringPerCustomer(ByVal debbycust As MyDebiterungPerCustomerView) As ActionResult
            ViewData("Customers") = db.Customers.Where(Function(c) c.Deleted = False).[Select](Function(c) New SelectListItem With
                  {
                .Text = c.CustName,
                .Value = c.CustomerID
                  })
            Dim username = User.Identity.GetUserName
            Dim debitlines = db.DebtitLinesViews.Where(Function(d) d.CustomerID = debbycust.CustID And d.DebDate >= debbycust.FirstDate And d.DebDate <= debbycust.SecondDate And d.UserName = username).OrderBy(Function(d) d.DebDate).ToList()
            Dim totaldebiterat As Decimal = 0
            Dim totalhours As Decimal = 0
            Dim debitlineslist As New List(Of DebitLinesOverview)
            For Each deb As DebitLinesView In debitlines

                Dim debover As New DebitLinesOverview
                debover.Comission = deb.Comission
                debover.DebDate = deb.DebDate
                debover.Description = deb.Description
                debover.LineTotal = deb.LineTotal
                debover.NoOfHours = deb.NoOfHours
                deb.KmAndOther = deb.KmAndOther
                deb.NoOfHours = deb.NoOfHours
                debover.NoOfKm = deb.NoOfKm
                debover.NoOfTravelHours = deb.NoOfTravelHours
                debover.OtherExpences = deb.OtherExpences
                debover.PricePerHoure = deb.PricePerHoure
                debover.PricePerKm = deb.PricePerKm
                debover.TravelPrice = deb.TravelPrice
                Dim customer = db.Customers.Where(Function(c) c.CustomerID = deb.CustomerID).FirstOrDefault
                Dim project = db.Projects.Where(Function(p) p.ProjectID = deb.ProjectID).FirstOrDefault
                debover.Project = project
                debover.Customer = customer
                debover.UserName = deb.UserName
                totaldebiterat = totaldebiterat + deb.LineTotal
                totalhours = totalhours + deb.NoOfHours
                debitlineslist.Add(debover)

            Next
            ViewBag.totaldebiterat = totaldebiterat
            ViewBag.totalhours = totalhours
            Dim model As New MyDebiterungPerCustomerView
            model.DebitLines = debitlineslist
            model.FirstDate = Date.Now.AddMonths(-1)
            model.SecondDate = Date.Now
            Return View(model)
            Return Nothing
        End Function

        Function DebitLinePerUsers(Optional ByVal months As String = "", Optional ByVal years As String = "") As ActionResult
            GlobalVariables.years = years
            GlobalVariables.months = months
            YearAndMonthDropdownList()
            ViewBag.months = New SelectList(monthss, "Value", "Text", GlobalVariables.currentMonth)
            ViewBag.years = New SelectList(yearss, "Value", "Text", GlobalVariables.currentYear)
            Dim lastYear As Integer
            If years <> "" Then
                lastYear = Integer.Parse(years) - 1

            End If
            Dim lYear = lastYear.ToString()
            Dim debitlines = db.DebtitLinesViews.Where(Function(d) d.Year = years And d.Month = months).GroupBy(Function(u) u.UserName).Select(Function(s) New DebitLinePerUsersView With {
                                                                                                                                               .UserName = s.Select(Function(u) u.UserName).FirstOrDefault,
                                                                                                                                               .TotalSale = s.Sum(Function(u) u.LineTotal),
                                                                                                                                               .SaleCustomer = s.Where(Function(u) u.Status = 2).Sum(Function(u) u.LineTotal),
                                                                                                                                               .InternalDebiting = s.Where(Function(u) u.Status = 3).Sum(Function(u) u.LineTotal),
                                                                                                                                               .OtherExpencesAndKm = s.Sum(Function(u) u.OtherExpences),
                                                                                                                                               .LastDateDebiting = s.Max(Function(u) u.DebDate),
                                                                                                                                               .Forecast = 0,
                                                                                                                                               .SaleLastYear = s.Where(Function(u) u.Year = lYear).Sum(Function(u) u.LineTotal),
                                                                                                                                               .Difference = s.Sum(Function(u) u.LineTotal) - s.Where(Function(u) u.Year = lYear).Sum(Function(u) u.LineTotal)})




            Return View(debitlines)
        End Function

        Function DebiteratInfoPerUserName(Optional ByVal userName As String = "") As ActionResult
            YearAndMonthDropdownList()
            ViewBag.months = New SelectList(monthss, "Value", "Text", GlobalVariables.months)
            ViewBag.years = New SelectList(yearss, "Value", "Text", GlobalVariables.years)
            Dim lastYear As Integer
            If GlobalVariables.years <> "" Then
                lastYear = Integer.Parse(GlobalVariables.years) - 1

            End If
            Dim lYear = lastYear.ToString()
            Dim debitlinesPerUsers = db.DebtitLinesViews.Where(Function(d) d.Year = GlobalVariables.years And d.Month = GlobalVariables.months).GroupBy(Function(u) u.UserName).Select(Function(s) New DebitLinePerUsersView With {
                                                                                                                                               .UserName = s.Select(Function(u) u.UserName).FirstOrDefault,
                                                                                                                                               .TotalSale = s.Sum(Function(u) u.LineTotal),
                                                                                                                                               .SaleCustomer = s.Where(Function(u) u.Status = 2).Sum(Function(u) u.LineTotal),
                                                                                                                                               .InternalDebiting = s.Where(Function(u) u.Status = 3).Sum(Function(u) u.LineTotal),
                                                                                                                                               .OtherExpencesAndKm = s.Sum(Function(u) u.OtherExpences),
                                                                                                                                               .LastDateDebiting = s.Max(Function(u) u.DebDate),
                                                                                                                                               .Forecast = 0,
                                                                                                                                               .SaleLastYear = s.Where(Function(u) u.Year = lYear).Sum(Function(u) u.LineTotal),
                                                                                                                                               .Difference = s.Sum(Function(u) u.LineTotal) - s.Where(Function(u) u.Year = lYear).Sum(Function(u) u.LineTotal)}).ToList()


            Dim debitlines = db.DebtitLinesViews.Where(Function(d) d.UserName = userName).OrderBy(Function(d) d.DebDate).ToList()
            Dim debitlineslist As New List(Of DebitLinesOverview)
            For Each deb As DebitLinesView In debitlines

                Dim debOver As New DebitLinesOverview
                debOver.Comission = deb.Comission
                debOver.DebDate = deb.DebDate.ToShortDateString
                debOver.Description = deb.Description
                debOver.LineTotal = deb.LineTotal
                debOver.NoOfHours = deb.NoOfHours
                deb.KmAndOther = deb.KmAndOther
                deb.NoOfHours = deb.NoOfHours
                debOver.NoOfKm = deb.NoOfKm
                debOver.NoOfTravelHours = deb.NoOfTravelHours
                debOver.OtherExpences = deb.OtherExpences
                debOver.PricePerHoure = deb.PricePerHoure
                debOver.PricePerKm = deb.PricePerKm
                debOver.TravelPrice = deb.TravelPrice
                Dim customer = db.Customers.Where(Function(c) c.CustomerID = deb.CustomerID).FirstOrDefault
                Dim project = db.Projects.Where(Function(p) p.ProjectID = deb.ProjectID).FirstOrDefault
                debOver.Project = project
                debOver.Customer = customer
                debOver.UserName = deb.UserName
                debitlineslist.Add(debOver)

            Next
            Dim model As New DebitLinesPerUsersAndDebitLinesOverView
            model.DebitLinesPerUsers = debitlinesPerUsers
            model.DebitLines = debitlineslist
            Return View(model)
            Return Nothing
        End Function
        Function DebitLinePer12Months(ByVal m As Integer?) As ActionResult

            Return View()
        End Function


    End Class





End Namespace
