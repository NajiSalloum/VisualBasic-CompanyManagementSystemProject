@ModelType IEnumerable(Of DebitLinesOverview)
@Code
    ViewData("Title") = "DebitLinesOverview"
End Code

<h2>Översikt</h2>



<table class="table">
    <tr>


        <th>
            @Html.Label("Kund")
        </th>
        <th>
            @Html.Label("Antal timmar")
        </th>
        <th>
            @Html.Label("Restid")
        </th>
        <th>
            @Html.Label("Antal Km")
        </th>
        <th>
            @Html.Label("Övriga utlägg")
        </th>
        <th>
            @Html.Label("Projekt")
        </th>
        <th>
            @Html.Label("Beskrivning")
        </th>
        <th>
            @Html.Label("Timpris")
        </th>
        <th>
            @Html.Label("Timpris resa")
        </th>
        <th>
            @Html.Label("Km pris")
        </th>
        <th>
            @Html.Label("Provision")
        </th>
        <th>
            @Html.Label("Total")
        </th>

        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Customer.CustName)
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
                @Html.DisplayFor(Function(modelItem) item.Project.ProjectName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Description)
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
                @Html.DisplayFor(Function(modelItem) item.Comission)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.LineTotal)   kr
            </td>

            <td>
                @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
                    @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
                    @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
            </td>
        </tr>
    Next

</table>
<div class="alert alert-success">
    Total debiterat för  <strong>@ViewBag.theDate</strong>   är   <strong>@ViewBag.totalDebiterat</strong>   kr
</div>
