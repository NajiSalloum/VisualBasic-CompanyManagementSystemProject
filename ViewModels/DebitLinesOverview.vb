Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations
Public Class DebitLinesOverview
    Public Property LineID() As Integer

    Public Property DebLineID() As Integer?
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy/MM/dd}", ApplyFormatInEditMode:=True)>
    Public Property DebDate() As Date

    Public Property UserName() As String
    Public Property Customer() As Customer
    Public Property CustomerID() As Integer?

    Public Property NoOfHours() As Decimal?
    Public Property NoOfTravelHours() As Decimal?
    Public Property NoOfKm() As Integer?
    Public Property OtherExpences As Decimal?

    Public Property Project() As Project
    Public Property ProjectID() As Integer?

    Public Property Description() As String
    Public Property PricePerHoure() As Decimal?
    Public Property TravelPrice() As Decimal?
    Public Property PricePerKm() As Integer?
    Public Property Comission() As Decimal?
    Public Property LineTotal() As Decimal?

    Public Property Total() As Decimal?
End Class
