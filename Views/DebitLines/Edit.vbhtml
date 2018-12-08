@ModelType DebitLine
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>DebitLine</h4>
        <hr />
        @Html.ValidationSummary(true)
        @Html.HiddenFor(Function(model) model.LineID)

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DebDate, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DebDate)
                @Html.ValidationMessageFor(Function(model) model.DebDate)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.UserName, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.UserName)
                @Html.ValidationMessageFor(Function(model) model.UserName)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.CustomerID, "CustomerID", New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.DropDownList("CustomerID", String.Empty)
                @Html.ValidationMessageFor(Function(model) model.CustomerID)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.NoOfHours, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.NoOfHours)
                @Html.ValidationMessageFor(Function(model) model.NoOfHours)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.NoOfTravelHours, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.NoOfTravelHours)
                @Html.ValidationMessageFor(Function(model) model.NoOfTravelHours)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.NoOfKm, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.NoOfKm)
                @Html.ValidationMessageFor(Function(model) model.NoOfKm)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.OtherExpences, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.OtherExpences)
                @Html.ValidationMessageFor(Function(model) model.OtherExpences)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.ProjectID, "ProjectID", New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.DropDownList("ProjectID", String.Empty)
                @Html.ValidationMessageFor(Function(model) model.ProjectID)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Description, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Description)
                @Html.ValidationMessageFor(Function(model) model.Description)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Invoiced, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Invoiced)
                @Html.ValidationMessageFor(Function(model) model.Invoiced)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Regesterad, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Regesterad)
                @Html.ValidationMessageFor(Function(model) model.Regesterad)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.PricePerHoure, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.PricePerHoure)
                @Html.ValidationMessageFor(Function(model) model.PricePerHoure)
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
            @Html.LabelFor(Function(model) model.Status, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Status)
                @Html.ValidationMessageFor(Function(model) model.Status)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Comission, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Comission)
                @Html.ValidationMessageFor(Function(model) model.Comission)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Subscription, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Subscription)
                @Html.ValidationMessageFor(Function(model) model.Subscription)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.CompanyCar, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.CompanyCar)
                @Html.ValidationMessageFor(Function(model) model.CompanyCar)
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
