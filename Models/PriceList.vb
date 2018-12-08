Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations
Public Class PriceList
    <Key>
    Private _priceListID As Integer
    Public Property PriceListID() As Integer
        Get
            Return _priceListID
        End Get
        Set(ByVal value As Integer)
            _priceListID = value
        End Set
    End Property
    <Required(ErrorMessage:="PriceList Name is required")>
    Private _priceListName As String

    <Required(ErrorMessage:="PriceList Name is required")>
    Public Property PriceListName() As String
        Get
            Return _priceListName
        End Get
        Set(ByVal value As String)
            _priceListName = value
        End Set
    End Property


End Class
