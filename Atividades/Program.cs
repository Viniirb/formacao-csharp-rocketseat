namespace FormacaoRocketseat.DesafioPraticoUm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var activityService = new ActivityService();

            activityService.ExecuteFirstActivity();
            Console.WriteLine("\n---\n");
            activityService.ExecuteSecondActivity();
            Console.WriteLine("\n---\n");
            activityService.ExecuteThirdActivity();
            Console.WriteLine("\n---\n");
            activityService.ExecuteFourthActivity();
            Console.WriteLine("\n---\n");
            activityService.ExecuteFifthActivity();
            Console.WriteLine("\n---\n");
            activityService.ExecuteSixthActivity();
            Console.WriteLine("\n---\n");
            Console.WriteLine("Todas as atividades foram executadas com sucesso!");
        }
    }

    public class ActivityService
    {
        public void ExecuteFirstActivity()
        {
            Console.Write("Digite seu nome: ");
            var nome = Console.ReadLine();
            Console.WriteLine($"Olá, {nome}! Seja muito bem-vindo!");
        }

        public void ExecuteSecondActivity()
        {
            Console.Write("Digite seu nome: ");
            var nome = Console.ReadLine();
            Console.Write("Digite seu sobrenome: ");
            var sobrenome = Console.ReadLine();
            Console.WriteLine($"Nome Completo: {nome} {sobrenome}");
        }

        public void ExecuteThirdActivity()
        {
            var numero1 = ReadDouble("Digite um número: ");
            var numero2 = ReadDouble("Digite outro número: ");

            var soma = CalculateOrZero(numero1, numero2, (a, b) => a + b);
            var subtracao = CalculateOrZero(numero1, numero2, (a, b) => a - b);
            var multiplicacao = CalculateOrZero(numero1, numero2, (a, b) => a * b);
            var divisao = ValidateDivision(numero1, numero2);
            var media = CalculateOrZero(numero1, numero2, (a, b) => (a + b) / 2);

            Console.WriteLine($"A soma dos números é: {soma}");
            Console.WriteLine($"A subtração dos números é: {subtracao}");
            Console.WriteLine($"A multiplicação dos números é: {multiplicacao}");
            Console.WriteLine($"A divisão dos números é: {divisao}");
            Console.WriteLine($"A média dos números é: {media}");
        }

        public void ExecuteFourthActivity()
        {
            Console.Write("Digite uma ou mais palavras: ");
            var palavras = Console.ReadLine();
            var qtdCaracteres = GetStringLength(palavras);
            Console.WriteLine($"A quantidade de caracteres digitados é: {qtdCaracteres}");
        }

        public void ExecuteFifthActivity()
        {
            Console.Write("Digite uma placa de um veiculo no formato XXX-XXXX: ");
            var placa = Console.ReadLine();
            var resultado = ValidatePlaca(placa);
            Console.WriteLine(resultado);
        }

        public void ExecuteSixthActivity()
        {
            var culturaBrasileira = System.Globalization.CultureInfo.GetCultureInfo("pt-BR");

            Console.WriteLine("=== FORMATAÇÃO DE DATAS ===\n");

            Console.Write("Formato Completo (ex: segunda-feira, 01 de janeiro de 2020 14:30:00): ");
            var dataCompleta = Console.ReadLine();

            Console.Write("\nFormato Curto (ex: 01/01/2020): ");
            var dataCurta = Console.ReadLine();

            Console.Write("\nHora no formato de 24 horas (ex: 14:30:00): ");
            var hora = Console.ReadLine();

            Console.Write("\nData com mês por extenso (ex: 01 de janeiro de 2020): ");
            var dataMesExtenso = Console.ReadLine();

            Console.WriteLine("\n=== RESULTADOS DA VALIDAÇÃO ===\n");

            ValidateAndDisplayDate(dataCompleta, null, "Data Completa", culturaBrasileira, 
                "dddd, dd 'de' MMMM 'de' yyyy HH:mm:ss");

            ValidateAndDisplayDate(dataCurta, "dd/MM/yyyy", "Data Curta", culturaBrasileira, 
                "dd/MM/yyyy");

            ValidateAndDisplayDate(hora, "HH:mm:ss", "Hora", culturaBrasileira, 
                "HH:mm:ss");

            ValidateAndDisplayDate(dataMesExtenso, "dd 'de' MMMM 'de' yyyy", "Data com Mês por Extenso", culturaBrasileira, 
                "dd 'de' MMMM 'de' yyyy");
        }

        #region Métodos de Validação

        private double ReadDouble(string prompt)
        {
            Console.Write(prompt);
            return Convert.ToDouble(Console.ReadLine());
        }

        private double CalculateOrZero(double numero1, double numero2, Func<double, double, double> operation)
        {
            return numero1 == 0 || numero2 == 0 ? 0 : operation(numero1, numero2);
        }

        private string ValidateDivision(double numero1, double numero2)
        {
            return numero2 == 0 ? "Divisão por zero não é permitida" : (numero1 / numero2).ToString();
        }

        private int GetStringLength(string? text)
        {
            return text?.Length ?? 0;
        }

        private string ValidatePlaca(string? placa)
        {
            if (string.IsNullOrWhiteSpace(placa) || placa.Replace("-", "").Length != 7)
            {
                return "Placa inválida. Certifique-se de seguir o formato XXX-XXXX.";
            }

            var partes = placa.Split('-');
            if (partes.Length != 2 || partes[0].Length != 3 || partes[1].Length != 4)
            {
                return "Placa inválida. Certifique-se de seguir o formato XXX-XXXX.";
            }

            if (!partes[0].All(char.IsLetter) || !partes[1].All(char.IsDigit))
            {
                return "Placa inválida. As três primeiras posições devem ser letras e as quatro últimas devem ser números.";
            }

            return "Placa válida!";
        }

        private void ValidateAndDisplayDate(string? input, string? parseFormat, string description, 
            System.Globalization.CultureInfo culture, string displayFormat)
        {
            bool isValid;
            DateTime parsedDate;

            if (parseFormat == null)
            {
                isValid = DateTime.TryParse(input, culture, System.Globalization.DateTimeStyles.None, out parsedDate);
            }
            else
            {
                isValid = DateTime.TryParseExact(input, parseFormat, culture, System.Globalization.DateTimeStyles.None, out parsedDate);
            }

            if (isValid)
            {
                Console.WriteLine($"✓ {description}: {parsedDate.ToString(displayFormat, culture)}");
            }
            else
            {
                Console.WriteLine($"✗ {description} inválida. Certifique-se de seguir o formato especificado.");
            }
        }

        #endregion
    }
}
