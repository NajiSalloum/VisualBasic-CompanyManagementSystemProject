@ModelType CreateAndAllPricesView 

@Code
    ViewData("Title") = "Create"
End Code

    <h2>Registrera</h2>

    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-horizontal">
            
            <hr />
            @Html.ValidationSummary(True)
            <div class="form-group">
                @Html.Label("Prislista:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownListFor(Function(model) model.Price.PriceListID, DirectCast(ViewData("Prices"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.Price.PriceListID, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.Label("Prislista:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownListFor(Function(model) model.Price.UserID, DirectCast(ViewData("Users"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.Price.UserID, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Price.PricePerHour, New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Price.PricePerHour)
                    @Html.ValidationMessageFor(Function(model) model.Price.PricePerHour)
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Price.TravelPrice, New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Price.TravelPrice)
                    @Html.ValidationMessageFor(Function(model) model.Price.TravelPrice)
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Price.PricePerKm, New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Price.PricePerKm)
                    @Html.ValidationMessageFor(Function(model) model.Price.PricePerKm)
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Price.Commission, New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Price.Commission)
                    @Html.ValidationMessageFor(Function(model) model.Price.Commission)
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="Create" class="btn btn-primary"  />
                </div>
            </div>
        </div>
    End Using
    <table class="table">
        <tr>
            <th>
                @Html.Label("Prislista")
            </th>
            <th>
                @Html.Label("Användarnamn")
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
            <th></th>
        </tr>

        @For Each item In Model.AllPrices 
            @<tr>

                <td>
                    @Html.DisplayFor(Function(modelItem) item.PriceList.PriceListName)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.User.UserName)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.PricePerHour)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.TravelPrice)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.PricePerKm)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Commission)
                </td>
                <td>
                    @*@Html.ActionLink("edit", "edit", New With {.id = item.primarykey}) |
                        @Html.ActionLink("details", "details", New With {.id = item.primarykey}) |*@
                    @Html.ActionLink("Radera", "delete", New With {.id = item.PriceID})
                </td>
            </tr>
        Next

    </table>

    <div>
        @Html.ActionLink("Back to List", "AllPrices")
    </div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
