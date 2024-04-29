namespace DelegatesConsoleApp
{
    public static class Extentions
    {
        public static T? GetMax<T>(this IEnumerable<T> collection, Func<T?, float?> convertToNumber) where T : class
        {
            T? maxT = null;
            float? maxValue = null;
            foreach (var item in collection)
            {
                var itemValue = convertToNumber(item);
                if(maxValue == null && itemValue >= maxValue)
                {
                    maxValue = itemValue;
                    maxT = item;
                }
            }

            return maxT;
        }
    }
}
