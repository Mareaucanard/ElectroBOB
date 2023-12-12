
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

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ActionId { get; set; }
        public int ReactionId { get; set; }
    }
}
