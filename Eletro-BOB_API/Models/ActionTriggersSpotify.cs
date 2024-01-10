using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Eletro_BOB_API.Models
{
    public class ActionTriggersSpotify
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int nbMin { get; set; }
        public string PlaylistName { get; set; }

        public DateTime NextTrigger { get; set; }

        [ForeignKey("Area")]
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }
    }
}
