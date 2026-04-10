namespace WinFormsKursach.Models
{
    public class Phones
    {
        public int Id { get; set; }
        public string Name { get; set; } = " ";
        public string Producer { get; set; } = " ";
        public decimal Price { get; set; }
        public string Os { get; set; } = " ";           
        public string ScreenSize { get; set; } = " ";   
        public string ScreenTech { get; set; } = " ";
        public string ScreenResolution { get; set; } = " ";
        public int ScreenRefreshHz { get; set; }
        public string Processor { get; set; } = " ";
        public int RamGb { get; set; }
        public int StorageGb { get; set; }
        public int CameraMp { get; set; }
        public int BatteryMah { get; set; }
        public string Waterproof { get; set; } = " ";
        public string ImageUrl { get; set; } = " ";
        public string Description { get; set; } = " ";
        public bool InStock { get; set; } = true;

    }
}
