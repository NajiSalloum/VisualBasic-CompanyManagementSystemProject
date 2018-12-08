@ModelType UserSetting
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>UserSetting</h4>
        <hr />
        @Html.ValidationSummary(true)
        <div class="form-group">
            @Html.LabelFor(Function(model) model.UserName, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.UserName)
                @Html.ValidationMessageFor(Function(model) model.UserName)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Initials, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Initials)
                @Html.ValidationMessageFor(Function(model) model.Initials)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.ExtResourc, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.ExtResourc)
                @Html.ValidationMessageFor(Function(model) model.ExtResourc)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.ExtTravelTimeID, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.ExtTravelTimeID)
                @Html.ValidationMessageFor(Function(model) model.ExtTravelTimeID)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.ExtNoOfK, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.ExtNoOfK)
                @Html.ValidationMessageFor(Function(model) model.ExtNoOfK)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.ExtOtherExpencesID, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.ExtOtherExpencesID)
                @Html.ValidationMessageFor(Function(model) model.ExtOtherExpencesID)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Active, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Active)
                @Html.ValidationMessageFor(Function(model) model.Active)
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
