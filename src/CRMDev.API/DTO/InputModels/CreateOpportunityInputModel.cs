using CRMDev.API.Entities;
using CRMDev.API.Enums;

namespace CRMDev.API.DTO.InputModels
{
    public class CreateOpportunityInputModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Budget { get; set; }
        public bool HasSupport { get; set; }
        public StatusEnum Status { get; set; }
        public ReasonEnum Reason { get; set; }
    }
}