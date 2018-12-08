Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations
Public Class Project
    <Key>
    Public Property ProjectID() As Integer


    <Required(ErrorMessage:="Project Name is required")>
    Public Property ProjectName() As String
    Public Property Customer() As Customer
    Public Property CustomerID As Integer


End Class
