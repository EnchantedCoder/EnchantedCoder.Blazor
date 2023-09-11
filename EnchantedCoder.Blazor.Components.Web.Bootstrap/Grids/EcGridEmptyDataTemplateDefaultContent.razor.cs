using Microsoft.Extensions.Localization;

namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

public partial class EcGridEmptyDataTemplateDefaultContent
{
	[Parameter] public RenderFragment ChildContent { get; set; }

	[Inject] protected IStringLocalizer<EcGrid> EcGridLocalizer { get; set; }
}
