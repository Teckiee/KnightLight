using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightLight.Core.Events;

public class ChannelValueEvent(Guid Id, double Value)
{
    public Guid Id { get; } = Id;
    public double Value { get; } = Value;
}
