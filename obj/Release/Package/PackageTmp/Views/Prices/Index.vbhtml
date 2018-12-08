@ModelType IEnumerable(Of Price)
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
            @Html.DisplayNameFor(Function(model) model.PriceList.PriceListName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.User.UserName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PricePerHour)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TravelPrice)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PricePerKm)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Commission)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PriceList.PriceListName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.User.UserName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PricePerHour)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.TravelPrice)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PricePerKm)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Commission)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.PriceID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.PriceID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.PriceID })
        </td>
    </tr>
Next

</table>
