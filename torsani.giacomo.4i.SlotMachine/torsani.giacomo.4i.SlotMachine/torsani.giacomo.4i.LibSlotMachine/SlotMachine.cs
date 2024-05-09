namespace torsani.giacomo._4i.LibSlotMachine
{
    public class SlotMachine
    {

        /*
        SLOT MACHINE
        Creare una classe che permetta di rappresentare una slot machine: deve funzionare ogni moneta inserita da diritto ad una partita in cui
        girano le tre rotelle della slot machine e appaiono tre simboli (nel nostro caso tre lettere a caso dall'alfabeto italiano).
        */
        private char let1 { get; set; }
        private char let2 { get; set; }
        private char let3 { get; set; }
        private int coin { get; set; }
        private int vincita { get; set; }
        private char[] lettere = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'Z' };
        private Random r = new Random();

        public int GetCoin()
        {
            return coin;
        }

        public SlotMachine()
        {
            let1 = 'A';
            let2 = 'A';
            let3 = 'A';
            Console.WriteLine("quante monete volete inserire??");
            coin = Convert.ToInt16(Console.ReadLine());
        }
        public void Gira()
        {
            coin--;

            let1 = lettere[r.Next(21)];
            let2 = lettere[r.Next(21)];
            let3 = lettere[r.Next(21)];

            Controllo();
        }

        //Le monete vinte possono essere rigiocate oppure riscosse dal giocatore.
        public void Ritira()
        {
            coin = 0;
            Console.WriteLine($"Hai ritirato tutte le monete.");
        }

        private void Controllo()
        {
            vincita = 0;
            Console.WriteLine($"in questo giro è uscito {let1}\t{let2}\t{let3}");

            //-se c’è una coppia viene restituita una moneta
            if (let1 == let2 || let1 == let3 || let2 == let3)
            {
                vincita = 1;
                coin += vincita;
                Console.WriteLine($"complimenti hai fatto una coppia, hai vinto {vincita} monete");
            }

            //-se c’è un tris di lettere uguali vengono restituite un numero di monete pari alla posizione in ordine alfabetico della lettera del
            //tris(es.tre C corrispondono a 3 monete)
            if (let1 == let2 && let2 == let3)
            {

                //-se ci sono tre Z allora è JACKPOT e vengono restituite 100 monetine
                if (let1 == 'Z')
                {
                    vincita = 100;
                    coin += vincita;
                    Console.WriteLine($"WOW HAI FATTO JACKPOT, HAI VINTO {vincita} MONETE!!!");
                }
                vincita = Convert.ToInt16(r);
                coin += vincita;
                Console.WriteLine($"complimenti hai fatto tris, hai vinto {vincita} monete");
            }

            //-se ci sono tre lettere consecutive(es.ABC oppure EFG) vengono restituite 50 monete
            if ((byte)let1 + 1 == (byte)let2 && (byte)let3 == (byte)let2 + 1)
            {
                vincita = 50;
                coin += vincita;
                Console.WriteLine($"complimenti hai fatto scala, hai vinto {vincita} monete");
            }
            Console.WriteLine($"le monete rimaste sono {coin}");
            //altrimenti non viene restituito nulla e si passa alla partita successiva inserendo una nuova monetina.
        }

        public bool WPFControl()
        {
            
            //-se c’è una coppia viene restituita una moneta
            if (let1 == let2 || let1 == let3 || let2 == let3)
            {
                vincita = 1;
                coin += vincita;
                return true;
            }

            //-se c’è un tris di lettere uguali vengono restituite un numero di monete pari alla posizione in ordine alfabetico della lettera del
            //tris(es.tre C corrispondono a 3 monete)
            else if (let1 == let2 && let2 == let3)
            {
                //-se ci sono tre Z allora è JACKPOT e vengono restituite 100 monetine
                if (let1 == 'Z')
                {
                    vincita = 100;
                    coin += vincita;
                    return true;
                }
                vincita = Convert.ToInt16(r);
                coin += vincita;
                return true;
            }

            //-se ci sono tre lettere consecutive(es.ABC oppure EFG) vengono restituite 50 monete
            else if ((byte)let1 + 1 == (byte)let2 && (byte)let3 == (byte)let2 + 1)
            {
                vincita = 50;
                coin += vincita;
                return true;
            }
            //altrimenti non viene restituito nulla e si passa alla partita successiva inserendo una nuova monetina.
            return false;
        }
    }
}