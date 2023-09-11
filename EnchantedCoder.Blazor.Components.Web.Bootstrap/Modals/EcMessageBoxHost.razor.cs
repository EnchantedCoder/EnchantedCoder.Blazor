namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Displays message boxes initiated through <see cref="IEcMessageBoxService"/>.
/// To be placed in root application component / main layout.
/// </summary>
public partial class EcMessageBoxHost : ComponentBase
{
	[Inject] protected IEcMessageBoxService MessageBoxService { get; set; }

	private EcMessageBox messageBox;
	private MessageBoxRequest request;
	private TaskCompletionSource<MessageBoxButtons> resultCompletion;

	protected override void OnInitialized()
	{
		base.OnInitialized();

		MessageBoxService.OnShowAsync = HandleShowRequest;
	}

	private async Task<MessageBoxButtons> HandleShowRequest(MessageBoxRequest request)
	{
		this.request = request;
		this.resultCompletion = new TaskCompletionSource<MessageBoxButtons>();

		StateHasChanged();

		await messageBox.ShowAsync();

		return await this.resultCompletion.Task;
	}

	private void HandleClosed(MessageBoxButtons button)
	{
		_ = resultCompletion.TrySetResult(button);
	}
}
