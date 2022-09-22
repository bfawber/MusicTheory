using MusicTheory.Common.Features.Accidentals;
using MusicTheory.Common.Features.Intervals;
using MusicTheory.Common.Features.Intervals.Creation;
using MusicTheory.Common.Features.Notes.Creation;
using MusicTheory.Common.Features.Quiz.Interval;
using MusicTheory.Common.Features.Scales;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IStepService, StepService>();
builder.Services.AddSingleton<MajorScaleBuilder>();
builder.Services.AddSingleton<IAccidentalsService, AccidentalsService>();
builder.Services.AddSingleton<INoteFactory, NoteFactory>();
builder.Services.AddSingleton<IIntervalFactory, IntervalFactory>();
builder.Services.AddSingleton<IIntervalService, IntervalService>();
builder.Services.AddSingleton<IIntervalQuizService, IntervalQuizService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
