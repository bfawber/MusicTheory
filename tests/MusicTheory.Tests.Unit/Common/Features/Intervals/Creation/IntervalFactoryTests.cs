using MusicTheory.Common.Core.Services;
using MusicTheory.Common.Features.Intervals;
using MusicTheory.Common.Features.Intervals.Creation;
using System;
using Xunit;

namespace MusicTheory.Tests.Unit.Common.Features.Intervals.Creation;

public class IntervalFactoryTests
{
	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData(" ")]
	[InlineData(" \t\t\r\n		")]
	public void Create_NullArguments_ThrowsException(string input)
	{
		var factory = Create();

		Assert.Throws<ArgumentException>(() => factory.Create(input));
	}

	[Fact]
	public void Create_InvalidIntervalType_ThrowsException()
	{
		var factory = Create();

		Assert.Throws<ArgumentOutOfRangeException>(() => factory.Create("bad"));
	}

	[Theory]
	[InlineData("m2", typeof(MinorSecond))]
	[InlineData("2", typeof(MajorSecond))]
	[InlineData("-5", typeof(DiminishedFifth))]
	[InlineData("+11", typeof(AugmentedEleventh))]
	[InlineData("-7", typeof(DiminishedSeventh))]
	public void Create_ValidIntervals_GetCreated(string input, Type expectedOutput)
	{
		var factory = Create();

		var interval = factory.Create(input);

		Assert.IsType(expectedOutput, interval);
	}

	[Fact]
	public void CreateRandom_CreatesRandomInterval()
	{
		var factory = Create();

		var randomInterval = factory.CreateRandom();

		Assert.IsAssignableFrom<IInterval>(randomInterval);
	}

	private IntervalFactory Create() => new IntervalFactory(new RandomService());
}
