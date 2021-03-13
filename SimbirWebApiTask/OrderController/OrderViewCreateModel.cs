using BusinessLogic.ShavermaManagement;
using BusinessLogic.UserManagement;
using System;
using System.Collections.Generic;

namespace SimbirWebApiTask.OrderController
{
    public class OrderViewCreateModel
    {
        public UserServiceModel User { get; set; }
        public IList<ShavermaServiceModel> Shavermas { get; set; }
        public float Price { get; set; }
        public DateTime Time { get; set; }
        public string Adress { get; set; }
    }
}
