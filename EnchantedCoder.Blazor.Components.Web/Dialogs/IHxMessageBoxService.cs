﻿namespace EnchantedCoder.Blazor.Components.Web;

public interface IHxMessageBoxService
{
	Task<MessageBoxButtons> ShowAsync(MessageBoxRequest request);

	Func<MessageBoxRequest, Task<MessageBoxButtons>> OnShowAsync { get; set; }
}
