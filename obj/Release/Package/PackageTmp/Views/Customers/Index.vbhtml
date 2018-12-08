@ModelType IEnumerable(Of Customer)
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
            @Html.DisplayNameFor(Function(model) model.Company.CompanyName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PartnerLevel.PartnerLevelName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PriceList.PriceListName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Deleted)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.InternalCustomer)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ErpOrderByProject)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ExtCustID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Notes)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NoOfTravelHour)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CustName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CustRef)
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
            @Html.DisplayNameFor(Function(model) model.NoOfKm)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Company.CompanyName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PartnerLevel.PartnerLevelName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PriceList.PriceListName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Deleted)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.InternalCustomer)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ErpOrderByProject)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ExtCustID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Notes)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NoOfTravelHour)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CustName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CustRef)
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
             @Html.DisplayFor(Function(modelItem) item.NoOfKm )
         </td>

        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.CustomerID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.CustomerID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.CustomerID })
        </td>
    </tr>
Next

</table>
