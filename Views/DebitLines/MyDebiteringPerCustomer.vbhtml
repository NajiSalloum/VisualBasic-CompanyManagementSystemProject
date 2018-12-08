﻿@ModelType MyDebiterungPerCustomerView
@Code
    ViewData("Title") = "MyDebitering"
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
    <h2>Mina debiteringsrader</h2>

    <div class="navbar-left">
       

        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()

            @<div class="form-horizontal">
                
                <hr />
                @Html.ValidationSummary(True)
                <div class="form-group">
                    
                    <div class="col-md-10">
                        @Html.TextBoxFor(Function(model) model.FirstDate, New With {.class = "form-control datepicker"})
                        @Html.ValidationMessageFor(Function(model) model.FirstDate)
                    </div>
                    
                </div>
                 <div class="form-group">
                    
                     <div class="col-md-10">
                         @Html.TextBoxFor(Function(model) model.SecondDate, New With {.class = "form-control datepicker"})
                         @Html.ValidationMessageFor(Function(model) model.SecondDate)
                     </div>

                 </div>
                 <div class="form-group">
                      <div class="col-md-10">
                         @Html.DropDownListFor(Function(model) model.CustID, DirectCast(ViewData("Customers"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                         @Html.ValidationMessageFor(Function(model) model.CustID, "", New With {.class = "text-danger"})
                     </div>
                 </div>


                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <input type="submit" value="Visa" class="btn btn-primary"  />
                    </div>
                </div>
            </div>
        End Using

    </div>
    @*@Html.TextBoxFor(Function(model) model.FirstDate, New With {.class = "form-control datepicker"})*@
    <table class="table" id="tblMydebitering">
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

    <div class="alert alert-success">
        Total debiterat är  <strong>@ViewBag.TotalDebiterat</strong> kr, totalt  <strong>@ViewBag.TotalHours</strong>   timmar.
    </div>

</div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
    <script type="text/javascript">
    $(document).ready(function () {
        
        $('.datepicker').datepicker();
    });
</script>
End Section