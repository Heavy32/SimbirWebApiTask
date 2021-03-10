using System.Collections.Generic;

namespace Data.ShavermaEmbeddedData
{
    public class ShavermaListDataProvider : ListDataProvider<ShavermaDataModel>
    {
        protected override IList<ShavermaDataModel> SeedList()
            => new List<ShavermaDataModel>
            {
                new ShavermaDataModel(1, "King Size XXX", 200),
                new ShavermaDataModel(2, "Classic shaverma", 150),
                new ShavermaDataModel(3, "Spicy shaverma from hell", 170)
            };

    }
}
