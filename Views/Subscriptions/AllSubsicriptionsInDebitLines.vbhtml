@ModelType IEnumerable(Of AllSubscriptionsInDebitLinesView)
@Code
    ViewData("Title") = "AllSubsicriptionsInDebitLines"
End Code

<h2>AllSubsicriptionsInDebitLines</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.Label("Abonnemang")
        </th>
        <th>
            @Html.Label("Kund")
        </th>
        <th>
            @Html.Label("Projekt")
        </th>
        <th>
            @Html.Label("Debiterat")
        </th>
        <th>
            @Html.Label("Timpris")
        </th>
        <th>
            @Html.Label("Provision")
        </th>
        <th>
            @Html.Label("Beskrivning")
        </th>
        <th>
            @Html.Label("Aktuell från")
        </th>
        <th>
            @Html.Label("Användarlåst")
        </th>
        <th>
            @Html.Label("Auto deb")
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.SubscriptionName)
            </td>

            <td>
                @Html.DisplayFor(Function(modelItem) item.Customer.CustName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Project.ProjectName)
            </td>

            <td>
                @Html.DisplayFor(Function(modelItem) item.NoOfHours)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.PricePerHour)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Commission)
            </td>

            <td>
                @Html.DisplayFor(Function(modelItem) item.Description)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.StartDate)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.LockedToUser)
            </td>

            <td>
                @Html.DisplayFor(Function(modelItem) item.AutoDeb)
            </td>
            <td>
                @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
                    @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
                    @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
            </td>
        </tr>
    Next

</table>
