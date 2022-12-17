using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManyToManyRelationship.Models
{
    public class ProductCategory
    {
       public Guid CategoryId { get; set; }
        public Guid ProductId { get; set; }
       public virtual Category Category { get; set; }
       public virtual Product Product { get; set; }
    }
}
