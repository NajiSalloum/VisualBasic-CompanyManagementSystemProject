Imports System.ComponentModel.DataAnnotations
Public Class AllSubscriptionsView
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

    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy/MM/dd}", ApplyFormatInEditMode:=True)>
    Public Property RegisteredDate() As Date?
    Public Property Description() As String

    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy/MM/dd}", ApplyFormatInEditMode:=True)>
    Public Property LastInvoiced() As Date?
    Public Property LockedToUser() As Boolean

    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy/MM/dd}", ApplyFormatInEditMode:=True)>
    Public Property StartDate() As Date?
    Public Property AutoDeb() As Boolean
    Public Property Commission() As Decimal?
    Public Property Debiterad() As Boolean

    Public Property InternalCustomer() As Boolean
End Class
