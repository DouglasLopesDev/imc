using Newtonsoft.Json;
class Program
{
    public static List<string> results = new List<string>();

    static void Main()
    {
        try
        {
            var action = string.Empty;
            var weight = 0.0;
            var height = 0.0;
            var name = string.Empty;
            do
            {
                Console.WriteLine("---Próximo Cálculo---");

                Console.Write("Digite o nome: ");
                name = Console.ReadLine().ToString();

                Console.Write("Digite o peso em kg: ");
                weight = double.Parse(Console.ReadLine().ToString());

                Console.Write("Digite a altura em cm: ");
                height = double.Parse(Console.ReadLine().ToString());

                height /= 100;
                var dict = CalculateIMC(height, weight);

                var messageResult = $"Nome: {name} ; Peso: {weight}kg ; Altura: {height}m ; IMC= {Math.Round(dict["imc"], 2)} ; Classificação= {dict["classification"]} ";
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine(messageResult);
                Console.WriteLine("---------------------------------------------------------------------");

                results.Add(messageResult);

                Console.WriteLine(GetMsg());
                action = Console.ReadLine();

                ExecuteNextAction(action);

            } while (action != "exit");
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    private static Dictionary<string, dynamic> CalculateIMC(double height, double weight)
    {
        var imc = weight / (Math.Pow(height, 2));
        var dict = new Dictionary<string, dynamic>();
        dict.Add("imc", imc);
        dict.Add("classification", GetImcClassification(imc));

        return dict;
    }

    private static string GetImcClassification(double imc)
    {
        if (imc < 18.5)
        {
            return "Magreza";
        }
        else if (imc <= 24.9)
        {
            return "Saudável";
        }
        else if (imc <= 29.9)
        {
            return "Sobrepeso";
        }
        else if (imc <= 34.9)
        {
            return "Obesidade Grau I";
        }
        else if (imc <= 39.9)
        {
            return "Obesidade Grau II (Severa)";
        }
        else
        {
            return "Obesidade Grau III (Mórbida)";
        }
    }

    private static void ExecuteNextAction(string action)
    {
        switch (action)
        {
            case "limpar":
                results = new List<string>();
                break;
            case "ver":
                foreach (var item in results)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("---------------------------------------------------------------------");
                }
                break;
            default: break;
        }
    }

    private static string GetMsg()
    {
        var msg = "Pressione Enter para calcular novamente \n" +
                    "Digite 'exit' para finalizar o console \n" +
                    "Digite 'limpar' para limpar os resultados anteriores e calcular novamente \n";

        if (results.Count != 0)
        {
            msg += "Digite 'ver' para visualizar resultados anteriores e calcular novamente \n";
        }
        return msg;
    }
}