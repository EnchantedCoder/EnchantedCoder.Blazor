namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Non-generic API for <see cref="EcAutosuggest{TItem, TValue}" />.
/// </summary>
public class EcAutosuggest
{
	/// <summary>
	/// Application-wide defaults for the <see cref="EcAutosuggest{TItem, TValue}"/> and derived components.
	/// </summary>
	public static AutosuggestSettings Defaults { get; set; }

	static EcAutosuggest()
	{
		Defaults = new AutosuggestSettings()
		{
			InputSize = Bootstrap.InputSize.Regular,
			SearchIcon = BootstrapIcon.Search,
			ClearIcon = BootstrapIcon.XLg,
			MinimumLength = 2,
			Delay = 300,
		};
	}
}
