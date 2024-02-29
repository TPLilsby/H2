
namespace EnWebside
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IRequest Httprequest = new HTTP();

            Console.WriteLine("Indtast URL: ");
            string urlPath = Console.ReadLine();

            await Httprequest.MakeRequest(urlPath);

            IRequest Filerequest = new File();

            Console.WriteLine("Indtast filnavn: ");
            string filePath = Console.ReadLine();

            await Filerequest.MakeRequest(filePath);



        }


    }
}