using System.ComponentModel.DataAnnotations.Schema;

namespace Eletro_BOB_API.Classes
{
    public class AreaBasic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int UsersId { get; set; }
        public ActionBasic action { get; set; }
        public ReactionBasic[] reactions { get; set; }
    }
}
