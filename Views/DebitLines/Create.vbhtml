@ModelType CreateAndAllSubscriptionInDebitLinesView
@Code
    ViewData("Title") = "Create"
End Code
<div id="JUM">


    <h2>Registrera Arbetad Tid</h2>

    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-horizontal">

            <hr />
            @Html.ValidationSummary(True)
            <div class="form-group">
                @Html.LabelFor(Function(model) model.DebitLine.DebDate, New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    
                    @Html.TextBoxFor(Function(model) model.DebitLine.DebDate, New With {.class = "form-control datepicker"})
                    @Html.ValidationMessageFor(Function(model) model.DebitLine.DebDate)
                </div>
            </div>

            <div class="form-group hidden">
                @Html.LabelFor(Function(model) model.DebitLine.UserName, New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.DebitLine.UserName)
                    @Html.ValidationMessageFor(Function(model) model.DebitLine.UserName)
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Kund Name", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownListFor(Function(model) model.DebitLine.CustomerID, DirectCast(ViewData("Customers"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.DebitLine.CustomerID, "", New With {.class = "text-danger"})
                </div>
            </div>



            <div class="form-group">
                @Html.Label("Antal Timmar", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.DebitLine.NoOfHours, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.DebitLine.NoOfHours)
                </div>
            </div>
            <div class="form-group">
                @Html.Label("Provision", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.DebitLine.Comission)
                    @Html.ValidationMessageFor(Function(model) model.DebitLine.Comission)
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Restid", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.DebitLine.NoOfTravelHours)
                    @Html.ValidationMessageFor(Function(model) model.DebitLine.NoOfTravelHours)
                </div>
            </div>
            <div class="form-group">
                @Html.Label("Övriga Utlägg", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.DebitLine.OtherExpences)
                    @Html.ValidationMessageFor(Function(model) model.DebitLine.OtherExpences)
                </div>
            </div>


            <div class="form-group">
                @Html.Label("Antal Km", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.DebitLine.NoOfKm)
                    @Html.ValidationMessageFor(Function(model) model.DebitLine.NoOfKm)
                </div>
            </div>


            <div class="form-group">
                @Html.Label("Projekt", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownListFor(Function(model) model.DebitLine.ProjectID, DirectCast(ViewData("Projects"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.DebitLine.ProjectID, "", New With {.class = "text-danger"})
                    @Html.ActionLink("Lägg till nytt projekt", "AddCustomerToProject", "Projects", New With {.id = Url.RequestContext.RouteData.Values("id")}, Nothing)
                    <br />
                    <span id="TextErrorMessage" class="text-danger hidden">Inget Projekt kopplat till kunden!!!</span>
                </div>

            </div>
            <div class="form-group">
                @Html.Label("Beskrivning", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.TextAreaFor(Function(model) model.DebitLine.Description, New With {.Placeholder = "Beskrivning..."})
                    @Html.ValidationMessageFor(Function(model) model.DebitLine.Description)
                </div>
            </div>

            <div class="form-group hidden">
                @Html.LabelFor(Function(model) model.DebitLine.Invoiced, New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.DebitLine.Invoiced)
                    @Html.ValidationMessageFor(Function(model) model.DebitLine.Invoiced)
                </div>
            </div>

            <div class="form-group hidden">
                @Html.LabelFor(Function(model) model.DebitLine.Regesterad, New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.DebitLine.Regesterad)
                    @Html.ValidationMessageFor(Function(model) model.DebitLine.Regesterad)
                </div>
            </div>

            <div class="form-group hidden">
                @Html.LabelFor(Function(model) model.DebitLine.PricePerHoure, New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.DebitLine.PricePerHoure)
                    @Html.ValidationMessageFor(Function(model) model.DebitLine.PricePerHoure)
                </div>
            </div>

            <div class="form-group hidden">
                @Html.LabelFor(Function(model) model.DebitLine.TravelPrice, New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.DebitLine.TravelPrice)
                    @Html.ValidationMessageFor(Function(model) model.DebitLine.TravelPrice)
                </div>
            </div>

            <div class="form-group hidden">
                @Html.LabelFor(Function(model) model.DebitLine.PricePerKm, New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.DebitLine.PricePerKm)
                    @Html.ValidationMessageFor(Function(model) model.DebitLine.PricePerKm)
                </div>
            </div>

            <div class="form-group hidden">
                @Html.LabelFor(Function(model) model.DebitLine.Status, New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.DebitLine.Status)
                    @Html.ValidationMessageFor(Function(model) model.DebitLine.Status)
                </div>
            </div>



            <div class="form-group hidden">
                @Html.LabelFor(Function(model) model.DebitLine.Subscription, New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.DebitLine.Subscription)
                    @Html.ValidationMessageFor(Function(model) model.DebitLine.Subscription)
                </div>
            </div>

            <div class="form-group hidden">
                @Html.LabelFor(Function(model) model.DebitLine.CompanyCar, New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.DebitLine.CompanyCar)
                    @Html.ValidationMessageFor(Function(model) model.DebitLine.CompanyCar)
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="Registrera" class="btn btn-primary" />
                </div>
            </div>
        </div>
    End Using
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
                @Html.Label("Antal timmar")
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

        @For Each item In Model.AllSubscriptionsInDebitLine
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
                    @Html.DisplayFor(Function(modelItem) item.Debiterad)
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
                    @Html.ActionLink("Välj", "Create", New With {.idSub = item.SubscriptionID}) 
                    @*|@Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
    @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})**@
                </td>
            </tr>
        Next

    </table>
    <div>
        @Html.ActionLink("Lägg till abonnemang", "Create", "Subscriptions", New With {.id = Url.RequestContext.RouteData.Values("id")}, Nothing)
    </div>
    <div>
        @Html.ActionLink("Tillbaka", "AllCustomers", "Customers")
    </div>
</div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/bundles/RegisterDebitLineProjectValidations")
End Section


