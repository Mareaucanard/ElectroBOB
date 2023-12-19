using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eletro_BOB_API.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Preference> Preferences { get; set; }
        public virtual ICollection<Area> Areas { get; set; }
    }
}
