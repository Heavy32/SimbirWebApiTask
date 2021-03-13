using BusinessLogic.ShavermaManagement;
using BusinessLogic.UserManagement;
using Data;
using System;
using System.Collections.Generic;

namespace BusinessLogic.OrderManagement
{
    public class OrderServiceModel : IUniqueModel
    {
        public OrderServiceModel(int id, UserServiceModel user, IList<ShavermaServiceModel> shavermas, float price, DateTime time, string adress)
        {
            Id = id;
            User = user;
            Shavermas = shavermas;
            Price = price;
            Time = time;
            Adress = adress;
        }

        public int Id { get; }
        public UserServiceModel User { get; }
        public IList<ShavermaServiceModel> Shavermas { get; }
        public float Price { get; }
        public DateTime Time { get; }
        public string Adress { get; }
    }
}
