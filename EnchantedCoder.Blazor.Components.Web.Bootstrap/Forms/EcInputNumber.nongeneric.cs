namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Non-generic API for <see cref="EcInputNumber{TValue}"/>.
/// Marker for resources for <see cref="EcInputNumber{TValue}"/>.
/// </summary>
public class EcInputNumber
{
	/// <summary>
	/// Application-wide defaults for the <see cref="EcAutosuggest{TItem, TValue}"/> and derived components.
	/// </summary>
	public static InputNumberSettings Defaults { get; set; }

	static EcInputNumber()
	{
		Defaults = new InputNumberSettings()
		{
			InputSize = InputSize.Regular,
		};
	}
}
