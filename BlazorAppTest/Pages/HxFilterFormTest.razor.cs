﻿using System.ComponentModel.DataAnnotations;
using EnchantedCoder.Blazor.Components.Web.Bootstrap;

namespace BlazorAppTest.Pages;

public partial class HxFilterFormTest
{
	protected FormModel model = new FormModel { Text1 = "initial value" };
	private HxGrid<string> myGrid;

	private HxFilterForm<FormModel> filterForm;
	private ChipItem[] chips;
	private ThemeColor[] selectData;

	protected override async Task OnInitializedAsync()
	{
		await Task.Delay(100);
		selectData = Enum.GetValues<ThemeColor>();
	}

	private void HandleChipsUpdated(ChipItem[] chips)
	{
		Console.WriteLine("HandleChipsUpdated");
		this.chips = chips;
	}

	private async Task HandleChipRemoveClick(ChipItem chipToRemove)
	{
		Console.WriteLine("HandleChipRemoveClick");
		await filterForm.RemoveChipAsync(chipToRemove);
	}

	#region Nested class FormModel
	public class FormModel : ICloneable
	{
		[Required]
		[MaxLength(20)]
		public string Text1 { get; set; }

		public string Text2 { get; set; }

		public int Number1 { get; set; } = 5;

		public List<string> Tags { get; set; }

		public ThemeColor Color { get; set; } = ThemeColor.Primary;

		public object Clone() => MemberwiseClone();
	}
	#endregion

	private async Task HandleModelChanged(FormModel newModel)
	{
		model = newModel;
		//StateHasChanged();
		await myGrid.RefreshDataAsync();
	}

	private async Task<GridDataProviderResult<string>> GridDataProvider(GridDataProviderRequest<string> request)
	{
		await Task.Delay(3000); // simulate server call

		var stringValues = new List<string>();
		stringValues.Add(model.Text1);
		stringValues.Add(model.Text2);
		stringValues.Add(model.Number1.ToString());
		return request.ApplyTo(stringValues);
	}

	private async Task<InputTagsDataProviderResult> GetTagsSuggestions(InputTagsDataProviderRequest request)
	{
		await Task.Delay(50); // simulate server API call
		return new InputTagsDataProviderResult()
		{
			Data = Enum.GetValues<ThemeColor>().Select(v => v.ToString()).Where(v => v.Contains(request.UserInput, StringComparison.OrdinalIgnoreCase))
		};
	}
}
