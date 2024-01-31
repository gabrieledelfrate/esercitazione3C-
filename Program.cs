namespace ContoCorrente
{

    class ContoCorrente
    {
        private string nomeCliente;
        private string numeroConto;
        private double saldo;

        public ContoCorrente(string nomeCliente, string numeroConto)
        {
            this.nomeCliente = nomeCliente;
            this.numeroConto = numeroConto;
            this.saldo = 0;
        }

        public void VisualizzaInfoConto()
        {
            Console.WriteLine($"Nome Cliente: {nomeCliente}");
            Console.WriteLine($"Numero Conto: {numeroConto}");
            Console.WriteLine($"Saldo Attuale: {saldo:C}");
        }

        public void Versamento(double importo)
        {
            if (importo > 0)
            {
                saldo += importo;
                Console.WriteLine($"Versamento di {importo:C} effettuato con successo.");
            }
            else
            {
                Console.WriteLine("L'importo del versamento deve essere maggiore di zero.");
            }
        }

        public void Prelevamento(double importo)
        {
            if (importo > 0 && importo <= saldo)
            {
                saldo -= importo;
                Console.WriteLine($"Prelevamento di {importo:C} effettuato con successo.");
            }
            else
            {
                Console.WriteLine("Importo non valido o saldo insufficiente per il prelevamento.");
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            ContoCorrente mioConto = null;

            while (true)
            {
                Console.WriteLine("Seleziona un'opzione:");
                Console.WriteLine("1. Apertura conto");
                Console.WriteLine("2. Versamento");
                Console.WriteLine("3. Prelevamento");
                Console.WriteLine("4. Visualizza saldo");
                Console.WriteLine("5. Esci");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        Console.WriteLine("Inserisci il nome del cliente:");
                        string nomeCliente = Console.ReadLine();
                        Console.WriteLine("Inserisci il numero del conto:");
                        string numeroConto = Console.ReadLine();
                        mioConto = new ContoCorrente(nomeCliente, numeroConto);
                        Console.WriteLine("Conto aperto con successo!");
                        break;

                    case "2":
                        if (mioConto != null)
                        {
                            Console.WriteLine("Inserisci l'importo da versare:");
                            double importoVersamento;
                            if (double.TryParse(Console.ReadLine(), out importoVersamento))
                            {
                                mioConto.Versamento(importoVersamento);
                            }
                            else
                            {
                                Console.WriteLine("Inserisci un importo valido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Apri un conto prima di effettuare un versamento.");
                        }
                        break;

                    case "3":
                        if (mioConto != null)
                        {
                            Console.WriteLine("Inserisci l'importo da prelevare:");
                            double importoPrelevamento;
                            if (double.TryParse(Console.ReadLine(), out importoPrelevamento))
                            {
                                mioConto.Prelevamento(importoPrelevamento);
                            }
                            else
                            {
                                Console.WriteLine("Inserisci un importo valido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Apri un conto prima di effettuare un prelevamento.");
                        }
                        break;

                    case "4":
                        if (mioConto != null)
                        {
                            mioConto.VisualizzaInfoConto();
                        }
                        else
                        {
                            Console.WriteLine("Apri un conto prima di visualizzare il saldo.");
                        }
                        break;

                    case "5":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }
            }
        }
    }
}
