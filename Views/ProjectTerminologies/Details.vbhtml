@ModelType ProjectTerminology
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>ProjectTerminology</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.ProjectTerminologyName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ProjectTerminologyName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ProjectTerminologyDescription)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ProjectTerminologyDescription)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ProjectTerminologyID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
