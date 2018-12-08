Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations

Public Class MyDebiterungPerCustomerView

    <DataType(DataType.Date)>
   <DisplayFormat(DataFormatString:="{0:yyyy/MM/dd}", ApplyFormatInEditMode:=True)>
    Public Property FirstDate As Date

    <DataType(DataType.Date)>
   <DisplayFormat(DataFormatString:="{0:yyyy/MM/dd}", ApplyFormatInEditMode:=True)>
    Public Property SecondDate As Date
    Public Property CustID As Integer

    Public Property DebitLines As List(Of DebitLinesOverview)





    End Class
