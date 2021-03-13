using BusinessLogic.ShavermaManagement;
using BusinessLogic.UserManagement;
using Data;
using System;
using System.Collections.Generic;

namespace BusinessLogic.OrderManagement
{
    public class OrderServiceCreateModel
    {
        public OrderServiceCreateModel(UserServiceModel user, IList<ShavermaServiceModel> shavermas, float price, DateTime time, string adress)
        {
            User = user;
            Shavermas = shavermas;
            Price = price;
            Time = time;
            Adress = adress;
        }

        public UserServiceModel User { get; }
        public IList<ShavermaServiceModel> Shavermas { get; }
        public float Price { get; }
        public DateTime Time { get; }
        public string Adress { get; }
    }
}
