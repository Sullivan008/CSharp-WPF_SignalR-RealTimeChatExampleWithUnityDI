namespace Application.Common.Utilities.Extensions;

public static class IEnumerableExtensions
{
    public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action)
    {
        foreach (T item in @this)
        {
            action(item);
        }
    }
}