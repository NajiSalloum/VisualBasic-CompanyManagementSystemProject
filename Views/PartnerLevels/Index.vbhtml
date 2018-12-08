@ModelType IEnumerable(Of PartnerLevel)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.PartnerLevelName)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PartnerLevelName)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.PartnerLevelID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.PartnerLevelID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.PartnerLevelID })
        </td>
    </tr>
Next

</table>
