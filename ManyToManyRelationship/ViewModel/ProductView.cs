namespace ManyToManyRelationship.ViewModel
{
    public class ProductView
    {
    
        public string ProductName { get; set; }
        public string Description { get; set; }
        public List<Guid> CategoryIds { get; set; }=new List<Guid>();
    }
}
