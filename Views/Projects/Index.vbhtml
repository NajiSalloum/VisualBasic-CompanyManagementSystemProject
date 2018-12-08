@ModelType IEnumerable(Of Project)
@Code
ViewData("Title") = "Index"
End Code

<h2>Projekt</h2>
<table class="table">
    <tr>
        <th>
            @Html.Label("Kund")
        </th>
        <th>
            @Html.Label("Projekt")
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Customer.CustName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ProjectName)
        </td>
        <td>
            @*@Html.ActionLink("Edit", "Edit", New With {.id = item.ProjectID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ProjectID }) |*@
            @Html.ActionLink("Ändra", "Edit", New With {.id = item.ProjectID})
        </td>
    </tr>
Next

</table>
