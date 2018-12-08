Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations
Public Class ResourceEvent
    <Key>
    Public Property ResourceEventID As Integer

    Public Property EventName As String

    Public Property EventType As Integer?
End Class
