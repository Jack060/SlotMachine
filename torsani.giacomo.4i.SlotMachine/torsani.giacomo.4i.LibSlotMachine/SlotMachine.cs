namespace torsani.giacomo._4i.LibSlotMachine
{
    public class SlotMachine
    {
        public int Credito { get; set; }
        public SlotMachine()
        {
            Credito = 0;
        }

        public SlotMachine(int credito)
        {
            this.Credito = credito;
        }
    }
}
