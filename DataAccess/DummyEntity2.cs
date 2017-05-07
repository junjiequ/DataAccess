using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class DummyEntity2:IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EntityProperty2 { get; set; }
    }
}
