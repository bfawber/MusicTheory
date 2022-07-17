using System.Collections;

namespace MusicTheory.Common.DataStructures;

public class Linked<T> : IEnumerable<T>
{
	private ListItem<T> _start;
	private ListItem<T> _end;

	public ListItem<T> Start => _start;
	public ListItem<T> End => _end;

	public Linked()
	{
	}

	public Linked(params T[] items)
	{
		foreach (var item in items)
		{
			Add(new ListItem<T> { Item = item });
		}
	}

	public void Add(ListItem<T> item)
	{
		if (_start == null)
		{
			_start = item;
			_end = item;
		}
		else
		{
			_end.Next = item;
			item.Prev = _end;
			_end = item;
			_end.Next = _start;
		}
	}

	public ListItem<T> Get(T itemValue)
	{
		if (_start.Item.Equals(itemValue))
		{
			return _start;
		}

		ListItem<T> current = _start.Next;
		while (!ReferenceEquals(current, _start))
		{
			if (current.Item.Equals(itemValue))
			{
				return current;
			}

			current = current.Next;
		}

		return null;
	}

	public IEnumerator<T> GetEnumerator()
	{
		var current = _start;
		yield return current.Item;
		current = current.Next;
		while (current != null && current != _start)
		{
			yield return current.Item;
			current = current.Next;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		var current = _start;
		yield return current.Item;
		current = current.Next;
		while (current != null && current != _start)
		{
			yield return current.Item;
			current = current.Next;
		}
	}
}
