using Data;
using DatabaseModel.Database;
using DatabaseModel.FindPerson;
using DatabaseModel.TreeFormer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Model
{
    class Model : IModel
    {
        protected IFindPerson findPerson;
        protected ITreeFormer treeFormer;

        public Model()
        {
            IDatabase dataBase = new Database.Database();
            findPerson = new FindPerson.FindPerson(ref dataBase);
            treeFormer = new TreeFormer.TreeFormer(ref dataBase);
        }

        public IDictionary<Int32, Person> FindPeople(Person mask)
        {
            throw new NotImplementedException();
        }

        public IDictionary<Int32, Person> GetPeople(Person mask)
        {
            throw new NotImplementedException();
        }

        public IDictionary<Int32, Person> BuildTree(Int32 code)
        {
            throw new NotImplementedException();
        }
    }
}
