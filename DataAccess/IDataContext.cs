using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IDataContext
    {
        IList<DummyEntity1> GetAllDummyEntity1s();
        IList<DummyEntity2> GetAllDummyEntity2s();
    }
}
