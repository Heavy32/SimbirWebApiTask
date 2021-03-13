using System.Collections.Generic;

namespace Data.UserEmbeddedData
{
    public class UserListDataProvider : ListDataProvider<UserDataModel>
    {      
        protected override IList<UserDataModel> SeedList()
            => new List<UserDataModel>
            {
                new UserDataModel(1, "Alex", "123456", UserStatus.Basic),
                new UserDataModel(2, "Jora", "123456", UserStatus.Regular),
                new UserDataModel(3, "Pojiratel", "123456", UserStatus.Vip),
                new UserDataModel(4, "Bomj", "123456", UserStatus.Basic),
                new UserDataModel(5, "Oleg", "123456", UserStatus.Vip)
            };
    }
}
