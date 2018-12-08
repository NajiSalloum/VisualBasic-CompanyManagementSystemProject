@ModelType Customer
@Code
    ViewData("Title") = "Edit"
End Code
    <h2>Redigera</h2>

    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-horizontal">

            <hr />
            @Html.ValidationSummary(True)
            @Html.HiddenFor(Function(model) model.CustomerID)

            <div class="form-group">
                @Html.Label("Prislista:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownList("PriceListID", String.Empty)
                    @Html.ValidationMessageFor(Function(model) model.PriceListID)
                </div>
                <span id="TextErrorMessagePrice" class="text-danger hidden">du måste välja en prislista!!!</span>
            </div>

            <div class="form-group">
                @Html.Label("Kopplat Bolag:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownList("CompanyID", String.Empty)
                    @Html.ValidationMessageFor(Function(model) model.CompanyID)
                </div>
                <span id="TextErrorMessage" class="text-danger hidden">du måste välja ett bolag!!!</span>
            </div>
            <div class="form-group">
                @Html.Label("Is A Partner?:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.IsAPartner)
                    @Html.ValidationMessageFor(Function(model) model.IsAPartner)
                </div>
            </div>



            <div class="form-group hidden" id="PartnerLevelDropDownList">
                @Html.Label("Partner Nivå:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownList("PartnerLevelID", String.Empty)
                    @Html.ValidationMessageFor(Function(model) model.PartnerLevelID)
                </div>
                <span id="TextErrorMessagePartner" class="text-danger hidden">du måste välja en partnernivå!!!</span>
            </div>
            
            
             <div class="form-group" id="KopplatPartnrtDropdownList">
                 @Html.LabelFor(Function(model) model.KopplatPartnerID, htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div class="col-md-10">
                     @Html.DropDownListFor(Function(model) model.KopplatPartnerID, DirectCast(ViewData("KopplatPartner"), IEnumerable(Of SelectListItem)), "Välj", New With {.class = "form-control"})
                     @Html.ValidationMessageFor(Function(model) model.KopplatPartnerID, "", New With {.class = "text-danger"})
                 </div>
             </div>

            <div class="form-group hidden">
                @Html.LabelFor(Function(model) model.Deleted, New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Deleted)
                    @Html.ValidationMessageFor(Function(model) model.Deleted)
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Internalkund?:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.InternalCustomer)
                    @Html.ValidationMessageFor(Function(model) model.InternalCustomer)
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.ErpOrderByProject, New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.ErpOrderByProject)
                    @Html.ValidationMessageFor(Function(model) model.ErpOrderByProject)
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Kopplat Kund ID:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.ExtCustID)
                    @Html.ValidationMessageFor(Function(model) model.ExtCustID)
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Notes, New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Notes)
                    @Html.ValidationMessageFor(Function(model) model.Notes)
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Restid", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.NoOfTravelHour)
                    @Html.ValidationMessageFor(Function(model) model.NoOfTravelHour)
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Kund Namn:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.CustName)
                    @Html.ValidationMessageFor(Function(model) model.CustName)
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Referens:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.CustRef)
                    @Html.ValidationMessageFor(Function(model) model.CustRef)
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Timpris:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.PricePerHour)
                    @Html.ValidationMessageFor(Function(model) model.PricePerHour)
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Timpris Resa:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.TravelPrice)
                    @Html.ValidationMessageFor(Function(model) model.TravelPrice)
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Km Pris:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.PricePerKm)
                    @Html.ValidationMessageFor(Function(model) model.PricePerKm)
                </div>
            </div>
            <div class="form-group">
                @Html.Label("Antal Km:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.NoOfKm)
                    @Html.ValidationMessageFor(Function(model) model.NoOfKm)
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="Save" class="btn btn-success" />
                </div>
            </div>
        </div>
    End Using

    <div>
        @Html.ActionLink("Back to List", "AllCustomers")
    </div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/bundles/dropdownlistvalidations")
    @Scripts.Render("~/bundles/editpartnervalidations")
End Section
