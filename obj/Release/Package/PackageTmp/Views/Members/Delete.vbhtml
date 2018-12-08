@ModelType UserView
@Code
    ViewData("Title") = "Delete"
End Code
<div class="jumbotron">
    <h2>Radera</h2>

    <h3>Är du säker på att du vill radera detta?</h3>
    <div>

        <hr />
        <dl class="dl-horizontal">
            <dt>
                @Html.DisplayNameFor(Function(model) model.UserName)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.UserName)
            </dd>


        </dl>
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()

            @<div class="form-actions no-color">
                <input type="submit" value="Delete" class="btn btn-danger"  /> |
                @Html.ActionLink("Back to List", "AllUsers")
            </div>
        End Using
    </div>
</div>