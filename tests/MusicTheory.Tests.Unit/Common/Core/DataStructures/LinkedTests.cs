using MusicTheory.Common.Core.DataStructures;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MusicTheory.Tests.Unit.Common.Core.DataStructures;

public class LinkedTests
{
	[Fact]
	public void Add_ToEmptyLinked_CreatesLinkedWithOneItem()
	{
		const string item = "one";
		Linked<string> linked = new Linked<string>();

		linked.Add(item);

		Assert.Single(linked);
		Assert.Equal(item, linked.First());
	}

	[Fact]
	public void Add_MultipleItems_CreatesLinkedList()
	{
		List<string> inputs = new List<string>
		{
			"one",
			"two",
			"three",
			"four",
			"five"
		};

		Linked<string> linked = new Linked<string>(inputs.ToArray());
		Assert.Equal(5, linked.Count());


		Linked<string> linkedTwo = new Linked<string>();
		foreach(string input in inputs)
		{
			linkedTwo.Add(input);
		}
		Assert.Equal(5, linkedTwo.Count());
	}

	[Fact]
	public void GetListItem_ValidInput_GetsItemWithValue()
	{
		List<string> inputs = new List<string>
		{
			"one",
			"two",
			"three",
			"four",
			"five"
		};

		Linked<string> linked = new Linked<string>(inputs.ToArray());

		var item = linked.GetListItem("three");
		Assert.NotNull(item);
		Assert.Equal("three", item.Item);
	}
}
