@ModelType ProjectTerminology
@Code
    ViewData("Title") = "Create"
End Code
<div class="jumbotron">
    <h2>Lägg till nytt project</h2>

    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-horizontal">

            <hr />
            @Html.ValidationSummary(True)
            <div class="form-group">
                @Html.Label("Projekt Namn:", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.ProjectTerminologyName)
                    @Html.ValidationMessageFor(Function(model) model.ProjectTerminologyName)
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Beskrivning", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.TextAreaFor(Function(model) model.ProjectTerminologyDescription)
                    @Html.ValidationMessageFor(Function(model) model.ProjectTerminologyDescription)
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="Lägg till" class="btn btn-primary"  />
                </div>
            </div>
        </div>
    End Using

    <div>
        @Html.ActionLink("Back to List", "Index")
    </div>
</div>