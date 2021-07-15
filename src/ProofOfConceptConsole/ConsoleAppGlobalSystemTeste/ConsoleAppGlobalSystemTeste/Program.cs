using ConsoleAppGlobalSystemTeste.Repository;
using System;
using System.Threading.Tasks;

namespace ConsoleAppGlobalSystemTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Acessando a Web API, aguarde um momento!");
            var repository = new FighterRepository();
            var fighterTask = repository.GetFightersAsync();
            fighterTask.ContinueWith(task =>
            {
                var fighters = task.Result;
                foreach (var fighter in fighters)
                {
                    Console.WriteLine("Id:"+ fighter.Id);
                    Console.WriteLine("Nome:"+ fighter.Name);
                    Console.WriteLine("Idade:" + fighter.Age);
                    Console.WriteLine("Lutas:" + fighter.Fights);
                    Console.WriteLine("Derrotas:" + fighter.Defeats);
                    Console.WriteLine("Vitórias:" + fighter.Victories);
                    Console.WriteLine("Quantidade de artes marciais:" + fighter.MartialArts.Length);
                    foreach (var fighterMartialArts in fighter.MartialArts)
                    {
                        Console.WriteLine("Arte marcial:" + fighterMartialArts);
                    }
                    Console.WriteLine("-----------------------------------------------------------");

                }
                Environment.Exit(0);
            },
                TaskContinuationOptions.OnlyOnRanToCompletion
            );
            Console.ReadLine();
        }
    }
}
