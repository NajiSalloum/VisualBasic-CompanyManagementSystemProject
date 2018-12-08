Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations
Public Class DebitLinePerUsersView
    Public Property UserName As String
    Public Property TotalSale As Decimal?
    Private _saleCustomer As Decimal
    Public Property SaleCustomer() As Decimal?
        Get
            Return _saleCustomer
        End Get
        Set(ByVal value As Decimal?)
            If value Is Nothing Then
                _saleCustomer = 0
            Else
                _saleCustomer = value
            End If


        End Set
    End Property


    Private _internalDebiting As Decimal?
    Public Property InternalDebiting() As Decimal?
        Get
            Return _internalDebiting
        End Get
        Set(ByVal value As Decimal?)
            If value Is Nothing Then
                _internalDebiting = 0
            Else
                _internalDebiting = value
            End If

        End Set
    End Property



    Public Property OtherExpencesAndKm As Decimal?

    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy/MM/dd}", ApplyFormatInEditMode:=True)>
    Public Property LastDateDebiting As Date?
    Public Property Forecast As Decimal?
    Private _saleLastYear As Decimal?
    Public Property SaleLastYear() As Decimal?
        Get
            Return _saleLastYear
        End Get
        Set(ByVal value As Decimal?)
            If value Is Nothing Then
                _saleLastYear = 0
            Else
                _saleLastYear = value
            End If

        End Set
    End Property

    Private _difference As Decimal?
    Public Property Difference() As Decimal?
        Get
            Return _difference
        End Get
        Set(ByVal value As Decimal?)
            If value Is Nothing Then
                _difference = 0
            Else
                _difference = value
            End If

        End Set
    End Property

End Class
