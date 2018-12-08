Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Imports Microsoft.AspNet.Identity

Namespace BitlogTime
    Public Class CustomersController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: /Customers/
        Function Index() As ActionResult
            Dim customers = db.Customers.Include(Function(c) c.Company).Include(Function(c) c.PartnerLevel).Include(Function(c) c.PriceList).Where(Function(c) c.Deleted = False)
            Return View(customers.ToList())
        End Function

        ' GET: /Customers/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim customer As Customer = db.Customers.Find(id)
            Dim company As Company = db.Companies.Find(customer.CompanyID)
            Dim partnerLevel As PartnerLevel = db.PartnerLevels.Find(customer.PartnerLevelID)
            Dim kopplatPartner As Customer = db.Customers.Find(customer.KopplatPartnerID)
            If IsNothing(partnerLevel) Then
                customer.PartnerLevel = Nothing
            Else
                customer.PartnerLevel.PartnerLevelName = partnerLevel.PartnerLevelName
            End If
            Dim priceList As PriceList = db.PriiceLists.Find(customer.PriceListID)

            customer.Company.CompanyName = company.CompanyName

            customer.PriceList.PriceListName = priceList.PriceListName
            If kopplatPartner IsNot Nothing Then
                ViewBag.KopplatPartnerName = kopplatPartner.CustName
            Else
                ViewBag.KopplatPartnerName = "Ingen Kopplat Partner"
            End If


            If IsNothing(customer) Then
                Return HttpNotFound()
            End If
            Return View(customer)
        End Function

        ' GET: /Customers/Create
        Function Create() As ActionResult
            ViewBag.CompanyID = New SelectList(db.Companies, "CompanyID", "CompanyName")
            ViewBag.PartnerLevelID = New SelectList(db.PartnerLevels, "PartnerLevelID", "PartnerLevelName")
            ViewBag.PriceListID = New SelectList(db.PriiceLists, "PriceListID", "PriceListName")
            ViewData("Prices") = db.PriiceLists.[Select](Function(c) New SelectListItem With
            {
                .Text = c.PriceListName,
                .Value = c.PriceListID
            })

            ViewData("Companies") = db.Companies.[Select](Function(c) New SelectListItem With
            {
                .Text = c.CompanyName,
                .Value = c.CompanyID
            })

            ViewData("PartnerLevels") = db.PartnerLevels.[Select](Function(c) New SelectListItem With
            {
                .Text = c.PartnerLevelName,
                .Value = c.PartnerLevelID
            })
            ViewData("KopplatPartner") = db.Customers.Where(Function(c) c.IsAPartner = True).[Select](Function(c) New SelectListItem With
            {
                .Text = c.CustName,
            .Value = c.CustomerID
            })
            Dim model As New Customer() With {
                .TravelPrice = 0,
                .NoOfKm = 0,
                .PricePerKm = 0
                }
            Return View(model)
        End Function

        ' POST: /Customers/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="CustomerID,PriceListID,CompanyID,PartnerLevelID,Deleted,InternalCustomer,ErpOrderByProject,ExtCustID,Notes,NoOfTravelHour,CustName,CustRef,PricePerHour,TravelPrice,PricePerKm,NoOfKm,KopplatPartnerID")> ByVal customer As Customer) As ActionResult
            If ModelState.IsValid Then
                If customer.PartnerLevelID Is Nothing Then
                    customer.IsAPartner = False
                Else
                    customer.IsAPartner = True
                End If
                If customer.KopplatPartnerID Is Nothing Then
                    customer.KopplatPartnerID = Nothing
                End If
                db.Customers.Add(customer)
                db.SaveChanges()
                Return RedirectToAction("AllCustomers")
            End If
            ViewBag.CompanyID = New SelectList(db.Companies, "CompanyID", "CompanyName", customer.CompanyID)
            ViewBag.PartnerLevelID = New SelectList(db.PartnerLevels, "PartnerLevelID", "PartnerLevelName", customer.PartnerLevelID)
            ViewBag.PriceListID = New SelectList(db.PriiceLists, "PriceListID", "PriceListName", customer.PriceListID)
            Return RedirectToAction("AllCustomers")
        End Function

        ' GET: /Customers/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim customer As Customer = db.Customers.Find(id)
            Dim travelPrice As Decimal = customer.TravelPrice
            customer.TravelPrice = FormatNumber((travelPrice), 1)

            If IsNothing(customer) Then
                Return HttpNotFound()
            End If
            'ViewData("Prices") = db.PriiceLists.[Select](Function(c) New SelectListItem With
            '{
            '    .Text = c.PriceListName,
            '    .Value = c.PriceListID
            '})

            'ViewData("Companies") = db.Companies.[Select](Function(c) New SelectListItem With
            '{
            '    .Text = c.CompanyName,
            '    .Value = c.CompanyID
            '})

            'ViewData("PartnerLevels") = db.PartnerLevels.[Select](Function(c) New SelectListItem With
            '{
            '    .Text = c.PartnerLevelName,
            '    .Value = c.PartnerLevelID
            '})
            ViewData("KopplatPartner") = db.Customers.Where(Function(c) c.IsAPartner = True).[Select](Function(c) New SelectListItem With
            {
                .Text = c.CustName,
            .Value = c.CustomerID
            })

            ViewBag.CompanyID = New SelectList(db.Companies, "CompanyID", "CompanyName", customer.CompanyID)

            Dim partner = db.PartnerLevels.Where(Function(p) p.PartnerLevelID = customer.PartnerLevelID).FirstOrDefault
            customer.PartnerLevel = partner
            Dim partnerlevels = db.PartnerLevels.ToList()
            ViewBag.PartnerLevelName = "Välj"
            If partner IsNot Nothing Then
                partnerlevels = db.PartnerLevels.Where(Function(p) p.PartnerLevelID <> partner.PartnerLevelID).ToList()
                ViewBag.PartnerLevelName = partner.PartnerLevelName
            End If
            ViewBag.PartnerLevelID = New SelectList(partnerlevels, "PartnerLevelID", "PartnerLevelName", customer.PartnerLevel)


            Dim priceLista = db.PriiceLists.Where(Function(p) p.PriceListID = customer.PriceListID).FirstOrDefault
            customer.PriceList = priceLista
            Dim priceLists = db.PriiceLists.Where(Function(p) p.PriceListID <> priceLista.PriceListID).ToList()
            ViewBag.PriceListName = priceLista.PriceListName
            ViewBag.PriceListID = New SelectList(priceLists, "PriceListID", "PriceListName", customer.PriceListID)
            Return View(customer)
        End Function

        ' POST: /Customers/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="CustomerID,PriceListID,CompanyID,PartnerLevelID,Deleted,InternalCustomer,ErpOrderByProject,ExtCustID,Notes,NoOfTravelHour,CustName,CustRef,PricePerHour,TravelPrice,PricePerKm,NoOfKm,KopplatPartnerID,IsAPartner")> ByVal customer As Customer) As ActionResult
            If ModelState.IsValid Then
                If customer.PartnerLevelID Is Nothing Then
                    Dim TheCurrentCustLevelID = db.Customers.Where(Function(c) c.CustomerID = customer.CustomerID).Select(Function(c) c.PartnerLevel).FirstOrDefault
                    If TheCurrentCustLevelID IsNot Nothing Then
                        customer.PartnerLevelID = TheCurrentCustLevelID.PartnerLevelID
                    Else
                        customer.PartnerLevel = Nothing
                    End If


                End If
                If customer.PriceListID Is Nothing Then
                    Dim TheCurrentCustPriceListID = db.Customers.Where(Function(c) c.CustomerID = customer.CustomerID).Select(Function(c) c.PriceListID).FirstOrDefault
                    customer.PriceListID = TheCurrentCustPriceListID
                End If

                If customer.IsAPartner = False Then
                    customer.PartnerLevelID = Nothing
                Else
                    customer.KopplatPartnerID = Nothing
                End If
                

                If customer.KopplatPartnerID Is Nothing Then
                    customer.KopplatPartnerID = Nothing
                End If

                db.Entry(customer).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("AllCustomers")
            End If
            ViewBag.CompanyID = New SelectList(db.Companies, "CompanyID", "CompanyName", customer.CompanyID)
            ViewBag.PartnerLevelID = New SelectList(db.PartnerLevels, "PartnerLevelID", "PartnerLevelName", customer.PartnerLevelID)
            ViewBag.PriceListID = New SelectList(db.PriiceLists, "PriceListID", "PriceListName", customer.PriceListID)
            Return RedirectToAction("AllCustomers")
        End Function

        ' GET: /Customers/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim customer As Customer = db.Customers.Find(id)
            Dim company As Company = db.Companies.Where(Function(c) c.CompanyID = customer.CompanyID).FirstOrDefault
            Dim partner As PartnerLevel = db.PartnerLevels.Where(Function(c) c.PartnerLevelID = customer.PartnerLevelID).FirstOrDefault
            Dim prislista As PriceList = db.PriiceLists.Where(Function(c) c.PriceListID = customer.PriceListID).FirstOrDefault
            customer.Company = company
            customer.PartnerLevel = partner
            customer.PriceList = prislista
            If IsNothing(customer) Then
                Return HttpNotFound()
            End If
            Return View(customer)
        End Function

        ' POST: /Customers/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim customer As Customer = db.Customers.Find(id)
            customer.Deleted = True
            db.Entry(customer).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("AllCustomers")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub


        'GET: Customers/AllCustomers
        Function AllCustomers(ByVal SearchName As String, Optional ByVal n As Integer = 0, Optional ByVal DateToGetoverview As String = " ") As ActionResult
            UpadateSub()
            GlobalVariables.countOfCustomers = db.Customers.Where(Function(c) c.Deleted = False).Count


            Dim dDate As Date
            If DateToGetoverview = " " Then
                dDate = Date.Now
                ViewData("InitialDate") = GlobalVariables.initialDate
            Else
                ViewData("InitialDate") = DateToGetoverview
                dDate = Date.ParseExact(DateToGetoverview, "MM/dd/yyyy",
                System.Globalization.DateTimeFormatInfo.InvariantInfo)


            End If


            GlobalVariables.num = GlobalVariables.num + n
            Dim customersList As New List(Of AllCustomersView)
            Dim customers = Nothing
            If SearchName Is Nothing Then
                customers = db.Customers.Where(Function(c) c.Deleted = False).Take(GlobalVariables.num).ToList()
            Else
                customers = (From u In db.Customers
                         Where u.Deleted = False And u.CustName.Contains(SearchName)
                         ).ToList()
            End If



            For Each customer As Customer In customers
                Dim company = (From c In db.Companies
                                  Where c.CompanyID = customer.CompanyID
                                  Select c).FirstOrDefault

                Dim priceList = (From c In db.PriiceLists
                                 Where c.PriceListID = customer.PriceListID
                                 Select c).FirstOrDefault

                customersList.Add(New AllCustomersView() With
                              {.CustID = customer.CustomerID,
                                .CustName = customer.CustName,
                               .CustRef = customer.CustRef,
                               .PriceList = priceList,
                               .PartnerLevel = customer.PartnerLevel,
                               .IinternalCustomer = customer.InternalCustomer})
            Next
            Dim DebitLinesList As New List(Of DebitLinesOverview)
            Dim debitlines = Nothing
            Dim userName = User.Identity.GetUserName
            debitlines = (From d In db.DebtitLinesViews
                         Where d.UserName = userName And d.DebDate.Year = dDate.Year And d.DebDate.Month = dDate.Month And d.DebDate.Day = dDate.Day
                         ).ToList()


            Dim totalDebiterad As Decimal = 0

            For Each debitLine As DebitLinesView In debitlines
                totalDebiterad += debitLine.LineTotal
                Dim customer = (From c In db.Customers
                                  Where c.CustomerID = debitLine.CustomerID
                                  Select c).FirstOrDefault

                Dim project = (From c In db.Projects
                                 Where c.ProjectID = debitLine.ProjectID
                                 Select c).FirstOrDefault

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

            ViewBag.theDate = dDate.Year.ToString + "/" + dDate.Month.ToString + "/" + dDate.Day.ToString
            ViewBag.totalDebiterat = totalDebiterad

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
                               .UserName = subscription.UserName,
                               .InternalCustomer = customer.InternalCustomer})
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
                               .UserName = subscription.UserName,
                               .InternalCustomer = customer.InternalCustomer})

                End If

            Next
            Dim model As New AllCustomersAndDebitLinesOverView()
            model.AllCustomers = customersList
            model.DebitLines = DebitLinesList
            model.AllSubscriptions = subscriptionsList
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
