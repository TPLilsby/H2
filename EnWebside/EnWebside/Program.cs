
namespace EnWebside
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IRequest Httprequest = new HTTP();

            Console.WriteLine("Indtast URL: ");
            string path = Console.ReadLine();

            await Httprequest.MakeRequest(path);
        }


    }
}