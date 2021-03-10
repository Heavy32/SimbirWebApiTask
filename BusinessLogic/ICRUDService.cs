using BusinessLogic.UserManagement;
using Data;
using System.Collections.Generic;

namespace BusinessLogic
{
    public interface ICRUDService<T> where T : IUniqueModel
    {
        public ServiceResult<T> Get(int id);
        public ServiceResult<T> Create(UserServiceCreateModel item);
        public ServiceResult<T> Delete(int id);
        public ServiceResult<T> Update(int id, T item);
        public ServiceResult<IReadOnlyCollection<T>> GetAll();
    }
}
