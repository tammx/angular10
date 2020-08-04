using System.ComponentModel.DataAnnotations;

namespace ModelService
{
    public class Role
    {
        [Key]
        [MaxLength(50)]
        public string Id { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
