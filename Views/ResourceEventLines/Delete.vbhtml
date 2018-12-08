@ModelType RecourseEventLine
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Radera</h2>

<h3>Är du säker på att du vill radera detta?</h3>
<div>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.Label("Händelse:")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ResourceEvent.EventName)
        </dd>

    
        <dt>
            @Html.Label("Användarnamn:")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.UserName)
        </dd>

        <dt>
            @Html.Label("Datum:")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.EventDate)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-danger"  /> |
            @Html.ActionLink("Back to List", "Create")
        </div>
    End Using
</div>
