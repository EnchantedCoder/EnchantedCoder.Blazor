namespace EnchantedCoder.Blazor.Components.Web.Bootstrap.Internal;

/// <summary>
/// Render order.
/// </summary>
public enum LabelValueRenderOrder
{
	/// <summary>
	/// Render label first, then value/input (majority of components).
	/// </summary>
	LabelValue,

	/// <summary>
	/// Render value/input first, then label (ie. former EcInputCheckbox).
	/// Obsolete, should not be needed any more.
	/// </summary>
	ValueLabel,

	/// <summary>
	/// Render value/input only. Label is not rendered (ie. <see cref="EcAutosuggest{TItem, TValue}" /> with floating label which renders label internally).
	/// </summary>
	ValueOnly
}