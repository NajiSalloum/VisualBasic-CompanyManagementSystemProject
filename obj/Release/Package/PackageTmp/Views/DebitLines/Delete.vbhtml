@ModelType DebitLinesView
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Radera</h2>

<h3>Är du säker på att du vill radera dettta?</h3>
<div>

    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.Label("Kund")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Customer.CustName)
        </dd>

        <dt>
            @Html.Label("Projekt")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Project.ProjectName)
        </dd>

        <dt>
            @Html.Label("Deb datum")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DebDate)
        </dd>



        <dt>
            @Html.Label("Antal timmar")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NoOfHours)
        </dd>

        <dt>
            @Html.Label("Restid")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NoOfTravelHours)
        </dd>

        <dt>
            @Html.Label("Antal km")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NoOfKm)
        </dd>

        <dt>
            @Html.Label("Öveiga utlägg")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.OtherExpences)
        </dd>

        <dt>
            @Html.Label("Beskrivning")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>


        <dt>
            @Html.Label("DebDate")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DebDate)
        </dd>

        <dt>
            @Html.Label("Timpris")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PricePerHoure)
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
            @Html.Label("Provision")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Comission)
        </dd>
        @code
            If Model.Subscription <> 0 Then
        End Code
        <dt>
            @Html.Label("Abonnemang")
        </dt>

        <dd>
            @Html.Raw(ViewBag.SubsicriptionName)
        </dd>
        @code
            End If
        End Code
       




    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-danger" /> |
            @Html.ActionLink("Back to List", "AllCustomers", "Customers")
        </div>
    End Using
</div>
