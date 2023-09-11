namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Allows customization of specific date in calendar (<see cref="EcCalendar"/>, <see cref="EcInputDate{TValue}"/>, <see cref="EcInputDateRange"/>).
/// </summary>
public delegate CalendarDateCustomizationResult CalendarDateCustomizationProviderDelegate(CalendarDateCustomizationRequest request);
