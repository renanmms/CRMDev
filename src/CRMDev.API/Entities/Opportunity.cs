using CRMDev.API.Enums;

namespace CRMDev.API.Entities
{
    public class Opportunity
    {
        public Opportunity(
            string? title,
            string? description,
            DateTime dueDate,
            decimal budget,
            bool hasSupport,
            StatusEnum status,
            ReasonEnum reason)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Budget = budget;
            HasSupport = hasSupport;
            Status = status;
            Reason = reason;
        }

        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Budget { get; set; }
        public bool HasSupport { get; set; }
        public StatusEnum Status { get; set; }
        public ReasonEnum Reason { get; set; }

    }
}