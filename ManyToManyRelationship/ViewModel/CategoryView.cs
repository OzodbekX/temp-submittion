namespace ManyToManyRelationship.ViewModel
{
    public class CategoryView
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Guid> ProductIds { get; set; } = new List<Guid>();

    }
}
