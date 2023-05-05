using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern1
{
    internal interface IComponent
    {
        int GetNumberOfEmails();

        string PrintStructure();
    }
}
