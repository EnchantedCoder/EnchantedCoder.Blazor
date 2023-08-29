﻿namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Data provider result for <see cref="HxInputTags"/>.
/// </summary>
public class InputTagsDataProviderResult
{
	/// <summary>
	/// The provided items by the request.
	/// </summary>
	public IEnumerable<string> Data { get; set; }
}