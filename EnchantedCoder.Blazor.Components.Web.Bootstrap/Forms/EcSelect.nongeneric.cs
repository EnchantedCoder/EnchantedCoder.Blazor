namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Non-generic API for <see cref="EcSelect{TValue, TItem}"/>.
/// </summary>
public class EcSelect
{
	/// <summary>
	/// Application-wide defaults for the <see cref="EcSelect{TValue, TItem}"/> (<see cref="EcSelectBase{TValue, TItem}"/> and derived components respectively).
	/// </summary>
	public static SelectSettings Defaults { get; set; }

	static EcSelect()
	{
		Defaults = new SelectSettings()
		{
			InputSize = InputSize.Regular,
		};
	}
}
