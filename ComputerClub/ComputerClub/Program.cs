namespace ComputerClub
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ComputerClub computerClub = new ComputerClub(8);
            computerClub.Work();
        }
    }

    public class ComputerClub
    {
        private int _balanceMoneyClub;
        private List<Computer> _computers  = new List<Computer>();
        private Queue<Client> _clientQueue = new Queue<Client>();

        public ComputerClub(int computersCount)
        {
            Random random = new Random();
            AddComputers(computersCount, random);
            AddNewClient(25, random);
        }

        public void AddNewClient(int count, Random random)
        {
            for (int i = 0; i < count; i++) _clientQueue.Enqueue(new Client(random.Next(100, 500), random));
        }
        private void AddComputers(int count, Random random)
        {
            for (int i = 0; i < count; i++) _computers.Add(new Computer(random.Next(7, 15)));
        }

        public void Work()
        {
            while (_clientQueue.Count > 0)
            {
                Client newClient = _clientQueue.Dequeue();

                Console.WriteLine($"Баланс комьютерного клуба: {_balanceMoneyClub}! Ждём навого клиента");
                Console.WriteLine($"У вас новый клиент! Он хочет купить своё время для посидолок за комьтером, т.е. {newClient.DiseredMinutes} минут.");
                StatusComputers();

                Console.Write("\nВы предлагаети ему будто самый ебучий комьютер под номером:");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int computerNumber))
                {
                    computerNumber--;
                    Computer computer = _computers[computerNumber];

                    if (computerNumber >= 0 && computerNumber < _computers.Count)
                    {
                        if (computer.IsBusy)
                            Console.WriteLine("Безделица! Клиент вас обосал!");
                        else
                        {
                            if (newClient.CheckSolvency(computer))
                            {
                                Console.WriteLine($"Клиент оказался при деньгах!\nОплачивает.... \nОн сел за комьютер: {computerNumber+1}");
                                _balanceMoneyClub += newClient.Pay();
                                computer.BecomeTake(newClient);
                            }
                            else Console.WriteLine("Клиет бомж! Вы позвали охраника, ему выбили зубы.");
                        } 
                    }

                    else Console.WriteLine("Дебил, ты потерял клиента!");
                }
                else
                {
                    AddNewClient(1, new Random());
                    Console.WriteLine("Неверный ввод! Тем самым вы упустили возможность нажевить денег!");
                }

                Console.WriteLine("Для устранения твоего безделия, нажми любую клавишу.");
                Console.ReadKey();
                Console.Clear();

                SpendOneMinutes();
            }
        }

        
        private void StatusComputers()
        {
            Console.WriteLine("\nСписок всех комьютеров:");
            for (int i = 0; i < _computers.Count; i++)
            {
                Console.Write(i + 1 + " - ");
                _computers[i].ShowState();
            }
        }

        private void SpendOneMinutes()
        {
            foreach (var computer in _computers)
                computer.SpendOnMinutes();
        }
    }

    public class Computer
    {
        private Client _client;
        private int _minutesRenaming;
        
        public int PriceOnMinute { get; private set; }
        public bool IsBusy { get {return _minutesRenaming > 0; }}

        public Computer(int priseOnMinutes) => PriceOnMinute = priseOnMinutes;

        public void BecomeTake(Client client)
        {
            _client = client;
            _minutesRenaming = client.DiseredMinutes;
        }
        
        public void BecomeEmpty() => _client = null;

        public void SpendOnMinutes() => _minutesRenaming--;

        public void ShowState()
        {
            if (IsBusy) Console.WriteLine($"Комьютер занят! Осталось {_minutesRenaming} минут");
            else Console.WriteLine($"Комьтер свободен! Цена за минуту: {PriceOnMinute}");
        }
        
    }

    public class Client
    {
        private int _money;
        private int _moneyToPay;
        public int DiseredMinutes { get; private set; }

        public Client(int money, Random rend)
        {
            _money = money;
            DiseredMinutes = rend.Next(15, 60);
        }

        public bool CheckSolvency(Computer computer)
        {
            _moneyToPay = DiseredMinutes * computer.PriceOnMinute;
            if (_money >= _moneyToPay)
                return true;
            else
            {
                _moneyToPay = 0;
                return false;
            }
        }

        public int Pay()
        {
            _money -= _moneyToPay;
            return _moneyToPay;
        }
    }
}