using System;
using System.Collections.Generic;

namespace Data
{
    public class OrderDataModel : IUniqueModel
    {
        public OrderDataModel(int id, UserDataModel user, IList<ShavermaDataModel> shavermas, float price, DateTime time, string adress)
        {
            Id = id;
            User = user;
            Shavermas = shavermas;
            Price = price;
            Time = time;
            Adress = adress;
        }

        public int Id { get; }
        public UserDataModel User { get; }
        public IList<ShavermaDataModel> Shavermas { get; }
        public float Price { get; }
        public DateTime Time { get; }
        public string Adress { get; }
    }
}
