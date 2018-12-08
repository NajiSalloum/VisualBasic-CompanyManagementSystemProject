Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations
Public Class AllUsersView

    Public Property Id() As String

    <Display(Name:="Användarnamn")>
    Public Property UserName As String

    <Display(Name:="Roll")>
    Public Property Role() As String

End Class
