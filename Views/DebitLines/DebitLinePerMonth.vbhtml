@ModelType IEnumerable(Of DebitLinePerMonthView)
@Code
ViewData("Title") = "DebitLinePerMonth"
End Code

<h2>DebitLinePerMonth</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.UserName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Month)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TotalPerMonth)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.UserName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Month)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.TotalPerMonth)
        </td>
        <td>
            @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
            @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
        </td>
    </tr>
Next

</table>
