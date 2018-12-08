@ModelType IEnumerable(Of AllResourceEventLinesView)
@Code
ViewData("Title") = "AllResourceEventLines"
End Code

<h2>Tillgänglighet</h2>

<p>
    @Html.ActionLink("Registrera tillgänglighet", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.Label("Datum")
        </th>
        <th>
            @Html.Label("Användarnamn")
        </th>

        <th>
            @Html.Label("Händelse")
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
         <td>
             @Html.DisplayFor(Function(modelItem) item.EventDate)
         </td>

        <td>
            @Html.DisplayFor(Function(modelItem) item.UserName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ResourceEventName)
        </td>
        <td>
            @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
            @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |*@
            @Html.ActionLink("Radera", "Delete", New With {.id = item.RecourseEventLineID})
        </td>
    </tr>
Next

</table>
