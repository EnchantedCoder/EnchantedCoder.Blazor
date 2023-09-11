namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Non-generic API for <see cref="EcListLayout{TFilterModel}" />.
/// </summary>
public class EcListLayout
{
	/// <summary>
	/// Application-wide defaults for <see cref="EcListLayout{TFilterModel}"/> and derived components.
	/// </summary>
	public static ListLayoutSettings Defaults { get; set; }

	static EcListLayout()
	{
		Defaults = new ListLayoutSettings()
		{
			CardSettings = new CardSettings(),
			FilterSubmitButtonSettings = new ButtonSettings()
			{
				Color = ThemeColor.Primary,
			},
			FilterOpenButtonSettings = new ButtonSettings()
			{
				Icon = BootstrapIcon.Filter,
				Color = ThemeColor.Light,
			},
			FilterOffcanvasSettings = new OffcanvasSettings(),
		};
	}

	/// <summary>
	/// Can be used for TFilterModelType to express there is no filter in the <see cref="EcListLayout"/> component.
	/// </summary>
	public sealed class NoFilter { }
}
