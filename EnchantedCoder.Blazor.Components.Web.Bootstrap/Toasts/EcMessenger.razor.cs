namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// <see cref="EcToastContainer"/> wrapper for displaying <see cref="EcToast"/> messages dispatched through <see cref="IEcMessengerService"/>.<br />
/// Full documentation and demos: <see href="https://EnchantedCoder.blazor.eu/components/EcMessenger">https://EnchantedCoder.blazor.eu/components/EcMessenger</see>
/// </summary>
public partial class EcMessenger : ComponentBase, IDisposable
{
	/// <summary>
	/// Position of the messages. Default is <see cref="ToastContainerPosition.None"/>.
	/// </summary>
	[Parameter] public ToastContainerPosition Position { get; set; } = ToastContainerPosition.None;

	/// <summary>
	/// Additional CSS class.
	/// </summary>
	[Parameter] public string CssClass { get; set; }

	[Inject] protected IEcMessengerService Messenger { get; set; }
	[Inject] protected NavigationManager NavigationManager { get; set; }

	private List<MessengerMessage> messages = new List<MessengerMessage>();

	protected override void OnInitialized()
	{
		Messenger.OnMessage += HandleMessage;
		Messenger.OnClear += HandleClear;
	}

	private void HandleMessage(MessengerMessage message)
	{
		InvokeAsync(() =>
		{
			messages.Add(message);

			StateHasChanged();
		});
	}

	private void HandleClear()
	{
		InvokeAsync(() =>
		{
			messages.Clear();

			StateHasChanged();
		});
	}

	/// <summary>
	/// Receive notification from <see cref="EcToast"/> when message is hidden.
	/// </summary>
	private void HandleToastHidden(MessengerMessage message)
	{
		messages.Remove(message);
	}

	public void Dispose()
	{
		Dispose(true);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			Messenger.OnMessage -= HandleMessage;
			Messenger.OnClear -= HandleClear;
		}
	}
}
