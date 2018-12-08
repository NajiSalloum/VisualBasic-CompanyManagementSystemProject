@ModelType IEnumerable(Of DebitLine)
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
            @Html.DisplayNameFor(Function(model) model.Customer.ExtCustID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Project.ProjectName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DebDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.UserName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NoOfHours)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NoOfTravelHours)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NoOfKm)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.OtherExpences)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Invoiced)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Regesterad)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PricePerHoure)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TravelPrice)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PricePerKm)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Status)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Comission)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Subscription)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CompanyCar)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Customer.ExtCustID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Project.ProjectName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.DebDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.UserName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NoOfHours)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NoOfTravelHours)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NoOfKm)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.OtherExpences)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Description)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Invoiced)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Regesterad)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PricePerHoure)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.TravelPrice)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PricePerKm)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Status)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Comission)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Subscription)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CompanyCar)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.LineID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.LineID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.LineID })
        </td>
    </tr>
Next

</table>
