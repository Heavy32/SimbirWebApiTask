using Data;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BusinessLogic.UserManagement
{
    public class UserCRUDService : ICRUDService<UserServiceModel>
    {
        private readonly IDataProvider<UserDataModel> userRepository;
        private readonly IMapper mapper;

        public UserCRUDService(IDataProvider<UserDataModel> userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public ServiceResult<UserServiceModel> Create(UserServiceCreateModel item)
        {
            UserDataModel userFromDb = userRepository.GetAll().FirstOrDefault(u => u.Login == item.Login);
            if (userFromDb != null)
            {
                return new ServiceResult<UserServiceModel>(StatusCode.ItemAlreadyCreated, "User is with such name is already exist");
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

            var user = mapper.Map<UserDataModel,UserServiceModel>(userFromDb);

            return new ServiceResult<UserServiceModel>(StatusCode.ItemRecieved, user);
        }

        public ServiceResult<IReadOnlyCollection<UserServiceModel>> GetAll()
        {
            IReadOnlyCollection<UserDataModel> users = userRepository.GetAll();
            if(users.Count == 0)
            {
                return new ServiceResult<IReadOnlyCollection<UserServiceModel>>(StatusCode.NoContent);
            }

            return new ServiceResult<IReadOnlyCollection<UserServiceModel>>(StatusCode.ItemRecieved, users.Select(user => mapper.Map<UserDataModel, UserServiceModel>(user)) as IReadOnlyCollection<UserServiceModel>);
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
