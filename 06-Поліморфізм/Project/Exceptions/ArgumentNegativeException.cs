using System.Runtime.CompilerServices;

namespace Project.Exceptions {
    public class ArgumentNegativeException : ArgumentException {
        private const string DefaultMessage = "Argument can't be negative.";

        public ArgumentNegativeException(string? argName) : base(DefaultMessage, argName) { 
            
        }

        public ArgumentNegativeException(object arg, [CallerArgumentExpression(nameof(arg))] string? argName = null) 
            : this(argName) {
        }

        public static void ThrowIfNegative(float v, [CallerArgumentExpression(nameof(v))] string? argName = null) {
            if (v < 0) throw new ArgumentNegativeException(argName);
        }

        public static void ThrowIfNegative(double v, [CallerArgumentExpression(nameof(v))] string? argName = null) {
            if (v < 0) throw new ArgumentNegativeException(argName);
        }

        public static void ThrowIfNegative(decimal v, [CallerArgumentExpression(nameof(v))] string? argName = null) {
            if (v < 0) throw new ArgumentNegativeException(argName);
        }

        public static void ThrowIfNegative(int v, [CallerArgumentExpression(nameof(v))] string? argName = null) {
            if (v < 0) throw new ArgumentNegativeException(argName);
        }
    }
}
