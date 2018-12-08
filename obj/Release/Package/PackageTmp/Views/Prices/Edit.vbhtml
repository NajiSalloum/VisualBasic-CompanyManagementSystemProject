@ModelType Price
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>Price</h4>
        <hr />
        @Html.ValidationSummary(true)
        @Html.HiddenFor(Function(model) model.PriceID)

        <div class="form-group">
            @Html.LabelFor(Function(model) model.PriceListID, "PriceListID", New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.DropDownList("PriceListID", String.Empty)
                @Html.ValidationMessageFor(Function(model) model.PriceListID)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.UserID, "UserID", New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.DropDownList("UserID", String.Empty)
                @Html.ValidationMessageFor(Function(model) model.UserID)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.PricePerHour, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.PricePerHour)
                @Html.ValidationMessageFor(Function(model) model.PricePerHour)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.TravelPrice, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.TravelPrice)
                @Html.ValidationMessageFor(Function(model) model.TravelPrice)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.PricePerKm, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.PricePerKm)
                @Html.ValidationMessageFor(Function(model) model.PricePerKm)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Commission, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Commission)
                @Html.ValidationMessageFor(Function(model) model.Commission)
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
