namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Indicates date in which calendar is to be customized.
/// Allows distinguishing From and To inputs in <see cref="EcInputDateRange"/>.
/// </summary>
public class CalendarDateCustomizationTarget
{
	/// <summary>
	/// Customization is for standalone <see cref="EcCalendar" />.
	/// </summary>
	public static CalendarDateCustomizationTarget Calendar { get; } = new CalendarDateCustomizationTarget();

	/// <summary>
	/// Customization is for the dropdown calendar in <see cref="EcInputDate{TValue}" />.
	/// </summary>
	public static CalendarDateCustomizationTarget InputDate { get; } = new CalendarDateCustomizationTarget();

	/// <summary>
	/// Customization is for the <i>From</i> dropdown calendar in <see cref="EcInputDateRange" />.
	/// </summary>
	public static CalendarDateCustomizationTarget InputDateRangeFrom { get; } = new CalendarDateCustomizationTarget();

	/// <summary>
	/// Customization is for the <i>To</i> dropdown calendar in <see cref="EcInputDateRange" />.
	/// </summary>
	public static CalendarDateCustomizationTarget InputDateRangeTo { get; } = new CalendarDateCustomizationTarget();
}
