namespace MusicTheory.Common.DataStructures;

public class ListItem<T>
{
	public T Item { get; init; }

	public ListItem<T> Next { get; set; }

	public ListItem<T> Prev { get; set; }
}
