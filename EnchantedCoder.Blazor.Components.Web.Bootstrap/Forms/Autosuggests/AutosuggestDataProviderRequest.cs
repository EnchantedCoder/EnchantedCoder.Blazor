﻿namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Data provider request for autosuggest data.
/// </summary>
public class AutosuggestDataProviderRequest
{
	/// <summary>
	/// Autosuggest current user input.
	/// </summary>
	public string UserInput { get; init; }

	/// <summary>
	/// The <see cref="System.Threading.CancellationToken"/> used to relay cancellation of the request.
	/// </summary>
	public CancellationToken CancellationToken { get; init; }
}