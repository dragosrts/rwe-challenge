namespace Rwe.App.Entities
{
    public class Park
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public IEnumerable<Turbine> Turbines { get; set; }
    }
}