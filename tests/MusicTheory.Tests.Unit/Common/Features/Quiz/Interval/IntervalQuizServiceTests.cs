using MusicTheory.Common.Core.Services;
using MusicTheory.Common.Features.Accidentals;
using MusicTheory.Common.Features.Intervals;
using MusicTheory.Common.Features.Intervals.Creation;
using MusicTheory.Common.Features.Notes.Creation;
using MusicTheory.Common.Features.Quiz.Interval;
using MusicTheory.Common.Features.Scales;
using System;
using Xunit;

namespace MusicTheory.Tests.Unit.Common.Features.Quiz.Interval;

public class IntervalQuizServiceTests
{
	private readonly IAccidentalsService _accidentalsService = new AccidentalsService();
	private readonly IRandomService _randomService = new RandomService();

	[Fact]
	public void GetQuestion_WithInvalidOptions_ThrowsException()
	{
		var quizService = Create();

		Assert.Throws<ArgumentNullException>(() => quizService.GetQuestion(null));
		Assert.Throws<ArgumentException>(() => quizService.GetQuestion(new IntervalQuizQuestionOptions(false, false)));
	}

	[Fact]
	public void GetQuestion_WithOnlyAbove_CreatesAboveQuestions()
	{
		var quizService = Create();

		var question = quizService.GetQuestion(new IntervalQuizQuestionOptions(true, false));
		Assert.NotNull(question);

		var intervalService = new IntervalService(new MajorScaleBuilder(new StepService(_accidentalsService)), _accidentalsService);
		var answer = intervalService.GetAbove(question.StartingNote, question.Interval);

		Assert.Equal(answer, question.Answer);
	}

	[Fact]
	public void GetQuestion_WithOnlyBelow_CreatesBelowQuestions()
	{
		var quizService = Create();

		var question = quizService.GetQuestion(new IntervalQuizQuestionOptions(false, true));
		Assert.NotNull(question);

		var intervalService = new IntervalService(new MajorScaleBuilder(new StepService(_accidentalsService)), _accidentalsService);
		var answer = intervalService.GetBelow(question.StartingNote, question.Interval);

		Assert.Equal(answer, question.Answer);
	}

	private IntervalQuizService Create() => new IntervalQuizService(new NoteFactory(_accidentalsService, _randomService), new IntervalFactory(_randomService), new IntervalService(new MajorScaleBuilder(new StepService(_accidentalsService)), _accidentalsService), _randomService);
}
