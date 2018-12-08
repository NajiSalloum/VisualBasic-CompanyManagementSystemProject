Imports System.ComponentModel.DataAnnotations

Public Class PartnerLevel
    <Key>
    Private _partnerLevelID As Integer
    Public Property PartnerLevelID() As Integer
        Get
            Return _partnerLevelID
        End Get
        Set(ByVal value As Integer)
            _partnerLevelID = value
        End Set
    End Property
    <Required(ErrorMessage:="Level Name is required")>
    Private _partnerLevelName As String


    <Required(ErrorMessage:="Level Name is required")>
    Public Property PartnerLevelName() As String
        Get
            Return _partnerLevelName
        End Get
        Set(ByVal value As String)
            _partnerLevelName = value
        End Set
    End Property


End Class
