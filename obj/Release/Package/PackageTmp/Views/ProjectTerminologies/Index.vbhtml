@ModelType IEnumerable(Of ProjectTerminology)
@Code
ViewData("Title") = "Index"
End Code

<h2>Projekt</h2>

<p>
    @Html.ActionLink("Lägg till nytt projekt", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.Label("Namn")
        </th>
        <th>
            @Html.Label("Beskrivning")
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ProjectTerminologyName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ProjectTerminologyDescription)
        </td>
        <td>
            @Html.ActionLink("Ändra", "Edit", New With {.id = item.ProjectTerminologyID}) |
            @Html.ActionLink("Detaljer", "Details", New With {.id = item.ProjectTerminologyID}) |
            @Html.ActionLink("Radera", "Delete", New With {.id = item.ProjectTerminologyID})
        </td>
    </tr>
Next

</table>
