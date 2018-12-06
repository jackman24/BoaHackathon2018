using System.Threading.Tasks;

namespace CognitiveServicesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            FaceAnalysisDemo demo = new FaceAnalysisDemo();
            await demo.Run();
        }
    }
}
