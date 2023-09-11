namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Settings for the <see cref="EcCalendar"/> and derived components.
/// </summary>
public record CalendarSettings
{
	/// <summary>
	/// Minimal value to choose from calendar.
	/// </summary>
	public DateTime? MinDate { get; set; }

	/// <summary>
	/// Maximal value to choose from calendar.
	/// </summary>
	public DateTime? MaxDate { get; set; }

	/// <summary>
	/// Allows customization of the dates in dropdown calendars.
	/// </summary>
	public CalendarDateCustomizationProviderDelegate DateCustomizationProvider { get; set; }
}
