@ModelType Customer
@Code
    ViewData("Title") = "Details"
End Code
    <h2>Detaljer</h2>

    <div>

        <hr />
        <dl class="dl-horizontal">
            <dt>
                @Html.Label("Koplat bolag")
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.Company.CompanyName)
            </dd>
            @code
                If Model.PartnerLevelID IsNot Nothing Then
            End Code
            <dt>
                @Html.Label("Partners nivå")
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.PartnerLevel.PartnerLevelName)
            </dd>
            @Code
            End If

            End Code
            @code
                If Model.PartnerLevelID Is Nothing Then
            End Code
            <dt>
                @Html.Label("Kopplat Partner")
            </dt>

            <dd>
                @Html.Raw(ViewBag.KopplatPartnerName)
            </dd>
            @Code
                End If

            End Code
            
            

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
            <dt>
                @Html.Label("Antal km")
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.NoOfKm)
            </dd>

        </dl>
    </div>
    <p>
        @Html.ActionLink("Ändra", "Edit", New With {.id = Model.CustomerID}) |
        <a href='javascript:history.go(-1)'>Tillbaka</a>
    </p>
