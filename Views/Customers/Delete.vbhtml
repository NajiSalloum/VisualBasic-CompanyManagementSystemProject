@ModelType Customer
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Radera</h2>

<h3>Är du säker på att du vill radera dette?</h3>
<div>

    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.Label("Koplat bolag")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Company.CompanyName)
        </dd>


        <dt>
            @Html.Label("Prislista")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PriceList.PriceListName)
        </dd>



        <dt>
            @Html.Label("Internalkund?")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.InternalCustomer)
        </dd>

        <dt>
            @Html.Label("Erp order per projekt?")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ErpOrderByProject)
        </dd>

        <dt>
            @Html.Label("Kopplat kund id")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ExtCustID)
        </dd>

        <dt>
            @Html.Label("Nots")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Notes)
        </dd>

        <dt>
            @Html.Label("Restid")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NoOfTravelHour)
        </dd>

        <dt>
            @Html.Label("Kund namn")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CustName)
        </dd>

        <dt>
            @Html.Label("Referens")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CustRef)
        </dd>

        <dt>
            @Html.Label("Timpris")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PricePerHour)
        </dd>

        <dt>
            @Html.Label("Timpris resa")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.TravelPrice)
        </dd>

        <dt>
            @Html.Label("Km pris")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PricePerKm)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-danger" />
        </div>
    End Using
</div>
<br />
<div>
    @Html.ActionLink("Tillbaka", "AllCustomers")
</div>
