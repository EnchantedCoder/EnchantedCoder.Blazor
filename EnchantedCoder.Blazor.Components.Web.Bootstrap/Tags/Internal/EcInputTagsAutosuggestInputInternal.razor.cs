﻿namespace EnchantedCoder.Blazor.Components.Web.Bootstrap.Internal;

public partial class EcInputTagsAutosuggestInputInternal
{
	[Parameter] public string Value { get; set; }

	[Parameter] public string Placeholder { get; set; }

	[Parameter] public EventCallback<string> OnInput { get; set; }

	[Parameter] public EventCallback OnFocus { get; set; }

	[Parameter] public EventCallback OnBlur { get; set; }

	[Parameter] public EventCallback OnMouseDown { get; set; }

	[Parameter] public string InputId { get; set; }

	[Parameter] public string CssClass { get; set; }

	[Parameter] public bool EnabledEffective { get; set; }

	/// <summary>
	/// Offset between dropdown input and dropdown menu
	/// </summary>
	[Parameter] public (int X, int Y) Offset { get; set; }

	[Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> AdditionalAttributes { get; set; }

	internal ElementReference InputElement { get; set; }

	private async Task HandleInput(ChangeEventArgs changeEventArgs)
	{
		await OnInput.InvokeAsync((string)changeEventArgs.Value);
	}

	public async ValueTask FocusAsync()
	{
		await InputElement.FocusAsync();
	}
}
