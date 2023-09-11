namespace EnchantedCoder.Blazor.Components.Web;

/// <summary>
/// Propagating access to EcMessenger as <see cref="IEcMessengerService" />.
/// </summary>
internal class EcMessengerService : IEcMessengerService
{
	/// <inheritdoc cref="IEcMessengerService.OnMessage" />
	public event Action<MessengerMessage> OnMessage;

	/// <inheritdoc cref="IEcMessengerService.OnClear" />
	public event Action OnClear;

	/// <inheritdoc cref="IEcMessengerService.AddMessage(MessengerMessage)" />
	public void AddMessage(MessengerMessage message)
	{
		OnMessage?.Invoke(message);
	}

	/// <inheritdoc cref="IEcMessengerService.Clear" />
	public void Clear()
	{
		OnClear?.Invoke();
	}
}