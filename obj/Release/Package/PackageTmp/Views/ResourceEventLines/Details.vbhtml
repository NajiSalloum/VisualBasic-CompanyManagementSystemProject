@ModelType RecourseEventLine
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>RecourseEventLine</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.ResourceEvent.EventName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ResourceEvent.EventName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.UserID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.UserID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.UserName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.UserName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.EventDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.EventDate)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.RecourseEventLineID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
