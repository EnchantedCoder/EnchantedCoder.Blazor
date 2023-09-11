namespace EnchantedCoder.Blazor.Components.Web;

public interface IEcMessageBoxService
{
	Task<MessageBoxButtons> ShowAsync(MessageBoxRequest request);

	Func<MessageBoxRequest, Task<MessageBoxButtons>> OnShowAsync { get; set; }
}
