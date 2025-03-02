namespace ITM.Models
{
    public class FacilityView
    {
        public int FacilityId { get; set; }

        public string FacilityName { get; set; } = null!;

        public string FacilityDesc { get; set; } = null!;

        public IFormFile FacilityImg { get; set; } = null!;
    }
}
