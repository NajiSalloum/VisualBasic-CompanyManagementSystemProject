@Imports Microsoft.AspNet.Identity
<!DOCTYPE html>
<html>
<head>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>


    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
    <link href="~/Content/Site.css" rel="stylesheet" />
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("BitlogTime", "Index", "Home", Nothing, New With {.[class] = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    @*<li>@Html.ActionLink("Home", "Index", "Home")</li>
                    <li>@Html.ActionLink("About", "About", "Home")</li>
                    <li>@Html.ActionLink("Contact", "Contact", "Home")</li>
                    <li>@Html.ActionLink("Password", "ChangePassword", "Members", New With {.id = Context.User.Identity.GetUserId}, Nothing)</li>*@
                </ul>
                @Html.Partial("_LoginPartial")
                @Code
                    If (Context.User.IsInRole("Admin")) Then
                End Code

                <ul class="nav navbar-nav navbar-right">
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><span aria-hidden="true" class="glyphicon glyphicon-user"></span> Användare <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a runat="server" href="~/Members/RegisterMember">Registrera ny användare</a></li>
                            <li><a runat="server" href="~/Members/AllUsers">Visa alla användare </a></li>
                            <li><a runat="server" href="~/UserSettings/Index">Ange användare egenskaper </a></li>
                            <li>
                                <asp:loginstatus runat="server" logoutaction="Redirect" logouttext="Logga ut" logoutpageurl="~/" onloggingout="Unnamed_LoggingOut" />
                            </li>
                        </ul>
                    </li>


                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><span aria-hidden="true" class="glyphicon glyphicon-picture"></span> Kunder <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a runat="server" href="~/Customers/Create">Lägg till ny kund</a></li>
                            <li><a runat="server" href="~/Customers/AllCustomers">Visa alla kunder</a></li>
                            <li>
                                <asp:loginstatus runat="server" logoutaction="Redirect" logouttext="Logga ut" logoutpageurl="~/" onloggingout="Unnamed_LoggingOut" />
                            </li>
                        </ul>
                    </li>

                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><span aria-hidden="true" class="glyphicon glyphicon-list-alt"></span> Prislistor <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a runat="server" href="~/PriceLists/Create">Lägg till ny prislista</a></li>
                            <li><a runat="server" href="~/PriceLists/Index">Visa alla prislistor</a></li>
                            <li><a runat="server" href="~/Prices/Create">Registrera</a></li>
                            <li><a runat="server" href="~/Prices/AllPrices">Visa alla registrerade prislistor</a></li>
                            <li>
                                <asp:loginstatus runat="server" logoutaction="Redirect" logouttext="Logga ut" logoutpageurl="~/" onloggingout="Unnamed_LoggingOut" />
                            </li>
                        </ul>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><span aria-hidden="true" class="glyphicon glyphicon-euro"></span> Provision <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a runat="server" href="~/Commisions/Index">Rapport selektering </a></li>

                            <li>
                                <asp:loginstatus runat="server" logoutaction="Redirect" logouttext="Logga ut" logoutpageurl="~/" onloggingout="Unnamed_LoggingOut" />
                            </li>
                        </ul>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><span aria-hidden="true" class="glyphicon glyphicon-book"></span> Projects <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a runat="server" href="~/ProjectTerminologies/Create">Lägg till nytt project </a></li>
                            <li><a runat="server" href="~/Projects/AddCustomerToProject">Lägg till befintligt project </a></li>
                            <li>
                                <asp:loginstatus runat="server" logoutaction="Redirect" logouttext="Logga ut" logoutpageurl="~/" onloggingout="Unnamed_LoggingOut" />
                            </li>
                        </ul>
                    </li>
                </ul>
                @Code
                    End If
                End Code
                @Code
                    If (Context.User.IsInRole("Konsult")) Then
                End Code
                
                <ul class="nav navbar-nav navbar-right">
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><span aria-hidden="true" class="glyphicon glyphicon-stats"></span> Uppföljning <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a runat="server" href="~/DebitLines/DebitLinePerCustomer">Välj uppföljning</a></li>
                            

                            <li>
                                <asp:loginstatus runat="server" logoutaction="Redirect" logouttext="Logga ut" logoutpageurl="~/" onloggingout="Unnamed_LoggingOut" />
                            </li>
                        </ul>
                    </li>
                    <ul class="nav navbar-nav navbar-right">
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><span aria-hidden="true" class="glyphicon glyphicon-calendar"></span> Tillgänglighet <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a runat="server" href="~/ResourceEventLines/Create">Registrera tillgänglighet</a></li>
                                <li><a runat="server" href="~/ResourceEventLines/Schedule">Visa tillgänglighet</a></li>

                                <li>
                                    <asp:loginstatus runat="server" logoutaction="Redirect" logouttext="Logga ut" logoutpageurl="~/" onloggingout="Unnamed_LoggingOut" />
                                </li>
                            </ul>
                        </li>


                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><span aria-hidden="true" class="glyphicon glyphicon-share"></span> Abonnemang <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a runat="server" href="~/Subscriptions/AllSubsicriptionsWithDebitLinesOverview">Visa alla abonnemang</a></li>
                                <li><a runat="server" href="~/Subscriptions/AllCustomers">Lägg till abonnemang</a></li>
                                <li>
                                    <asp:loginstatus runat="server" logoutaction="Redirect" logouttext="Logga ut" logoutpageurl="~/" onloggingout="Unnamed_LoggingOut" />
                                </li>
                            </ul>
                        </li>

                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><span aria-hidden="true" class="glyphicon glyphicon-time"></span> arbetad tid <span class="caret"></span></a>
                            <ul class="dropdown-menu">

                                <li><a runat="server" href="~/Customers/AllCustomers">Registrera arbetad tid</a></li>
                                <li>
                                    <asp:loginstatus runat="server" logoutaction="Redirect" logouttext="Logga ut" logoutpageurl="~/" onloggingout="Unnamed_LoggingOut" />
                                </li>
                            </ul>
                        </li>

                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><span aria-hidden="true" class="glyphicon glyphicon-list-alt"></span> Prislistor <span class="caret"></span></a>
                            <ul class="dropdown-menu">

                                <li><a runat="server" href="~/Prices/Create">Registrera</a></li>
                                <li>
                                    <asp:loginstatus runat="server" logoutaction="Redirect" logouttext="Logga ut" logoutpageurl="~/" onloggingout="Unnamed_LoggingOut" />
                                </li>
                            </ul>
                        </li>
                    </ul>
                    @Code
                        End If
                    End Code


</div>
        </div>
    </div>
    <div class="container body-content">
        @RenderBody()
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    @RenderSection("scripts", required:=False)
</body>
</html>
