namespace Project; 

public static class IComparableExtensions {
    extension<T>(IEnumerable<T> items) where T : IComparable {
        /// <summary>
        /// Compares items by their natural order and returns the largest one.
        /// </summary>
        /// <returns>Largest item.</returns>
        public T Largest() => items.OrderDescending().First();
    }
}