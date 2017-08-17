using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;
using System.Timers;
using System.Net;
using System.IO;

// Needed to add the System.Net, System.Timers, and TweetSharp for this project.
namespace FirstTwitterAPITest
{
    class Program
    {
        // This is where the API and all other keys are
        private static string customer_key = "gltLPKE3ejALS6qNluvLrjMAA";
        private static string customer_key_secret = "aeaROPF7K1sRGbklJOx8c8uxfftb3vfGlxO8KNqqQ7GBiEx7hK";
        private static string access_token = "134319035-8M1bhLCv2HY4qAjKbXeGki4PsPDpqNQgMJuiqnLU";
        private static string access_token_secret = "GqCDv2A04Z7bOrsAjRHyjt7G8bq1JjN25MXxDKIQQYZ2V";

        private static TwitterService service = new TwitterService(customer_key, customer_key_secret, access_token, access_token_secret);

        // Created a list and assigned the first spot to the image
        private static int currentImageID = 0;
        private static List<string> imageList = new List<string> { $"C:/Users/Abel/Desktop/ConsoleAppTwitterAPI/Images/westworld.jpg" };



        // This is what is shown in the main console when the program is run. Also holds the fun intro text.
        static void Main(string[] args)
        {
            Console.WriteLine($"<{DateTime.Now}> - Twittertron 3000 Activating");
            Console.WriteLine($"<{DateTime.Now}> - Loading Awesome Protocol");
            Console.WriteLine($"<{DateTime.Now}> - Twitter Bot Started");
            SendMediaTweet("Hello World! Twittertron 3000 is activated.", currentImageID);
            Console.Read();
        }


        // This is what sends the tweet. If it works, show in green, if it doesn't red 
        private static void SendTweet(string _status)
        {
            service.SendTweet(new SendTweetOptions { Status = _status }, (tweet, response) =>
             {
                 if(response.StatusCode == HttpStatusCode.OK)
                 {
                     Console.ForegroundColor = ConsoleColor.Green;
                     Console.WriteLine($"<{DateTime.Now}> - The Package has left the building!");
                     Console.ResetColor();
                 }
                 else
                 {
                     Console.ForegroundColor = ConsoleColor.Red;
                     Console.WriteLine($"<ERROR> " + response.Error.Message);
                     Console.ResetColor();
                 }
             });
        }

        // Creates a dictionary item out of our image and sends out the image in the 0 slot
        private static void SendMediaTweet(string _status, int imageID)
        {
            using (var stream = new FileStream(imageList[imageID], FileMode.Open))
            {
                service.SendTweetWithMedia(new SendTweetWithMediaOptions
                {
                    Status = _status,
                    Images = new Dictionary<string, Stream> { { imageList[imageID], stream } }
                });

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"<{DateTime.Now}> - The Package has left the building!");
                Console.ResetColor();

                if((currentImageID + 1) == imageList.Count)
                    {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("<Twittertron 3000> - End of Image Array");
                    Console.ResetColor();
                    currentImageID = 0;
                }
                else
                {
                    currentImageID++;
                }
            }
        }
    }
}
