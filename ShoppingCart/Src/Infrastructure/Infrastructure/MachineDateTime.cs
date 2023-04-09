using Common.Interfaces;

namespace Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYeat => DateTime.Now.Year;
    }
}
