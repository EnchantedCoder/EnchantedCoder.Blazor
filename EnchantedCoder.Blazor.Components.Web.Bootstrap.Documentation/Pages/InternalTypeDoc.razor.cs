using EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation.Services;

namespace EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation.Pages;

public partial class InternalTypeDoc
{
	[Parameter] public string TypeText { get; set; }

	private Type type;

	protected override void OnParametersSet()
	{
		try
		{
			type = ApiTypeHelper.GetType(TypeText);
		}
		catch
		{
			// NOOP
		}
	}
}
