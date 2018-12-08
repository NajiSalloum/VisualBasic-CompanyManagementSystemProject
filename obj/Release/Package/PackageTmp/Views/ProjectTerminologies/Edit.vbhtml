@ModelType ProjectTerminology
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>ProjectTerminology</h4>
        <hr />
        @Html.ValidationSummary(true)
        @Html.HiddenFor(Function(model) model.ProjectTerminologyID)

        <div class="form-group">
            @Html.LabelFor(Function(model) model.ProjectTerminologyName, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.ProjectTerminologyName)
                @Html.ValidationMessageFor(Function(model) model.ProjectTerminologyName)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.ProjectTerminologyDescription, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.ProjectTerminologyDescription)
                @Html.ValidationMessageFor(Function(model) model.ProjectTerminologyDescription)
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
