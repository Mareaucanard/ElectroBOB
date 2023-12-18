using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eletro_BOB_API.Models
{
    public class Preference
    {
        [Key]
        public int Id { get; set; }
        public bool ActiveNotifications { get; set; }
        public bool ActiveEmail { get; set; }
        public bool ActiveSMS { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
