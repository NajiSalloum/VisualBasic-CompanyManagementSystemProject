Imports System.ComponentModel.DataAnnotations
Public Class Membership

    <Key>
    Public Property MembershipID() As Integer
    Public Property UserID() As String

    Public Property UserName() As String
    Public Property CreateDate() As Date?
    Public Property LastLoginDate() As Date?
    Public Property PasswordChangedDate() As Date?

End Class
