Public Class AllSubscriptionsInDebitLinesView
    Public Property SubscriptionID() As Integer

    Public Property SubscriptionName() As String
    Public Property Project() As Project
    Public Property ProjectID() As Integer?

    Public Property Customer() As Customer
    Public Property CustomerID() As Integer?

    Public Property NoOfHours() As Decimal?

    Public Property Debiterad() As Decimal?
    Public Property PricePerHour() As Decimal?

    Public Property Description() As String

    Public Property LockedToUser() As Boolean
    Public Property StartDate() As Date?
    Public Property AutoDeb() As Boolean
    Public Property Commission() As Decimal?
End Class
