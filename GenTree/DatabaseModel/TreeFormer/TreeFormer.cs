using Data;
using DatabaseModel.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.TreeFormer
{
    class TreeFormer : ITreeFormer
    {
        protected IDatabase database;
        public TreeFormer(IDatabase dtBase)
        {
            if (null == dtBase)
                throw new NullReferenceException();

            database = dtBase;
        }

        public IDictionary<Int32, Person> FormTree(Int32 code)
        {
            throw new NotImplementedException();
        }
    }
}
