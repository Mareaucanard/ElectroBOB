using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Eletro_BOB_API.Models
{
    public class ReactionTrigger
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Message { get; set; }

        [ForeignKey("Area")]
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }
    }
}
