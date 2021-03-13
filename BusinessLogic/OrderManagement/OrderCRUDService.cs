using Data;
using System;
using System.Linq;
using System.Collections.Generic;
using BusinessLogic.ShavermaManagement;

namespace BusinessLogic.OrderManagement
{
    public class OrderCRUDService : IOrderCRUDService
    {
        private readonly IDataProvider<OrderDataModel> orderRepository;
        private readonly IDataProvider<UserDataModel> userRepository;
        private readonly IDataProvider<ShavermaDataModel> shavermaRepository;
        private readonly IMapper mapper;

        public OrderCRUDService(IDataProvider<OrderDataModel> orderRepository, IDataProvider<UserDataModel> userRepository, IDataProvider<ShavermaDataModel> shavermaRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.userRepository = userRepository;
            this.shavermaRepository = shavermaRepository;
            this.mapper = mapper;
        }

        public ServiceResult<OrderServiceModel> Create(OrderServiceCreateModel item)
        {
            UserDataModel user = userRepository.Get(item.User.Id);
            IList<ShavermaDataModel> shavermas = item.Shavermas.Select(shaverma => mapper.Map<ShavermaServiceModel, ShavermaDataModel>(shaverma)).ToList();
            
            orderRepository.Create(new OrderDataModel(new Random().Next(0, int.MaxValue), user, shavermas, item.Price, item.Time, item.Adress));

            return new ServiceResult<OrderServiceModel>(StatusCode.ItemCreated, "Order is created");
        }

        public ServiceResult<OrderServiceModel> Delete(int id)
        {
            orderRepository.Delete(id);
            return new ServiceResult<OrderServiceModel>(StatusCode.ItemDeleted);
        }

        public ServiceResult<OrderServiceModel> Get(int id)
        {
            OrderServiceModel order = mapper.Map<OrderDataModel, OrderServiceModel>(orderRepository.Get(id));

            return new ServiceResult<OrderServiceModel>(StatusCode.ItemRecieved, order);
        }

        public ServiceResult<IReadOnlyCollection<OrderServiceModel>> GetAll()
        {
            IReadOnlyCollection<OrderDataModel> orders = orderRepository.GetAll();
            if (orders.Count == 0)
            {
                return new ServiceResult<IReadOnlyCollection<OrderServiceModel>>(StatusCode.NoContent);
            }

            return new ServiceResult<IReadOnlyCollection<OrderServiceModel>>(
                StatusCode.ItemRecieved,
                orders.Select(order => mapper.Map<OrderDataModel, OrderServiceModel>(order)) as IReadOnlyCollection<OrderServiceModel>);
        }

        public ServiceResult<OrderServiceModel> Update(int id, OrderServiceModel item)
        {
            orderRepository.Update(id, mapper.Map<OrderServiceModel, OrderDataModel>(item));

            return new ServiceResult<OrderServiceModel>(StatusCode.ItemUpdated);
        }
    }
}
