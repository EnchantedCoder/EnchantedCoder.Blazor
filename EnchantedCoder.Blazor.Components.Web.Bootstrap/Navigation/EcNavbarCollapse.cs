namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Collapse section for Bootstrap 5 <see href="https://getbootstrap.com/docs/5.3/components/navbar/">navbar</see> component.
/// Derived from <see cref="EcCollapse"/>.
/// </summary>
public class EcNavbarCollapse : EcCollapse
{
	[CascadingParameter] protected EcNavbar NavbarContainer { get; set; }

	public override async Task SetParametersAsync(ParameterView parameters)
	{
		await base.SetParametersAsync(parameters);

		Contract.Requires<InvalidOperationException>(NavbarContainer is not null, $"{nameof(EcNavbarToggler)} requires parent {nameof(EcNavbar)}.");

		Id = parameters.GetValueOrDefault(nameof(Id), NavbarContainer.GetDefaultCollapseId());
	}

	protected override string GetCssClass()
	{
		return CssClassHelper.Combine("navbar-collapse", base.GetCssClass());
	}
}
