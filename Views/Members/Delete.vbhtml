@ModelType UserView
@Code
    ViewData("Title") = "Delete"
End Code
    <h2>Radera</h2>

    <h3>Är du säker på att du vill radera detta?</h3>
    <div>

        <hr />
        <dl class="dl-horizontal">
            <dt>
                @Html.Label("Användarnamn")
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.UserName)
            </dd>


        </dl>
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()

            @<div class="form-actions no-color">
                <input type="submit" value="Radera" class="btn btn-danger"  />
                
            </div>
        End Using
    </div>
<br />
<br />
<div>
    @Html.ActionLink("Tillbaka", "AllUsers")
</div>