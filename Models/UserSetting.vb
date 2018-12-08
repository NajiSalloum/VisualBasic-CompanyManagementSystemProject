Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations
Public Class UserSetting

    <Key>
    Public Property UserSettingID() As Integer


    Public Property UserName() As String

    Public Property Initials() As String
    Public Property ExtResourc() As String

    Public Property ExtTravelTimeID() As String
    Public Property ExtNoOfK() As String
    Public Property ExtOtherExpencesID() As String
    Public Property Active() As Boolean

End Class
