using MusicTheory.Common.Features.Intervals;
using MusicTheory.Common.Features.Intervals.Creation;
using MusicTheory.Common.Features.Notes;
using MusicTheory.Common.Features.Notes.Creation;

namespace MusicTheory.Common.Features.Quiz.Interval;

/// <inheritdoc />
public class IntervalQuizService : IIntervalQuizService
{
	private static readonly Random Random = new Random();

	private readonly IntervalQuizServiceOptions _options;
	private readonly INoteFactory _noteFactory;
	private readonly IIntervalFactory _intervalFactory;
	private readonly IIntervalService _intervalService;


	public IntervalQuizService(IntervalQuizServiceOptions options, INoteFactory noteFactory, IIntervalFactory intervalFactory, IIntervalService intervalService)
	{
		_options = options ?? throw new ArgumentNullException(nameof(options));
		_noteFactory = noteFactory ?? throw new ArgumentNullException(nameof(noteFactory));
		_intervalFactory = intervalFactory ?? throw new ArgumentNullException(nameof(intervalFactory));
		_intervalService = intervalService ?? throw new ArgumentNullException(nameof(intervalService));

		ValidateOptions(_options);
	}

	/// <inheritdoc />
	public IntervalQuizQuestion GetQuestion()
	{
		var startingNote = _noteFactory.CreateRandom();
		var interval = _intervalFactory.CreateRandom();
		bool isIntervalAbove = _options.IncludeAbove;

		if (_options.IncludeAbove && _options.IncludeBelow)
		{
			int randomNum = Random.Next(2);
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

	private void ValidateOptions(IntervalQuizServiceOptions options)
	{
		if (options == null || (!options.IncludeAbove && !options.IncludeBelow))
		{
			throw new ArgumentException($"The options values provided are invalid.");
		}
	}
}
