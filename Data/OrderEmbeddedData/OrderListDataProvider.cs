using System.Collections.Generic;

namespace Data.OrderEmbeddedData
{
    public class OrderListDataProvider : ListDataProvider<Order>
    {
        protected override IList<Order> SeedList()
        {
            return new List<Order>();
        }
    }
}
