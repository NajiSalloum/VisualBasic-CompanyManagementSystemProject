@ModelType AddAndAllSubscriptionsView
@Code
    ViewData("Title") = "Create"
End Code

<h2>Lägg till nytt abonnemang</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <hr />
        @Html.ValidationSummary(True)
      
        <div class="form-group">
            <div class="col-md-1">

            </div>
            <div class="col-md-1" >
                @Html.DisplayFor(Function(model) model.Subscription.Customer.CustName)
            </div>
            <div class="col-md-10">
                
                @Html.ActionLink("Registrera arbetad tid", "Create", "DebitLines", New With {.id = Url.RequestContext.RouteData.Values("id")}, Nothing)     
                @Html.ValidationMessageFor(Function(model) model.Subscription.Customer.CustName)
            </div>
        </div>
         <div class="form-group">
             @Html.Label("Kund Name:", New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.DropDownListFor(Function(model) model.Subscription.CustomerID, DirectCast(ViewData("Customers"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(model) model.Subscription.CustomerID, "", New With {.class = "text-danger"})
             </div>
         </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Subscription.StartDate, New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.Subscription.StartDate, New With {.class = "form-control datepicker"})
                @Html.ValidationMessageFor(Function(model) model.Subscription.StartDate)
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Projekt:", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.Subscription.ProjectID, DirectCast(ViewData("Projects"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.Subscription.ProjectID, "", New With {.class = "text-danger"})
                @Html.ActionLink("Lägg till nytt projekt", "AddCustomerToProjectAndBackToSubscription", "Projects", New With {.id = Model.Subscription.CustomerID}, Nothing)
                <br />
                <span id="TextErrorMessage" class="text-danger hidden">Inget Projekt kopplat till kunden!!!</span>
            </div>

        </div>

        

        <div class="form-group">
            @Html.Label("Intervall:", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.Subscription.PeriodTypeID, DirectCast(ViewData("PeriodTypes"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.Subscription.PeriodTypeID, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group hidden">
            @Html.LabelFor(Function(model) model.Subscription.UserName, New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Subscription.UserName)
                @Html.ValidationMessageFor(Function(model) model.Subscription.UserName)
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Antal timmar:", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Subscription.NoOfHours)
                @Html.ValidationMessageFor(Function(model) model.Subscription.NoOfHours)
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Timpris", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Subscription.PricePerHour)
                @Html.ValidationMessageFor(Function(model) model.Subscription.PricePerHour)
            </div>
        </div>

        <div class="form-group hidden">
            @Html.LabelFor(Function(model) model.Subscription.RegisteredDate, New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Subscription.RegisteredDate)
                @Html.ValidationMessageFor(Function(model) model.Subscription.RegisteredDate)
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Beskrivning:", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextAreaFor(Function(model) model.Subscription.Description, New With {.Placeholder = "Beskrivning...."})
                @Html.ValidationMessageFor(Function(model) model.Subscription.Description)
            </div>
        </div>

        <div class="form-group hidden">
            @Html.LabelFor(Function(model) model.Subscription.LastInvoiced, New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Subscription.LastInvoiced)
                @Html.ValidationMessageFor(Function(model) model.Subscription.LastInvoiced)
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Låst till användare:", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Subscription.LockedToUser)
                @Html.ValidationMessageFor(Function(model) model.Subscription.LockedToUser)
            </div>
        </div>


        <div class="form-group hidden">
            @Html.Label("Auto Deb:", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Subscription.AutoDeb)
                @Html.ValidationMessageFor(Function(model) model.Subscription.AutoDeb)
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Provision:", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Subscription.Commission)
                @Html.ValidationMessageFor(Function(model) model.Subscription.Commission)
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Lägg till" class="btn btn-primary" />
            </div>


        </div>


    </div>

End Using
<table class="table">
    <tr>
        <th>
            @Html.Label("Projekt")
        </th>
        <th>
            @Html.Label("Kund")
        </th>
        <th>
            @Html.Label("Inervall")
        </th>
        <th>
            @Html.Label("Registrerad av")
        </th>
        <th>
            @Html.Label("Antal Timmar")
        </th>
        <th>
            @Html.Label("Timpris")
        </th>
        <th>
            @Html.Label("Registrerad")
        </th>
        <th>
            @Html.Label("Beskrivning")
        </th>
        <th>
            @Html.Label("Nästa debitering")
        </th>
        <th>
            @Html.Label("Låst till användare")
        </th>
        <th>
            @Html.Label("Startdatum")
        </th>
        <th>
            @Html.Label("Auto deb")
        </th>
        <th>
            @Html.Label("Provision")
        </th>
        <th></th>
    </tr>

    @For Each item In Model.AllSubscriptions
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Project.ProjectName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Customer.CustName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.PeriodType.PeriodTypeName)
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
                @Html.ActionLink("Ändra", "Edit", New With {.id = item.SubscriptionID}) |
                @*@Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |*@
                @Html.ActionLink("Radera", "Delete", New With {.id = item.SubscriptionID})
            </td>
        </tr>
    Next

</table>

<div>
    <a href='javascript:history.go(-1)'>Tillbaka</a>
</div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/bundles/SubscriptionValidations")
End Section