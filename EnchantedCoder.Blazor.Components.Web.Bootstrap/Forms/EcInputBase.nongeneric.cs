namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Non-generic API for the <see cref="EcInputBase{TValue}"/> component.
/// </summary>
public sealed class EcInputBase
{
	/// <summary>
	/// Application-wide defaults for the <see cref="EcInputBase{TValue}"/> and derived components.
	/// </summary>
	public static InputSettings Defaults { get; set; }

	static EcInputBase()
	{
		Defaults = new InputSettings()
		{
			ValidationMessageMode = ValidationMessageMode.Floating
		};
	}
}