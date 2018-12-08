@ModelType IEnumerable(Of DebitLinePerCustomerView)
@Code
ViewData("Title") = "DebitLinePerCustomer"
End Code
<div class="col-md-3" id="divUppföljningLinks" >
    @Html.ActionLink("Debitering per dag", "")<br /><br />
    @Html.ActionLink("Försäljning per kund", "DebitLinePerCustomer", "DebitLines")<br /><br />
    @Html.ActionLink("Försäljning per projekt", "")<br /><br />
    @Html.ActionLink("Mina debiteringsrader", "MyDebitering", "DebitLines")<br /><br />
    @Html.ActionLink("Mina debiteringsrader per kund", "")<br /><br />
    @*@Html.ActionLink("Mina körjournal", "")<br /><br />*@
    @Html.ActionLink("Total debitering per konsult", "DebitLinePerUserName", "DebitLines")<br /><br />
    @Html.ActionLink("Total debitering per 12 månaders period", "")<br /><br />
</div>
<div class="col-md-9" >
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

@For Each item In Model
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
            @Html.ActionLink("Detaljerad info", "DebiteratInfoPerCustomerName", "DebitLines", New With {.id = item.CustomerID}, Nothing)
            @*@Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
        </td>
    </tr>
Next

</table>
</div>