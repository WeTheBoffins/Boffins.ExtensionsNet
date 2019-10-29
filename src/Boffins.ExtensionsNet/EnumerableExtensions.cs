using System.Collections.Generic;
using System.Linq;

namespace Boffins.ExtensionsNet 
{
    public static class EnumerableExtensions 
    {
        public static bool HasAny<T>(this IEnumerable<T> arr1, IEnumerable<T> arr2) 
        {
            return arr2.Any(arr1.Contains);
        } 
        
        public static bool HasAny<T>(this IEnumerable<T> arr1, params T[] values) {
            return values.Any(arr1.Contains);
        }

        public static bool HasAll<T>(this IEnumerable<T> arr1, IEnumerable<T> arr2) 
        {
            return arr2.All(arr1.Contains);
        }
        
        public static bool HasAll<T>(this IEnumerable<T> arr1, params T[] values) 
        {
            return values.All(arr1.Contains);
        }
        
    }
}