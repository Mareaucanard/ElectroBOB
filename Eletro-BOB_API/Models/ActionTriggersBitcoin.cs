using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Eletro_BOB_API.Models
{
    public class ActionTriggersBitcoin
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int nbMin { get; set; }
        public int minValue { get; set; }
        public int maxValue { get; set; }
        public int comparePercent { get; set; }
        public DateTime NextTrigger { get; set; }

        [ForeignKey("Area")]
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }
    }
}
