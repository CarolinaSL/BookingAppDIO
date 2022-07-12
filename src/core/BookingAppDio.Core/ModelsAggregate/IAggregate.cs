using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAppDio.Core.ModelsAggregate
{
    public interface IAggregate<out T> : IAggregate
    {
        T Id { get; }
    }

    public interface IAggregate
    {

    }
}
