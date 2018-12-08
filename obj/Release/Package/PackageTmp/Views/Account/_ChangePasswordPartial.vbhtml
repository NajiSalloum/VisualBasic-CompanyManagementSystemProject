@Imports Microsoft.AspNet.Identity
@ModelType ManageUserViewModel

<p class="text-info">Du är inloggad som <strong>@User.Identity.GetUserName()</strong>.</p>

@Using Html.BeginForm("Manage", "Account", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})

    @Html.AntiForgeryToken()

    @<text>
    <h4>Byta av lösenord</h4>
    <hr />
    <div class="form-group">
        @Html.Label("Lösenord:", New With {.class = "col-md-2 control-label"})
        <div class="col-md-10">
            @Html.PasswordFor(Function(m) m.OldPassword, New With {.class = "form-control"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Nytt Lösenord:", New With {.class = "col-md-2 control-label"})
        <div class="col-md-10">
            @Html.PasswordFor(Function(m) m.NewPassword, New With {.class = "form-control"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Bekräfta:", New With {.class = "col-md-2 control-label"})
        <div class="col-md-10">
            @Html.PasswordFor(Function(m) m.ConfirmPassword, New With {.class = "form-control"})
        </div>
    </div>

    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" value="Byta" class="btn btn-primary"  />
        </div>
    </div>
    </text>
End Using
