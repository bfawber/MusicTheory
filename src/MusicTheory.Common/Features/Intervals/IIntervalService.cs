using MusicTheory.Common.Features.Notes;

namespace MusicTheory.Common.Features.Intervals;

public interface IIntervalService
{
    Note Get(Note startingNote, IInterval interval);
}
