﻿using EnchantedCoder.Blazor.Components.Web.Bootstrap;
using Microsoft.AspNetCore.Components;

namespace BlazorAppTest.Pages;

public partial class EcListLayoutTest
{
	[Inject] protected NavigationManager NavigationManager { get; set; }

	private DataItemDto currentItem;
	private FilterModelDto filterModel = new FilterModelDto();
	private EcGrid<DataItemDto> gridComponent;

	private readonly IEnumerable<NamedView<FilterModelDto>> namedViews = new List<NamedView<FilterModelDto>>()
	{
		new NamedView<FilterModelDto>("Minimum = 1", () => new FilterModelDto { MinimumItemId = 1 }),
		new NamedView<FilterModelDto>("Minimum = 2", () => new FilterModelDto { MinimumItemId = 2 }),
		new NamedView<FilterModelDto>("Minimum = 3", () => new FilterModelDto { MinimumItemId = 3 })
	};

	private Task<GridDataProviderResult<DataItemDto>> LoadDataItems(GridDataProviderRequest<DataItemDto> request)
	{
		List<DataItemDto> data = new List<DataItemDto>()
		{
			new DataItemDto() { ItemId = 1, Name = "Edward P. Lopez", Email="EdwardPLopez@teleworm.us", PhoneNumber="918-483-4067", Age=45},
			new DataItemDto() { ItemId = 2, Name = "Stanley M. Bolduc", Email="StanleyMBolduc@armyspy.com", PhoneNumber="330-510-7016", Age=29},
			new DataItemDto() { ItemId = 3, Name = "David D. Lounsbury", Email="DavidDLounsbury@armyspy.com", PhoneNumber="212-292-4140", Age=38},
			new DataItemDto() { ItemId = 4, Name = "Benjamin M. Damato", Email="BenjaminMDamato@jourrapide.com", PhoneNumber="225-268-0659", Age=63},
			new DataItemDto() { ItemId = 5, Name = "Carol B. Jhonson", Email="CarolBJhonson@teleworm.us", PhoneNumber="217-243-3921", Age=25},
			new DataItemDto() { ItemId = 6, Name = "Juan I. Nichols", Email="JuanINichols@rhyta.com", PhoneNumber="727-562-0918", Age=60}
		};

		IEnumerable<DataItemDto> result = data.Where(i => i.ItemId >= filterModel.MinimumItemId).ToList();
		if (filterModel.NameContains is not null)
		{
			result = result.Where(i => i.Name.Contains(filterModel.NameContains));
		}
		result = result.Where(i => i.Age >= filterModel.MinimumAge);
		if (filterModel.MaximumAge > filterModel.MinimumAge)
		{
			result = result.Where(i => i.Age <= filterModel.MaximumAge);
		}

		return Task.FromResult(new GridDataProviderResult<DataItemDto>()
		{
			Data = result,
			TotalCount = result.Count()
		});
	}

	private async Task HandleFilterModelChanged(FilterModelDto newFilterModel)
	{
		filterModel = newFilterModel;
		await gridComponent.RefreshDataAsync();
	}

	protected async Task NamedViewSelected(NamedView<FilterModelDto> namedView)
	{
		filterModel = namedView.Filter();
		await gridComponent.RefreshDataAsync();
	}

	protected async Task SearchRequested()
	{
		await gridComponent.RefreshDataAsync();
	}

	private Task DeleteItemClicked(DataItemDto dataItemDto)
	{
		_ = dataItemDto;
		return Task.CompletedTask;
	}

	private Task HandleSelectedDataItemChanged(DataItemDto selection)
	{
		currentItem = selection;
		// await dataItemEditComponent.ShowAsync();
		return Task.CompletedTask;
	}

	private Task NewItemClicked()
	{
		currentItem = new DataItemDto();
		// await dataItemEditComponent.ShowAsync();
		return Task.CompletedTask;
	}

	private async Task<InputTagsDataProviderResult> GetTagsSuggestions(InputTagsDataProviderRequest request)
	{
		await Task.Delay(50); // simulate server API call
		return new InputTagsDataProviderResult()
		{
			Data = Enum.GetValues<ThemeColor>().Select(v => v.ToString()).Where(v => v.Contains(request.UserInput, StringComparison.OrdinalIgnoreCase))
		};
	}

	public record FilterModelDto
	{
		public int MinimumItemId { get; set; }
		public string NameContains { get; set; }
		public int MinimumAge { get; set; }
		public int MaximumAge { get; set; }
		public List<string> Tags { get; set; }
	}

	public record DataItemDto
	{
		public int ItemId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public int Age { get; set; }
	}
}
