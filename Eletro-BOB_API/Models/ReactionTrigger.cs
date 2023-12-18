using System.ComponentModel.DataAnnotations;

namespace Eletro_BOB_API.Models
{
    public class ReactionTrigger
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
    }
}
