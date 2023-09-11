namespace EnchantedCoder.Blazor.Components.Web;

public class EcMessageBoxService : IEcMessageBoxService
{
	public Func<MessageBoxRequest, Task<MessageBoxButtons>> OnShowAsync { get; set; }

	public Task<MessageBoxButtons> ShowAsync(MessageBoxRequest request)
	{
		return OnShowAsync.Invoke(request);
	}
}
