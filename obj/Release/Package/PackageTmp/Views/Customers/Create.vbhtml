@ModelType Customer
@Code
    ViewData("Title") = "Create"
End Code


    <h2>Lägg till ny kund</h2>

    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-horizontal">

            <hr />
            @Html.ValidationSummary(True)
            <div class="form-group">
                @Html.Label("Kund Namn:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.CustName)
                    @Html.ValidationMessageFor(Function(model) model.CustName)
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Prislista:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownListFor(Function(model) model.PriceListID, DirectCast(ViewData("Prices"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.PriceListID, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Kopplat Bolag:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownListFor(Function(model) model.CompanyID, DirectCast(ViewData("Companies"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.CompanyID, "", New With {.class = "text-danger"})
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
                    @Html.EditorFor(Function(model) model.TravelPrice, New With {.type = "number", .step = "1"})
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




            <div class="form-group hidden">
                @Html.LabelFor(Function(model) model.Deleted, New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Deleted)
                    @Html.ValidationMessageFor(Function(model) model.Deleted)
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Internal Kund:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.InternalCustomer)
                    @Html.ValidationMessageFor(Function(modsel) Model.InternalCustomer)
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Erp Order By Project:", New With {.class = "control-label col-md-2 textForLabel"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.ErpOrderByProject)
                    @Html.ValidationMessageFor(Function(model) model.ErpOrderByProject)
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Kopplar Kund ID:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.ExtCustID)
                    @Html.ValidationMessageFor(Function(model) model.ExtCustID)
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Nots:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.TextAreaFor(Function(model) model.Notes)
                    @Html.ValidationMessageFor(Function(model) model.Notes)
                </div>
            </div>
            <div class="form-group" id="divIsAPartner">
                @Html.Label("Är En Partner?:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.CheckBox("isAPartner", False)
                    @Html.ValidationMessageFor(Function(model) model.Notes)
                </div>
            </div>
             
            @*<div class="form-group hidden" id="PartnerDropdownList">
                    @Html.Label("Partner Level:", New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("PartnerLevelID", "--Select--")
                        @Html.ValidationMessageFor(Function(model) model.PartnerLevelID)
                    </div>
                </div>*@
            <div class="form-group hidden" id="PartnerDropdownList">
                @Html.LabelFor(Function(model) model.PartnerLevelID, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownListFor(Function(model) model.PartnerLevelID, DirectCast(ViewData("PartnerLevels"), IEnumerable(Of SelectListItem)), "Välj", New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.PartnerLevelID, "", New With {.class = "text-danger"})
                </div>
            </div>

             <div class="form-group" id="divKopplatPartner">
                 @Html.Label("Kopplat Partner?:", New With {.class = "control-label col-md-2"})
                 <div class="col-md-10">
                     @Html.CheckBox("KopplatPartner", False)
                     @Html.ValidationMessageFor(Function(model) model.Notes)
                 </div>
             </div>
            <div class="form-group hidden" id="KopplatPartnrtDropdownList">
                @Html.LabelFor(Function(model) model.KopplatPartnerID, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownListFor(Function(model) model.KopplatPartnerID, DirectCast(ViewData("KopplatPartner"), IEnumerable(Of SelectListItem)), "Välj", New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.KopplatPartnerID, "", New With {.class = "text-danger"})
                </div>
            </div>



            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="Create" class="btn btn-primary" />
                </div>
            </div>
        </div>
    End Using

    <div>
        @Html.ActionLink("Back to List", "AllCustomers")
    </div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/bundles/PartnerValidations")
End Section
