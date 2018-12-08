@ModelType RegisterViewModel
@Code
    ViewBag.Title = "Register"
End Code
<div class="jumbotron">

    <h2>@ViewBag.Title.</h2>

    @Using Html.BeginForm("RegisterMember", "Members", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})

        @Html.AntiForgeryToken()

        @<text>
            <h4>Registera ny användare.</h4>
            <hr />
            @Html.ValidationSummary()
            <div class="form-group">
                @Html.Label("Användernamn", New With {.class = "col-md-2 control-label"})
                <div class="col-md-10">
                    @Html.TextBoxFor(Function(m) m.UserName, New With {.class = "form-control"})
                </div>
                <span id="TextErrorMessage" class="text-danger hidden">Användarnamn redan finns!!!</span>
            </div>
            <div class="form-group">
                @Html.Label("Lösenord", New With {.class = "col-md-2 control-label"})
                <div class="col-md-10">
                    @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
                </div>
            </div>
            <div class="form-group">
                @Html.Label("Bekräfta", New With {.class = "col-md-2 control-label"})
                <div class="col-md-10">
                    @Html.PasswordFor(Function(m) m.ConfirmPassword, New With {.class = "form-control"})
                </div>
            </div>
            @Code
            Dim roles As New List(Of SelectListItem)()
            roles.Add(New SelectListItem() With
              {
              .Text = "Admin",
              .Value = 1
              })
            roles.Add(New SelectListItem() With
              {
              .Text = "Konsult",
              .Value = 2
              })

            End Code
            <div class="form-group">
                @Html.Label("Roll", New With {.class = "col-md-2 control-label"})
                <div class="col-md-10">
                    @Html.DropDownListFor(Function(model) model.Kind, roles, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.Kind, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" class="btn btn-primary" value="Register" />
                </div>
            </div>

        </text>
    End Using
</div>

@section Scripts
    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/bundles/uniqueusername")
End Section
