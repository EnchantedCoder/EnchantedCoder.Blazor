using EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation.Shared.Components;

namespace EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation.Services;

public interface IDocPageNavigationItemsHolder
{
	void RegisterNew(IDocPageNavigationItem item, string url);

	ICollection<IDocPageNavigationItem> RetrieveAll(string url);

	void Clear();
}
