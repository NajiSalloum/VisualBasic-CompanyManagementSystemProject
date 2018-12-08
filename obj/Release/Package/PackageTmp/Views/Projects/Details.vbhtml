@ModelType Project
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Project</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Customer.ExtCustID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Customer.ExtCustID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ProjectName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ProjectName)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ProjectID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
