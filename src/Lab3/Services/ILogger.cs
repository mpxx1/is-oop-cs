using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public interface ILogger
{
    public void PrintMessages(IList<IMessage> messages);
}