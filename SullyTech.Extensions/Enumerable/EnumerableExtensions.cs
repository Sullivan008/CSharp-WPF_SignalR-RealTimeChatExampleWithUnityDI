namespace SullyTech.Extensions.Enumerable;

public static class EnumerableExtensions
{
    public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action)
    {
        foreach (T item in @this)
        {
            action(item);
        }
    }
}