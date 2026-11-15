namespace Project;

public abstract class Notifier {
    /// <summary>
    /// Sends text to a recepient.
    /// </summary>
    /// <param name="to">Recepient.</param>
    /// <param name="text">Text to send.</param>
    /// <returns>Text that was actually sent.</returns>
    public abstract string Send(string to, string text);
}