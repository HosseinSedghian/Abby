namespace Abby.Utility
{
    public static class SD
    {
        public const string ManagerRole = "Manager";
        public const string FrontDeskRole = "Front";
        public const string KitchenRole = "Kitchen";
        public const string CustomerRole = "Customer";

        public const string StatusPendingPayment = "Pending";
        public const string StatusSubmittedPaymentApproved = "Submitted";
		public const string StatusInProccess = "InProccess";
		public const string StatusReadyForPickup = "Ready";
		public const string StatusCompleted = "Completed";

		public const string StatusRejectedPayment = "Rejected";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";

        public const string CartCountKey = "CartCount";
    }
}
