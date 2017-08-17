using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;
using System.Timers;
using System.Net;

// Needed to add the System.Net, System.Timers, and TweetSharp for this project.
namespace FirstTwitterAPITest
{
    class Program
    {
        // This is where the API and all other keys are
        private static string customer_key = "t7bnPyIiQ1XMyfP6ANdd72Epj";
        private static string customer_key_secret = "tfMApWlO5WKL1bEcGGQYjeq8wWp6WZRQtHzV2IgRd85Fu4qV85";
        private static string access_token = "134319035-vQxaXfDqzwVIABibani8lxMOePxO3ov7MOxlV72M";
        private static string access_token_secret = "qfVdkw2fxMHxNMjvh31xNlNnJFS9lND4enoqly78bimzC";

        private static TwitterService service = new TwitterService(customer_key, customer_key_secret, access_token, access_token_secret);

        // This is what is shown in the main console when the program is run 
        static void Main(string[] args)
        {
            Console.WriteLine($"<{DateTime.Now}> - Loading Awesome Protocol");
            Console.WriteLine($"<{DateTime.Now}> - Twitter Bot Started");
            SendTweet("Hello World!");
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

        // This will be the update that I add, sending Media Images
        private static void SendMediaTweet(string _status, int imageID)
        {

        }



    }
}
