using System.Diagnostics.CodeAnalysis;

namespace MusicTheory.Common.Core.DataStructures;

/// <summary>
/// An item for a <see cref="Linked{T}" /> list.
/// </summary>
/// <typeparam name="T">The type of item being stored.</typeparam>
[ExcludeFromCodeCoverage]
public class ListItem<T>
{
	public T Item { get; init; }

	public ListItem<T> Next { get; set; }

	public ListItem<T> Prev { get; set; }
}
