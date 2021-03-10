using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public abstract class ListDataProvider<T> : IDataProvider<T> where T : IUniqueModel 
    {
        protected readonly IList<T> items;

        public ListDataProvider()
        {
            items = SeedList();
        }

        public virtual int Create(T model)
        {
            items.Add(model);
            return model.Id;
        }

        public virtual void Delete(int id)
        {
            items.Remove(items[id]);
        }

        public virtual T Get(int id)
        {
            return items.FirstOrDefault(item => item.Id == id);
        }

        public virtual IReadOnlyCollection<T> GetAll()
        {
            return items as IReadOnlyCollection<T>;
        }

        public virtual void Update(int id, T newModel)
        {
            items[id] = newModel;
        }

        protected abstract IList<T> SeedList();
    }
}
