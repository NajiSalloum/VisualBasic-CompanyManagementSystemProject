@ModelType DebitLinesPerCustomersAndDebitLinesOverView
@Code
    ViewData("Title") = "DebiteratInfoPerCustomerName"
End Code
<div class="col-md-3" id="divUppföljningLinks">
    @Html.ActionLink("Debitering per dag", "")<br /><br />
    @Html.ActionLink("Försäljning per kund", "DebitLinePerCustomer", "DebitLines")<br /><br />
    @Html.ActionLink("Försäljning per projekt", "")<br /><br />
    @Html.ActionLink("Mina debiteringsrader", "MyDebitering", "DebitLines")<br /><br />
    @Html.ActionLink("Mina debiteringsrader per kund", "")<br /><br />
    @*@Html.ActionLink("Mina körjournal", "")<br /><br />*@
    @Html.ActionLink("Total debitering per konsult", "DebitLinePerUserName", "DebitLines")<br /><br />
    @Html.ActionLink("Total debitering per 12 månaders period", "")<br /><br />
</div>
<div class="col-md-9">
    <h2>Försäljning per kund</h2>

    <div class="navbar-left">
        @Using (Html.BeginForm("DebitLinePerCustomer", "DebitLines", FormMethod.Get))
            @<div class="form-inline">
                <ul class="nav navbar">
                    <li>
                        @Html.DropDownList("years", Nothing, New With {.class = "form-control"})@Html.DropDownList("months", Nothing, New With {.class = "form-control"})
                        <input type="submit" value="Visa" class="btn btn-primary" />
                    </li>


                </ul>
            </div>
        End Using
    </div>

    <table class="table">
        <tr>
            <th>
                @Html.Label("Kund")
            </th>
            <th>
                @Html.Label("År")
            </th>
            <th>
                @Html.Label("Månad")
            </th>
            <th>
                @Html.Label("Total försäljning")
            </th>
            <th>
                @Html.Label("Total försäljning och resor")
            </th>
            <th></th>
        </tr>

        @For Each item In Model.DebitLinesPerCustomers
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.CustName)
                </td>
                 <td>
                     @Html.DisplayFor(Function(modelItem) item.Year)
                 </td>
                 <td>
                     @Html.DisplayFor(Function(modelItem) item.Month)
                 </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.TotalDebiterat)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.TotalDebiteratAndTravilPrice)
                </td>
                <td>
                    @Html.ActionLink("Detaljerad info", "DebiteratInfoPerCustomerName", New With {.id = item.CustomerID})
                    @*@Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
                        @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
                </td>
            </tr>
        Next

    </table>


    <table class="table">
        <tr>

            <th>
                @Html.Label("Datum")
            </th>
            <th>
                @Html.Label("Kund")
            </th>
            <th>
                @Html.Label("Konsult")
            </th>
            <th>
                @Html.Label("Antal timmar")
            </th>
            <th>
                @Html.Label("Restid")
            </th>
            <th>
                @Html.Label("Antal km")
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
                @Html.Label("Totalt debiterat")
            </th>
            <th></th>
        </tr>

        @For Each item In Model.DebitLines
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.DebDate)
                </td>
                 <td>
                     @Html.DisplayFor(Function(modelItem) item.Customer.CustName )
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
                    @Html.DisplayFor(Function(modelItem) item.LineTotal)
                </td>
                <td>
            </tr>
        Next

        </table>
</div>
