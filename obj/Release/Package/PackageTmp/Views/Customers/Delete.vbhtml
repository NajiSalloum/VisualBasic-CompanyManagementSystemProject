@ModelType Customer
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Radera</h2>

<h3>Är du säker på att du vill radera dette?</h3>
<div>
    <h4>Customer</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Company.CompanyName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Company.CompanyName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PartnerLevel.PartnerLevelName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PartnerLevel.PartnerLevelName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PriceList.PriceListName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PriceList.PriceListName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Deleted)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Deleted)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.InternalCustomer)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.InternalCustomer)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ErpOrderByProject)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ErpOrderByProject)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ExtCustID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ExtCustID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Notes)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Notes)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NoOfTravelHour)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NoOfTravelHour)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CustName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CustName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CustRef)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CustRef)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PricePerHour)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PricePerHour)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.TravelPrice)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.TravelPrice)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PricePerKm)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PricePerKm)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-danger"  /> |
            @Html.ActionLink("Back to List", "AllCustomers")
        </div>
    End Using
</div>
