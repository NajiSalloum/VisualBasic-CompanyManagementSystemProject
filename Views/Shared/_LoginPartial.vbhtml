@Imports Microsoft.AspNet.Identity
@If Request.IsAuthenticated Then
    @Using Html.BeginForm("LogOff", "Account", FormMethod.Post, New With {.id = "logoutForm", .class = "navbar-right"})
        @Html.AntiForgeryToken()
        @<ul class="nav navbar-nav navbar-right">
             <li class="dropdown">

                 <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">&nbsp; &nbsp;&nbsp;<span aria-hidden="true" class="glyphicon glyphicon-user" ></span> @Html.Raw(User.Identity.GetUserName)<span class="caret"></span></a>
                 <ul class="dropdown-menu">
                     <li><a runat="server" href="~/Account/Manage">Byta lösenord</a></li>
                     <li><a href="javascript:document.getElementById('logoutForm').submit()">Logga ut</a></li>
                     <li>
                         <asp:loginstatus runat="server" logoutaction="Redirect" logouttext="Logga ut" logoutpageurl="~/" onloggingout="Unnamed_LoggingOut" />
                     </li>
                 </ul>
             </li>

            
            @*<li>
                    @Html.ActionLink("Hello " + User.Identity.GetUserName() + "!", "Manage", "Account", routeValues := Nothing, htmlAttributes := New With { .title = "Manage" })
                </li>*@
                @*<li><a href="javascript:document.getElementById('logoutForm').submit()">Logga ut</a></li>*@
        </ul>
    End Using
Else
    @<ul class="nav navbar-nav navbar-right">
        @*<li>@Html.ActionLink("Register", "Register", "Account", routeValues := Nothing, htmlAttributes := New With { .id = "registerLink" })</li>*@
        <li>@Html.ActionLink("Logga in", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "loginLink"})</li>

    </ul>
End If

