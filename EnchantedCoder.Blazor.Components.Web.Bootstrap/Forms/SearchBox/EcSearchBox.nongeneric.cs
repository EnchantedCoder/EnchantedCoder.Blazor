namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Non-generic API for <see cref="EcSearchBox{TItem}" />.
/// </summary>
public static class EcSearchBox
{
	/// <summary>
	/// Application-wide defaults for the <see cref="EcSearchBox{TItem}"/> and derived components.
	/// </summary>
	public static SearchBoxSettings Defaults { get; set; }

	static EcSearchBox()
	{
		Defaults = new SearchBoxSettings()
		{
			InputSize = Bootstrap.InputSize.Regular,
			SearchIcon = BootstrapIcon.Search,
			ClearIcon = BootstrapIcon.XLg,
			MinimumLength = 2,
			Delay = 300,
		};
	}
}

