using BusinessLogic.UserManagement;
using Data;
using System.Collections.Generic;

namespace BusinessLogic
{
    public interface ICRUDService<T, TCreateModel> where T : IUniqueModel
    {
        public ServiceResult<T> Get(int id);
        public ServiceResult<T> Create(TCreateModel item);
        public ServiceResult<T> Delete(int id);
        public ServiceResult<T> Update(int id, T item);
        public ServiceResult<IReadOnlyCollection<T>> GetAll();
    }
}
