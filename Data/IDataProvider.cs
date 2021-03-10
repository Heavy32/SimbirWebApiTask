using System.Collections.Generic;

namespace Data
{
    public interface IDataProvider<T>
    {
        public T Get(int id);
        public IReadOnlyCollection<T> GetAll();
        public void Delete(int id);
        public int Create(T model);
        public void Update(int id, T newModel);
    }
}
