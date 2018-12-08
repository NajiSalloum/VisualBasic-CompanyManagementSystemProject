Imports System.Web.Mvc

Public Class CommisionsController
    Inherits Controller
    Private db As New ApplicationDbContext
    ' GET: /Commisions
    Function Index(Optional ByVal months As String = "", Optional ByVal years As String = "") As ActionResult

        Dim monthss As New List(Of SelectListItem)()
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


        Dim yearss As New List(Of SelectListItem)()
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


        ViewBag.months = New SelectList(monthss, "Value", "Text")
        ViewBag.years = New SelectList(yearss, "Value", "Text")
        Dim commisionsList As New List(Of ComisionsView)
        Dim debitslinesviews = Nothing

        If months = "" And years = "" Then
            debitslinesviews = db.DebtitLinesViews.ToList().DefaultIfEmpty
        Else
            debitslinesviews = db.DebtitLinesViews.Where(Function(d) d.Month = months And d.Year = years).ToList()
        End If





        For Each debitlineview As DebitLinesView In debitslinesviews
            Dim project = (From c In db.Projects
                              Where c.ProjectID = debitlineview.ProjectID
                              Select c).FirstOrDefault

            Dim customer = (From c In db.Customers
                             Where c.CustomerID = debitlineview.CustomerID
                             Select c).FirstOrDefault

            commisionsList.Add(New ComisionsView() With
                          {.Comission = debitlineview.Comission,
                           .ComissionBased = debitlineview.ComissionBased,
                           .Customer = customer,
                           .Description = debitlineview.Description,
                           .NoOfHours = debitlineview.NoOfHours,
                           .PricePerHoure = debitlineview.PricePerHoure,
                           .Project = project,
                           .Regesterad = debitlineview.Regesterad,
                           .UserName = debitlineview.UserName})
        Next
        Return View(commisionsList)
        Return View(db.DebtitLinesViews.ToList())
    End Function
End Class