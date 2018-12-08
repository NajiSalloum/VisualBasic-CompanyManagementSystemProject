Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Public Class PricesController
    Inherits Controller
    Private db As New ApplicationDbContext
    ' GET: /Prices
    Function Index() As ActionResult
        Return View(db.Prices.ToList())
    End Function

    'GET: Prices/AllPrices
    Function AllPrices() As ActionResult
        Dim pricesList As New List(Of AllPricesView)
        Dim prices = Nothing

        prices = db.Prices.ToList()

        



        For Each price As Price In prices
            Dim pricelist = (From c In db.PriiceLists
                              Where c.PriceListID = price.PriceListID
                              Select c).FirstOrDefault

            Dim user = (From c In db.Users
                             Where c.Id = price.UserID
                             Select c).FirstOrDefault

            pricesList.Add(New AllPricesView() With
                          {.PriceID = price.PriceID,
                            .Commission = price.Commission,
                           .PricePerHour = price.PricePerHour,
                           .PricePerKm = price.PricePerKm,
                           .TravelPrice = price.TravelPrice,
                           .User = user,
                           .PriceList = pricelist
                          })
        Next
        Return View(pricesList)
    End Function











    ' GET: /Prices/Create
    Function Create() As ActionResult
        
        ViewData("Prices") = db.PriiceLists.[Select](Function(c) New SelectListItem With
        {
            .Text = c.PriceListName,
            .Value = c.PriceListID
        })

        ViewData("Users") = db.Users.Where(Function(u) u.UserName IsNot Nothing).[Select](Function(c) New SelectListItem With
        {
            .Text = c.UserName,
            .Value = c.Id
        })

        Dim modelPrice As New Price() With {
            .Commission = 0,
            .PricePerHour = 0,
            .PricePerKm = 0,
            .TravelPrice = 0}

        Dim model As New CreateAndAllPricesView()
        model.Price = modelPrice
        Dim pricesList As New List(Of AllPricesView)
        Dim prices = Nothing

        prices = db.Prices.ToList()





        For Each price As Price In prices
            Dim pricelist = (From c In db.PriiceLists
                              Where c.PriceListID = price.PriceListID
                              Select c).FirstOrDefault

            Dim user = (From c In db.Users
                             Where c.Id = price.UserID
                             Select c).FirstOrDefault

            pricesList.Add(New AllPricesView() With
                          {.PriceID = price.PriceID,
                            .Commission = price.Commission,
                           .PricePerHour = price.PricePerHour,
                           .PricePerKm = price.PricePerKm,
                           .TravelPrice = price.TravelPrice,
                           .User = user,
                           .PriceList = pricelist
                          })
        Next
        model.AllPrices = pricesList
        Return View(model)
    End Function
    ' POST: /Prices/Create
    'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    <HttpPost()>
    <ValidateAntiForgeryToken()>
    Function Create(ByVal price As Price) As ActionResult
        If ModelState.IsValid Then
            Dim pr = db.Prices.Where(Function(p) p.PriceListID = price.PriceListID And p.UserID = price.UserID).FirstOrDefault
            If pr Is Nothing Then
                db.Prices.Add(price)
                db.SaveChanges()
            End If

           
            Return RedirectToAction("Create")
        End If
        
        Return View()
    End Function

    ' GET: /Prices/Delete/5
    Function Delete(ByVal id As Integer?) As ActionResult
        If IsNothing(id) Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim price As Price = db.Prices.Find(id)
        Dim priceList = db.PriiceLists.Where(Function(p) p.PriceListID = price.PriceListID).FirstOrDefault
        Dim user = db.Users.Where(Function(u) u.Id = price.UserID).FirstOrDefault
        price.PriceList = priceList
        price.User = user
        If IsNothing(price) Then
            Return HttpNotFound()
        End If
        Return View(price)
    End Function

    ' POST: /Prices/Delete/5
    <HttpPost()>
    <ActionName("Delete")>
    <ValidateAntiForgeryToken()>
    Function DeleteConfirmed(ByVal id As Integer) As ActionResult
        Dim price As Price = db.Prices.Find(id)
        db.Prices.Remove(price)
        db.SaveChanges()
        Return RedirectToAction("Create")
    End Function


End Class