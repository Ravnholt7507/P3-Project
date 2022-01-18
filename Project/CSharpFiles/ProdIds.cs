using System.Collections.Generic;

namespace Project.CSharpFiles
{
    public class ProdId
    {
        public ProdId(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
        public List<KPIData> KpiData = new List<KPIData>();
    }
}