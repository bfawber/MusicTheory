using MusicTheory.Common.Core.Services;
using MusicTheory.Common.Features.Intervals;
using MusicTheory.Common.Features.Intervals.Creation;
using MusicTheory.Common.Features.Notes;
using MusicTheory.Common.Features.Notes.Creation;

namespace MusicTheory.Common.Features.Quiz.Interval;

/// <inheritdoc />
public class IntervalQuizService : IIntervalQuizService
{
	private readonly INoteFactory _noteFactory;
	private readonly IIntervalFactory _intervalFactory;
	private readonly IIntervalService _intervalService;
	private readonly IRandomService _randomService;

	public IntervalQuizService(INoteFactory noteFactory, IIntervalFactory intervalFactory, IIntervalService intervalService, IRandomService randomService)
	{
		_noteFactory = noteFactory ?? throw new ArgumentNullException(nameof(noteFactory));
		_intervalFactory = intervalFactory ?? throw new ArgumentNullException(nameof(intervalFactory));
		_intervalService = intervalService ?? throw new ArgumentNullException(nameof(intervalService));
		_randomService = randomService ?? throw new ArgumentNullException(nameof(randomService));
	}

	/// <inheritdoc />
	public IntervalQuizQuestion GetQuestion(IntervalQuizQuestionOptions options)
	{
		ValidateOptions(options);

		var startingNote = _noteFactory.CreateRandom();
		var interval = _intervalFactory.CreateRandom();
		bool isIntervalAbove = options.IncludeAbove;

		if (options.IncludeAbove && options.IncludeBelow)
		{
			int randomNum = _randomService.Next(2);
			if (randomNum < 1)
			{
				isIntervalAbove = false;
			}
		}

		Note answer;
		if (isIntervalAbove)
		{
			answer = _intervalService.GetAbove(startingNote, interval);
		}
		else
		{
			answer = _intervalService.GetBelow(startingNote, interval);
		}

		return new IntervalQuizQuestion(startingNote, interval, answer);
	}

	private void ValidateOptions(IntervalQuizQuestionOptions options)
	{
		if (options == null)
		{
			throw new ArgumentNullException(nameof(options));
		}

		if (!options.IncludeAbove && !options.IncludeBelow)
		{
			throw new ArgumentException("At least one direction (Above or Below) must be included in quiz options.", nameof(options));
		}
	}
}
