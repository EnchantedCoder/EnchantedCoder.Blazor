namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Non-generic API for <see cref="EcMultiSelect{TValue, TItem}"/>.
/// </summary>
public class EcMultiSelect
{
	/// <summary>
	/// Application-wide defaults for the <see cref="EcMultiSelect{TValue, TItem}"/>.
	/// </summary>
	public static MultiSelectSettings Defaults { get; set; }

	static EcMultiSelect()
	{
		Defaults = new MultiSelectSettings()
		{
			InputSize = InputSize.Regular,
		};
	}
}
