using System.Collections;

namespace MusicTheory.Common.Core.DataStructures;

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
			Add(item);
		}
	}

	public void Add(T item)
	{
		var listItem = new ListItem<T>
		{
			Item = item,
		};

		if (_start == null)
		{
			_start = listItem;
			_end = listItem;
		}
		else
		{
			_end.Next = listItem;
			listItem.Prev = _end;
			_end = listItem;
		}

		_start.Prev = _end;
		_end.Next = _start;
	}

	public ListItem<T> GetListItem(T itemValue)
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
