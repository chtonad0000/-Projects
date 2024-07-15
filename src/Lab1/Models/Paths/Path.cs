using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Paths;

public class Path
{
    public Path(IEnumerable<PathSegment> segments)
    {
        Segments = segments;
    }

    public IEnumerable<PathSegment> Segments { get; private set; }
}