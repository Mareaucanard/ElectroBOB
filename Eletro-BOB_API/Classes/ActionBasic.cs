using System.ComponentModel.DataAnnotations.Schema;

namespace Eletro_BOB_API.Classes
{
    public class ActionBasic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int nbMin { get; set; }
        public int AreaId { get; set; }
    }
}
