using torsani.giacomo._4i.LibSlotMachine;

SlotMachine Machine = new SlotMachine();
int input;

do
{
    Console.WriteLine("premere '1' per girare e premere '2' per ritirare");
    input = Convert.ToInt16(Console.ReadLine());
    switch (input)
    {
        case 1:
            Machine.Gira();
            break;
        case 2:
            Machine.Ritira();
            break;
        default:
            Console.WriteLine("hai inserito un valore non valido");
            break;
    }
} while (Machine.GetCoin() != 0);

if(Machine.GetCoin() == 0)
{
    Console.WriteLine("Hai finito le monete!");
}