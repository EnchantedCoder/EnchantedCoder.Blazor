using System.Linq.Expressions;
using EnchantedCoder.Collections;

namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Sorting criteria for a <see cref="GridUserState"/>.
/// </summary>
public sealed record GridUserStateSortingItem
{
	/// <summary>
	/// Column identifier.
	/// </summary>
	public string ColumnId { get; init; }

	/// <summary>
	/// Indicates whether the sorting should be performed in the reverse direction.
	/// </summary>
	public bool ReverseDirection { get; init; }
}