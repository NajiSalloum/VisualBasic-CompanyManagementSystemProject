Imports System.ComponentModel.DataAnnotations
Public Class DebitLinesView
    <Key>
    Public Property LineID() As Integer

    <DataType(DataType.Date)>
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

    Public Property Invoiced() As Date?

    Public Property Regesterad() As Date?

    Public Property PricePerHoure() As Decimal?

    Public Property TravelPrice() As Decimal?

    Public Property PricePerKm() As Integer?

    Public Property Status() As Integer?


    Public Property Comission() As Decimal?

    Public Property Subscription() As Integer?

    Public Property CompanyCar() As Boolean?

    Public Property Year() As String

    Public Property Month() As String 
    Public Property LineTotal() As Decimal?

    Public Property ComissionBased() As Decimal?

    Public Property KmAndOther() As Decimal? 

    Public Property DebLineID() As Integer?

End Class
