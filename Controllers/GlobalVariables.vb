Public Class GlobalVariables
    Public Shared countOfCustomers As Integer
    Public Shared num As Integer = 4
    Public Shared years As String
    Public Shared months As String
    Public Shared currentMonth As String = Date.Now.Month.ToString()
    Public Shared currentYear As String = Date.Now.Year.ToString()
    Public Shared initialDate As String = Date.Now.ToString("MM/dd/yyyy")
End Class
