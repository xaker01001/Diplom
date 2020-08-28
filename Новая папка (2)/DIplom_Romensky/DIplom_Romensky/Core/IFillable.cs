using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIplom_Romensky.Core
{
   public interface IFillable<Tin,Tout>
    {
        Tout Fill(Tin data);
    }
}
