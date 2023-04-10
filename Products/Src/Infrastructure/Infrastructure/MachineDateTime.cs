using Common.Interfaces;

namespace ProductsAPI.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYeat => DateTime.Now.Year;
    }
}
