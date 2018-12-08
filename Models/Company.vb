Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations
Public Class Company

    <Key>
    Private _companyID As Integer

    <Required(ErrorMessage:="Company Name is required")>
    Private _companyName As String

    <Required(ErrorMessage:="Company Name is required")>
    Public Property CompanyName() As String
        Get
            Return _companyName
        End Get
        Set(ByVal value As String)
            _companyName = value
        End Set
    End Property

    Public Property CompanyID() As Integer
        Get
            Return _companyID
        End Get
        Set(ByVal value As Integer)
            _companyID = value
        End Set
    End Property


End Class
