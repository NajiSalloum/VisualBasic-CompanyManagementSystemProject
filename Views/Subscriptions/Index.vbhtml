@ModelType IEnumerable(Of Subscription)
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
            @Html.DisplayNameFor(Function(model) model.PeriodType.PeriodTypeName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Project.ProjectName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.UserName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NoOfHours)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PricePerHour)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.RegisteredDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LastInvoiced)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LockedToUser)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.StartDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.AutoDeb)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Commission)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Customer.ExtCustID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PeriodType.PeriodTypeName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Project.ProjectName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.UserName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NoOfHours)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PricePerHour)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.RegisteredDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Description)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.LastInvoiced)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.LockedToUser)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.StartDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.AutoDeb)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Commission)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.SubscriptionID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.SubscriptionID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.SubscriptionID })
        </td>
    </tr>
Next

</table>
