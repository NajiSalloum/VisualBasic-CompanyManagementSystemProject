Imports System.ComponentModel.DataAnnotations
Public Class Price
    <Key>
    Public Property PriceID() As Integer

    Public Property PriceList() As PriceList
    Public Property PriceListID() As Integer

    Public Property User() As ApplicationUser
    Public Property UserID() As String

    Public Property PricePerHour() As Decimal
    Public Property TravelPrice() As Decimal
    Public Property PricePerKm() As Decimal
    <Range(0, 1, ErrorMessage:="Commission must be between 0 and 1, tex 0.35")>
    Public Property Commission() As Decimal
End Class
