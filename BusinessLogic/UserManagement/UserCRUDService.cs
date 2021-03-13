using Data;
using System.Collections.Generic;
using System;
using System.Linq;
using NLog;

namespace BusinessLogic.UserManagement
{
    public class UserCRUDService : IUserCRUDService
    {
        private readonly IDataProvider<UserDataModel> userRepository;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public UserCRUDService(IDataProvider<UserDataModel> userRepository, IMapper mapper, ILogger logger)
        {
            this.logger = logger;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public ServiceResult<UserServiceModel> Create(UserServiceCreateModel item)
        {
            UserDataModel userFromDb = userRepository.GetAll().FirstOrDefault(u => u.Login == item.Login);
            if (userFromDb != null)
            {
                logger.Error("User with such name is already exist");
                return new ServiceResult<UserServiceModel>(StatusCode.ItemAlreadyCreated, "User with such name is already exist");
            }

            var newUser = new UserDataModel(
                new Random().Next(0, int.MaxValue),
                item.Login,
                item.Password,
                item.UserStatus);

            int id = userRepository.Create(newUser);

            return new ServiceResult<UserServiceModel>(StatusCode.ItemCreated, new UserServiceModel(id, item.Login, item.Password, item.UserStatus));
        }

        public ServiceResult<UserServiceModel> Delete(int id)
        {
            UserDataModel userFromDb = userRepository.Get(id);
            if (userFromDb == null)
            {
                return new ServiceResult<UserServiceModel>(StatusCode.ItemNotFound, "User is not found");
            }

            userRepository.Delete(id);

            return new ServiceResult<UserServiceModel>(StatusCode.ItemDeleted);
        }

        public ServiceResult<UserServiceModel> Get(int id)
        {
            UserDataModel userFromDb = userRepository.Get(id);
            if (userFromDb == null)
            {
                return new ServiceResult<UserServiceModel>(StatusCode.ItemNotFound, "User is not found");
            }

            var user = mapper.Map<UserDataModel, UserServiceModel>(userFromDb);

            return new ServiceResult<UserServiceModel>(StatusCode.ItemRecieved, user);
        }

        public ServiceResult<IReadOnlyCollection<UserServiceModel>> GetAll()
        {
            IReadOnlyCollection<UserDataModel> users = userRepository.GetAll();
            if(users.Count == 0)
            {
                return new ServiceResult<IReadOnlyCollection<UserServiceModel>>(StatusCode.NoContent);
            }
            return new ServiceResult<IReadOnlyCollection<UserServiceModel>>(StatusCode.ItemRecieved, users.Select(user => mapper.Map<UserDataModel, UserServiceModel>(user)).ToList().AsReadOnly());
        }

        public ServiceResult<UserServiceModel> Update(int id, UserServiceModel item)
        {
            UserDataModel userFromDb = userRepository.Get(id);
            if (userFromDb == null)
            {
                return new ServiceResult<UserServiceModel>(StatusCode.ItemNotFound, "User is not found");
            }

            userRepository.Update(id, mapper.Map<UserServiceModel, UserDataModel>(item));

            return new ServiceResult<UserServiceModel>(StatusCode.ItemUpdated);
        }
    }
}
