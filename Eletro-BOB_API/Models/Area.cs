
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eletro_BOB_API.Models
{
    public class Area
    {
        public Area(int id, string name, string description, int actionId, int reactionId)        {
            Id = id;
            Name = name;
            Description = description;
            ActionId = actionId;
            ReactionId = reactionId;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        [ForeignKey("ActionTrigger")]
        public int ActionId { get; set; }
        public virtual ActionTrigger ActionTrigger { get; set; }
        
        [ForeignKey("ReactionTrigger")]
        public int ReactionId { get; set; }
        public virtual ReactionTrigger ReactionTrigger { get; set; }
    }
}
