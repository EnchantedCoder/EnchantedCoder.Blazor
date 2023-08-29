﻿namespace EnchantedCoder.Blazor.Components.Web;

public class HxMessageBoxService : IHxMessageBoxService
{
	public Func<MessageBoxRequest, Task<MessageBoxButtons>> OnShowAsync { get; set; }

	public Task<MessageBoxButtons> ShowAsync(MessageBoxRequest request)
	{
		return OnShowAsync.Invoke(request);
	}
}
