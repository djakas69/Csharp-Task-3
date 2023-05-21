using System.ComponentModel.DataAnnotations;

namespace Csharp_Task_3.Models.Dto
{
    public class PinDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(8)]
        public string CalulatedPin { get; set; }
    }
}
