namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Used in a component which can generate chips.
/// </summary>
public interface IEcChipGenerator
{
	/// <summary>
	/// Get chips from the component.
	/// </summary>
	IEnumerable<ChipItem> GetChips();
}