using Common.Interfaces;

namespace ShoppingCartAPI.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYeat => DateTime.Now.Year;
    }
}
