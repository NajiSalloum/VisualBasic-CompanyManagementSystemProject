@ModelType PartnerLevel
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>PartnerLevel</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.PartnerLevelName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PartnerLevelName)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.PartnerLevelID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
