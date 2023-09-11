using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnchantedCoder.Collections;

namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Grid internal state item to persists sorting.
/// </summary>
internal class GridInternalStateSortingItem<TItem>
{
	/// <summary>
	/// Sorting column
	/// </summary>
	public IEcGridColumn<TItem> Column { get; init; }

	/// <summary>
	/// Indicates whether the sorting should be performed in the reverse direction.
	/// </summary>
	public bool ReverseDirection { get; init; }
}
