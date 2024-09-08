namespace Abby.Utility
{
    public static class SD
    {
        public const string ManagerRole = "Manager";
        public const string FrontDeskRole = "Front";
        public const string KitchenRole = "Kitchen";
        public const string CustomerRole = "Customer";

        public const string StatusPendingPayment = "Pending_Payment";
        public const string StatusSubmittedPaymentApproved = "Submitted_PaymentApproved";
		public const string StatusInProccess = "Being_Prepared";
		public const string StatusReadyForPickup = "Ready_For_Pickup";
		public const string StatusCompleted = "Completed";

		public const string StatusRejectedPayment = "Rejected_Payment";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";

        public const string CartCountKey = "CartCount";
    }
}
