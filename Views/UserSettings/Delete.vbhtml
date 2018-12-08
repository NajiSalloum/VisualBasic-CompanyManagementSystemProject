@ModelType UserSetting
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>UserSetting</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.UserName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.UserName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Initials)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Initials)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ExtResourc)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ExtResourc)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ExtTravelTimeID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ExtTravelTimeID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ExtNoOfK)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ExtNoOfK)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ExtOtherExpencesID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ExtOtherExpencesID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Active)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Active)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
