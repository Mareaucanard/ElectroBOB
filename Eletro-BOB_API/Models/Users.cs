using System.ComponentModel.DataAnnotations;

namespace Eletro_BOB_API.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int PreferenceId { get; set; }
        public virtual Preference Preference { get; set; }
    }
}
