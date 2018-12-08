Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations

Public Class RecourseEventLine
    <Key>
    Public Property RecourseEventLineID As Integer

    Public Property User() As ApplicationUser
    Public Property UserID() As String
    Public Property UserName As String

    Public Property EventDate As Date?
    Public Property ResourceEvent() As ResourceEvent
    Public Property ResourceEventID() As Integer?


End Class
