@ModelType RecourseEventLine
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>RecourseEventLine</h4>
        <hr />
        @Html.ValidationSummary(true)
        @Html.HiddenFor(Function(model) model.RecourseEventLineID)

        <div class="form-group">
            @Html.LabelFor(Function(model) model.UserID, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.UserID)
                @Html.ValidationMessageFor(Function(model) model.UserID)
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
            @Html.LabelFor(Function(model) model.EventDate, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.EventDate)
                @Html.ValidationMessageFor(Function(model) model.EventDate)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.ResourceEventID, "ResourceEventID", New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.DropDownList("ResourceEventID", String.Empty)
                @Html.ValidationMessageFor(Function(model) model.ResourceEventID)
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
