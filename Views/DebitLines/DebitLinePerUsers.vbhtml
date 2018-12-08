@ModelType IEnumerable(Of DebitLinePerUsersView)
@Code
    ViewData("Title") = "DebitLinePerUserName"
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
    <h2>Total debitering per konsult</h2>

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

        @For Each item In Model
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
</div>