Imports System.ComponentModel.DataAnnotations

Public Class Customer
    <Key>
    Private _customerID As Integer

    <Required(ErrorMessage:="Customer Name is required")>
    Private _custName As String

    Private _custRef As String
    Private _pricePerHour As Decimal
    Private _travelPrice As Decimal
    Private _pricePerKm As String

    Public Property NoOfKm() As Integer?
    Public Property PriceList() As PriceList
    Public Property PriceListID() As Integer?

    Private _noOfTravelHour As Integer
    Private _notes As String
    Private _extCustID As String
    Private _isAPartner As Boolean
    Public Property IsAPartner() As Boolean
        Get
            Return _IsAPartner
        End Get
        Set(ByVal value As Boolean)
            _IsAPartner = value
        End Set
    End Property


    Public Property Company() As Company
    Public Property CompanyID() As Integer?



    Public Property PartnerLevel() As PartnerLevel
    Public Property PartnerLevelID() As Integer?


    Public Property KopplatPartner() As Customer
    Public Property KopplatPartnerID() As Integer?


    Private _erpOrderByProject As Boolean

    Private _internalCustomer As Boolean

    Private _deleted As Boolean


    Public Property Deleted() As Boolean
        Get
            Return _deleted
        End Get
        Set(ByVal value As Boolean)
            _deleted = value
        End Set
    End Property

    Public Property InternalCustomer() As Boolean
        Get
            Return _internalCustomer
        End Get
        Set(ByVal value As Boolean)
            _internalCustomer = value
        End Set
    End Property

    Public Property ErpOrderByProject() As Boolean
        Get
            Return _erpOrderByProject
        End Get
        Set(ByVal value As Boolean)
            _erpOrderByProject = value
        End Set
    End Property


    Public Property ExtCustID() As String
        Get
            Return _extCustID
        End Get
        Set(ByVal value As String)
            _extCustID = value
        End Set
    End Property



    Public Property Notes() As String
        Get
            Return _notes
        End Get
        Set(ByVal value As String)
            _notes = value
        End Set
    End Property



    Public Property NoOfTravelHour() As Integer
        Get
            Return _noOfTravelHour
        End Get
        Set(ByVal value As Integer)
            _noOfTravelHour = value
        End Set
    End Property

    Public Property CustomerID() As Integer
        Get
            Return _customerID
        End Get
        Set(ByVal value As Integer)
            _customerID = value
        End Set
    End Property

    <Required(ErrorMessage:="Customer Name is required")>
    Public Property CustName() As String
        Get
            Return _custName
        End Get
        Set(ByVal value As String)
            _custName = value
        End Set
    End Property


    Public Property CustRef() As String
        Get
            Return _custRef
        End Get
        Set(ByVal value As String)
            _custRef = value
        End Set
    End Property


    Public Property PricePerHour() As Decimal
        Get
            Return _pricePerHour
        End Get
        Set(ByVal value As Decimal)
            _pricePerHour = value
        End Set
    End Property


    Public Property TravelPrice() As Decimal
        Get
            Return _travelPrice
        End Get
        Set(ByVal value As Decimal)
            _travelPrice = value
        End Set
    End Property


    Public Property PricePerKm() As String
        Get
            Return _pricePerKm
        End Get
        Set(ByVal value As String)
            _pricePerKm = value
        End Set
    End Property







End Class
