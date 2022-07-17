namespace MusicTheory.Common.DataStructures;

public class Link<T>
{
	public ListItem<T> Connection { get; set; }

	public int Weight { get; set; }
}
