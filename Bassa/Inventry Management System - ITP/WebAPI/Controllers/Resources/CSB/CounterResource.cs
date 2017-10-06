using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers.Resources
{
    public class CounterResource
    {
        [Required]
        public long BranchID { get; set; }

        [Required]
        public long CouterNo { get; set; }
    }
}