namespace Project.CSharpFiles
{
    public class KPIData
    {
        public KPIData(string year, string month, string sales, string views, string viewsPerSale)
        {
            this.Year = year;
            this.Month = month;
            this.Sales = sales;
            this.Views = views;
            this.ViewsPerSale = viewsPerSale;
        }

        public string Year { get; set; }
        public string Month { get; set; }
        public string Sales { get; set; }
        public string Views { get; set; }
        public string ViewsPerSale { get; set; }
    }
}