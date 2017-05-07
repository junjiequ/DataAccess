using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class DummyEntity1:IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string EntityProperty1 { get; set; }
    }
}