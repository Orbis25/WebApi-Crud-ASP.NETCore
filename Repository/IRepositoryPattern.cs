using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IRepositoryPattern<Entity> where Entity : class
    {

        bool Add(Entity entity);
        bool Update(Entity entity);
        bool Delete(int id);
        IEnumerable<Entity> GetAll();
        Entity Get(int id);
    }
}
