@ModelType Price
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Radera</h2>

<h3>Är du säker på att du vill radera detta?</h3>
<div>
    
    <hr />
    <dl class="dl-horizontal">
        

        <dt>
            @Html.Label("Användarnamn")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.User.UserName)
        </dd>
        <dt>
            @Html.Label("Prislista")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PriceList.PriceListName)
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
           @Html.Label("Provision")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Commission)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Radera" class="btn btn-danger"  /> 
           
        </div>
        
    End Using
    <br />
    <div>
        <a href='javascript:history.go(-1)'>Tillbaka</a>
    </div>

</div>
