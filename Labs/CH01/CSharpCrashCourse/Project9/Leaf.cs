using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project9
{
    public class Leaf : ITurnable
    {
       public string Turn()
        {
            return "For one to turn over a new leaf. One must seperate from the branches of habit.\n\n";
        }
    }
}
