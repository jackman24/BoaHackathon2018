using System;
using System.Threading.Tasks;

namespace CognitiveServicesConsole
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            FaceAnalysisDemo demo = new FaceAnalysisDemo();
            await demo.Run();
            Console.ReadKey();
        }
    }
}