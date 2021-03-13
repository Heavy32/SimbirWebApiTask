using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public abstract class CRUDService<TModel, TCreateModel> : ICRUDService<TModel, TCreateModel> where TModel : IUniqueModel
    {
        private readonly IDataProvider<TModel> dataProvider;
        private readonly IMapper mapper;

        protected CRUDService(IDataProvider<TModel> dataProvider, IMapper mapper)
        {
            this.dataProvider = dataProvider;
            this.mapper = mapper;
        }

        public virtual ServiceResult<TModel> Create(TCreateModel item)
        {
            throw new NotImplementedException();
        }

        public virtual ServiceResult<TModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual ServiceResult<TModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public virtual ServiceResult<IReadOnlyCollection<TModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual ServiceResult<TModel> Update(int id, TModel item)
        {
            throw new NotImplementedException();
        }
    }
}
