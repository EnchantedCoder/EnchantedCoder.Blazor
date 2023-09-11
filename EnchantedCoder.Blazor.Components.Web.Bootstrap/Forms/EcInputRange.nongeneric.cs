namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

public static class EcInputRange
{
	/// <summary>
	/// Application-wide defaults for the <see cref="EcInputRange{TValue}"/>.
	/// </summary>
	public static InputRangeSettings Defaults { get; set; }

	static EcInputRange()
	{
		Defaults = new InputRangeSettings()
		{
			BindEvent = Bootstrap.BindEvent.OnChange
		};
	}
}
