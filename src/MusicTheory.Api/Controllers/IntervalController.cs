using Microsoft.AspNetCore.Mvc;
using MusicTheory.Common.Features.Quiz.Interval;

namespace MusicTheory.Api.Controllers;

[ApiController]
[Route("interval")]
public class IntervalController : ControllerBase
{
	private readonly IIntervalQuizService _quizService;
	private readonly ILogger<IntervalController> _logger;

	public IntervalController(IIntervalQuizService quizService, ILogger<IntervalController> logger)
	{
		_quizService = quizService;
		_logger = logger;
	}

	[HttpGet(Name = "GetIntervalQuestion")]
	public IntervalQuizQuestion Get()
	{
		return _quizService.GetQuestion(new IntervalQuizQuestionOptions(true, false));
	}
}
