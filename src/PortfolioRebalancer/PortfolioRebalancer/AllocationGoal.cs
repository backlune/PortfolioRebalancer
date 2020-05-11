namespace PortfolioRebalancer
{
    public class AllocationGoal
    {
        public AllocationGoal(decimal allocation, decimal leverage)
        {
            Allocation = allocation;
            Leverage = leverage;
        }

        public decimal Allocation { get; set; }
        public decimal Leverage { get; set; }
    }
}
