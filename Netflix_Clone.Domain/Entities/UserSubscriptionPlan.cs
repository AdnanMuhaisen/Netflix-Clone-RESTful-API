﻿namespace Netflix_Clone.Domain.Entities
{
    public class UserSubscriptionPlan
    {

        public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsEnded { get; set; }
        public bool IsPaid { get; set; } = false;


        public string UserId { get; init; } = string.Empty;
        public ApplicationUser ApplicationUser { get; set; } = default!;
        public int SubscriptionPlanId { get; init; }
        public SubscriptionPlan SubscriptionPlan { get; set; } = default!;
    }
}
