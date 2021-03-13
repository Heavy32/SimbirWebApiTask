using System.Collections.Generic;

namespace Data.OrderEmbeddedData
{
    public class OrderListDataProvider : ListDataProvider<OrderDataModel>
    {
        protected override IList<OrderDataModel> SeedList()
        {
            return new List<OrderDataModel>();
        }

        public override int Create(OrderDataModel model)
        {
            return base.Create(model);
        }
    }
}
