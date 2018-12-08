Imports Microsoft.AspNet.Identity.EntityFramework

Imports System.Security.Claims
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations

' You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
Public Class ApplicationUser
    Inherits IdentityUser



End Class

Public Class ApplicationDbContext
    Inherits IdentityDbContext(Of ApplicationUser)
    Public Property Companies() As DbSet(Of Company)
    Public Property PriiceLists() As DbSet(Of PriceList)
    Public Property PartnerLevels() As DbSet(Of PartnerLevel)

    Public Property Customers() As DbSet(Of Customer)

    Public Property Projects() As DbSet(Of Project)

    Public Property DebitLines() As DbSet(Of DebitLine)
    Public Property Prices() As DbSet(Of Price)

    Public Property Memberships() As DbSet(Of Membership)

    Public Property UserSettings() As DbSet(Of UserSetting)
    Public Property DebtitLinesViews() As DbSet(Of DebitLinesView)
    Public Property PeriodTypes() As DbSet(Of PeriodType)
    Public Property Subscriptions() As DbSet(Of Subscription)
    Public Property ProjectTerminologies() As DbSet(Of ProjectTerminology)
    Public Property ResourceEvents() As DbSet(Of ResourceEvent)
    Public Property RecourseEventLines() As DbSet(Of RecourseEventLine)

    Public Sub New()
        MyBase.New("DefaultConnection")
    End Sub
    Public Shared Function Create() As ApplicationDbContext
        Return New ApplicationDbContext()
    End Function


End Class
