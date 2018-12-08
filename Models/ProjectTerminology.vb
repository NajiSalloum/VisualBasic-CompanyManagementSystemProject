Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations
Public Class ProjectTerminology
    <Key>
    Public Property ProjectTerminologyID As Integer

    <Required(ErrorMessage:="Namn är obligatorisk")>
    Public Property ProjectTerminologyName As String

    <Required(ErrorMessage:="Besikrivning är obligatorisk")>
    Public Property ProjectTerminologyDescription As String
End Class
