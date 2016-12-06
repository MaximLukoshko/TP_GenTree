using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.TreeFormer
{
    internal interface ITreeFormer
    {
        IDictionary<Int32, Person> FormTree(Int32 code);
    }
}
