using System.ComponentModel.DataAnnotations;

namespace ManyToManyRelationship.Models
{
    public class Product
    {
        public Product()
        {
            this.Categories = new HashSet<Category>();
        }
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Category> Categories { get; set; }

    }
}
