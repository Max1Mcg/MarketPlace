namespace MarketPlace.Extensions
{
    public static class CollectionHelpers
    {
        /// <summary>
        /// Метод расширения для создания AddRange для коллекции
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="destination">текущая коллекция</param>
        /// <param name="source">добавляемое перечисление</param>
        public static void AddRange<T>(this ICollection<T>destination, IEnumerable<T>source)
        {
            foreach (var v in source)
            {
                destination.Add(v);
            }
        }
        /// <summary>
        /// Метод расширения для создания DeleteRange для коллекции
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="destination">текущая коллекция</param>
        /// <param name="source">удаляемое перечисление</param>
        public static void RemoveRange<T>(this ICollection<T> destination, IEnumerable<T> source)
        {
            foreach (var v in source)
            {
                destination.Remove(v);
            }
        }
    }
}
