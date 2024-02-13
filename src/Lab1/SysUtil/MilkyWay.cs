using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;

namespace Itmo.ObjectOrientedProgramming.Lab1.SysUtil;

public class MilkyWay
{
    private Collection<ISpaceEnv> _way;

    public MilkyWay(Collection<ISpaceEnv> way)
    {
        _way = way;
    }

    public IList<ISpaceEnv> Way
    {
        get { return _way.AsReadOnly(); }
    }
}
