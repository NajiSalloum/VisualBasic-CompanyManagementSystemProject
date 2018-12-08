Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations
Public Class Subscription

    <Key>
    Public Property SubscriptionID() As Integer

    Public Property Project() As Project
    Public Property ProjectID() As Integer?

    Public Property Customer() As Customer
    Public Property CustomerID() As Integer?

    Public Property PeriodType() As PeriodType
    Public Property PeriodTypeID() As Integer?

    Public Property UserName() As String
    Public Property NoOfHours() As Decimal?
    Public Property PricePerHour() As Decimal?
    Public Property RegisteredDate() As Date?
    Public Property Description() As String
    Public Property LastInvoiced() As Date?
    Public Property LockedToUser() As Boolean
    Public Property StartDate() As Date?
    Public Property AutoDeb() As Boolean

    Public Property Debiterad() As Boolean

    <Range(0, 1, ErrorMessage:="Commission must be between 0 and 1, tex 0.35")>
    Public Property Commission() As Decimal?
End Class
