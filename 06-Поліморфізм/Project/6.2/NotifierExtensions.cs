namespace Project;

public static class NotifierExtensions {
    extension(IEnumerable<Notifier> notifiers) {
        public List<string> Broadcast(string to, string text) {
            var sent = new List<string>();

            foreach (var notifier in notifiers)
                sent.Add(notifier.Send(to, text));

            return sent;
        }
    }
}