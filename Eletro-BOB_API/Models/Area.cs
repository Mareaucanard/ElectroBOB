
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eletro_BOB_API.Models
{
    public class Area
    {
        /*public Area(int id, string name, string description, bool isactive, int userid)        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = isactive;
            UsersId = userid;
        }*/

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("Users")]
        public int UsersId { get; set; }
        public virtual Users Users { get; set; }
        public virtual ICollection<ActionTrigger> ActionTriggers { get; set; }
        public virtual ICollection<ReactionTrigger> ReactionTriggers { get; set; }
    }
}
