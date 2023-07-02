using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Interfaces
{
    public  interface IGeneralRepo<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>> getAll();
        public Task<TEntity> getById(int id);

        public Task addItem(TEntity item);

        public Task updateItem(TEntity item);
        public Task removeItem(int id);

        public Task saveChanges();
    }
}
