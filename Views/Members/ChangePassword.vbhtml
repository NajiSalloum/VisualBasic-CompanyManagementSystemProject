@ModelType UserView
@Code
    ViewData("Title") = "ChangePassword"
End Code
<div class="jumbotron">
<h2>Byta lösenord</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        
        <hr />
        @Html.ValidationSummary(true)
        @Html.HiddenFor(Function(model) model.Id)

        <div class="form-group">
            @Html.Label("Användarnamn", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DisplayFor(Function(model) model.UserName)
                @Html.ValidationMessageFor(Function(model) model.UserName)
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Lösenord", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Password)
                @Html.ValidationMessageFor(Function(model) model.Password)
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Bekräfta", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.ConfirmPassword)
                @Html.ValidationMessageFor(Function(model) model.ConfirmPassword)
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
</div>