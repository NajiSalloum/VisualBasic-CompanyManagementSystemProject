@ModelType DebitLinesPerUsersAndDebitLinesOverView
@Code
    ViewData("Title") = "DebiteratInfoPerCustomerName"
End Code
<div class="col-md-3" id="divUppföljningLinks">
    @Html.ActionLink("Debitering per dag", "")<br /><br />
    @Html.ActionLink("Försäljning per kund", "DebitLinePerCustomer", "DebitLines")<br /><br />
    @Html.ActionLink("Försäljning per projekt", "")<br /><br />
    @Html.ActionLink("Mina debiteringsrader", "MyDebitering", "DebitLines")<br /><br />
    @Html.ActionLink("Mina debiteringsrader per kund", "MyDebiteringPerCustomer", "DebitLines")<br /><br />
    @*@Html.ActionLink("Mina körjournal", "")<br /><br />*@
    @Html.ActionLink("Total debitering per konsult", "DebitLinePerUsers", "DebitLines")<br /><br />
    @Html.ActionLink("Total debitering per 12 månaders period", "")<br /><br />
</div>
<div class="col-md-9">
    <h2>Försäljning per kund</h2>

    <div class="navbar-left">
        @Using (Html.BeginForm("DebitLinePerUsers", "DebitLines", FormMethod.Get))
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
                @Html.Label("Konsult")
            </th>
            <th>
                @Html.Label("Total Försäljning")
            </th>
            <th>
                @Html.Label("Försäljning kund")
            </th>
            <th>
                @Html.Label("Intern debitering")
            </th>
            <th>
                @Html.Label("Övriga utlägg and kilometer")
            </th>
            <th>
                @Html.Label("Senaste debiterings datum")
            </th>
            <th>
                @Html.Label("Prognos")
            </th>
            <th>
                @Html.Label("Försäljning föregående år")
            </th>
            <th>
                @Html.Label("Skillnad")
            </th>
            <th></th>
        </tr>

        @For Each item In Model.DebitLinesPerUsers 
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.UserName)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.TotalSale)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.SaleCustomer)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.InternalDebiting)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.OtherExpencesAndKm)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.LastDateDebiting)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Forecast)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.SaleLastYear)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Difference)
                </td>
                <td>
                    @*@html.actionlink("edit", "edit", new with {.id = item.primarykey}) |
                        @html.actionlink("details", "details", new with {.id = item.primarykey}) |*@
                    @Html.ActionLink("Detaljerad info", "DebiteratInfoPerUserName", New With {.userName = item.UserName})
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
                    @Html.DisplayFor(Function(modelItem) item.Customer.CustName)
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
