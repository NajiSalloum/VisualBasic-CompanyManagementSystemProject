@ModelType UserSetting
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Ändra</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        
        <hr />
        @Html.ValidationSummary(true)
        @Html.HiddenFor(Function(model) model.UserSettingID)

        <div class="form-group">
            @Html.Label("Användare", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.UserName)
                @Html.ValidationMessageFor(Function(model) model.UserName)
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Initialer", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Initials)
                @Html.ValidationMessageFor(Function(model) model.Initials)
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Resues ID", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.ExtResourc)
                @Html.ValidationMessageFor(Function(model) model.ExtResourc)
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Restids ID", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.ExtTravelTimeID)
                @Html.ValidationMessageFor(Function(model) model.ExtTravelTimeID)
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Antal Km ID", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.ExtNoOfK)
                @Html.ValidationMessageFor(Function(model) model.ExtNoOfK)
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Övriga Kostnader ID", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.ExtOtherExpencesID)
                @Html.ValidationMessageFor(Function(model) model.ExtOtherExpencesID)
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Aktiv Konsult", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Active)
                @Html.ValidationMessageFor(Function(model) model.Active)
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-success"  />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
