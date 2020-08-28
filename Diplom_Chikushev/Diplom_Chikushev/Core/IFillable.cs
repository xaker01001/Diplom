using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom_Chikushev.Core
{
    public interface IFillable<TIn, TOut>
    {
        TOut Fill(TIn data);
    }
}
