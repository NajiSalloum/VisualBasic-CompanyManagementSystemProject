Imports System.ComponentModel.DataAnnotations
Public Class DebitLine
    <Key>
    Public Property LineID() As Integer

    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy/MM/dd}", ApplyFormatInEditMode:=True)>
    Public Property DebDate() As Date
    Public Property UserName() As String
    Public Property Customer() As Customer
    Public Property CustomerID() As Integer
    Public Property NoOfHours() As Decimal
    Public Property NoOfTravelHours() As Decimal
    Public Property NoOfKm() As Integer
    Public Property OtherExpences As Decimal

    Public Property Project() As Project
    Public Property ProjectID() As Integer?

    <Required(ErrorMessage:="Projektbeskrivning är obligatorisk, 160 char max!"), StringLength(160)>
    Public Property Description() As String

    Public Property Invoiced() As Date

    Public Property Regesterad() As Date

    Public Property PricePerHoure() As Decimal

    Public Property TravelPrice() As Decimal

    Public Property PricePerKm() As Integer

    Public Property Status() As Integer

    <Range(0, 1, ErrorMessage:="Commission must be between 0 and 1, tex 0.35")>
    Public Property Comission() As Decimal

    Public Property Subscription() As Integer

    Public Property CompanyCar() As Boolean

End Class
