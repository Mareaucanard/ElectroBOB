using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eletro_BOB_API.Models
{
    public class ActionTrigger
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set;}

        [ForeignKey("Area")]
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }
    }
}
