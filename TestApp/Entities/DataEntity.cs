namespace TestApp.Entities
{
    public enum CuisineType
    {
        None,
        Italian,
        French,
        Japanese,
        American
    }

    public class DataEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CuisineType Cuisine { get; set;}
    }
}
