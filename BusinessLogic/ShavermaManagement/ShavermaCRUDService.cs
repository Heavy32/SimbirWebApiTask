using Data;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.ShavermaManagement
{
    public class ShavermaCRUDService : IShavermaCRUDService
    {
        private readonly IDataProvider<ShavermaDataModel> shavermaRepository;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public ShavermaCRUDService(IDataProvider<ShavermaDataModel> shavermaRepository, IMapper mapper, ILogger logger)
        {
            this.shavermaRepository = shavermaRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public ServiceResult<ShavermaServiceModel> Create(ShavermaCreateModel item)
        {
            var newUser = new ShavermaDataModel(
                new Random().Next(0, int.MaxValue),
                item.Name,
                item.Price);

            int id = shavermaRepository.Create(newUser);

            return new ServiceResult<ShavermaServiceModel>(StatusCode.ItemCreated, new ShavermaServiceModel(id, item.Name, item.Price));
        }

        public ServiceResult<ShavermaServiceModel> Delete(int id)
        {
            ShavermaDataModel shavermaFromDb = shavermaRepository.Get(id);
            if (shavermaFromDb == null)
            {
                logger.Error("Shaverma is not found");
                return new ServiceResult<ShavermaServiceModel>(StatusCode.ItemNotFound, "Shaverma is not found");
            }

            shavermaRepository.Delete(id);

            return new ServiceResult<ShavermaServiceModel>(StatusCode.ItemDeleted);
        }

        public ServiceResult<ShavermaServiceModel> Get(int id)
        {
            ShavermaDataModel shavermaFromDb = shavermaRepository.Get(id);
            if (shavermaFromDb == null)
            {
                logger.Error("Shaverma is not found");
                return new ServiceResult<ShavermaServiceModel>(StatusCode.ItemNotFound, "Shaverma is not found");
            }

            var shaverma = mapper.Map<ShavermaDataModel, ShavermaServiceModel>(shavermaFromDb);

            return new ServiceResult<ShavermaServiceModel>(StatusCode.ItemRecieved, shaverma);
        }

        public ServiceResult<IReadOnlyCollection<ShavermaServiceModel>> GetAll()
        {
            IReadOnlyCollection<ShavermaDataModel> shavermas = shavermaRepository.GetAll();
            if (shavermas.Count == 0)
            {
                return new ServiceResult<IReadOnlyCollection<ShavermaServiceModel>>(StatusCode.NoContent);
            }

            return new ServiceResult<IReadOnlyCollection<ShavermaServiceModel>>(
                StatusCode.ItemRecieved,
                shavermas.Select(shaverma => mapper.Map<ShavermaDataModel, ShavermaServiceModel>(shaverma)) as IReadOnlyCollection<ShavermaServiceModel>);
        }

        public ServiceResult<ShavermaServiceModel> Update(int id, ShavermaServiceModel item)
        {
            ShavermaDataModel shavermaFromDb = shavermaRepository.Get(id);
            if (shavermaFromDb == null)
            {
                logger.Error("Shaverma is not found");
                return new ServiceResult<ShavermaServiceModel>(StatusCode.ItemNotFound, "Shaverma is not found");
            }

            shavermaRepository.Update(id, mapper.Map<ShavermaServiceModel, ShavermaDataModel>(item));

            return new ServiceResult<ShavermaServiceModel>(StatusCode.ItemUpdated);
        }
    }
}
