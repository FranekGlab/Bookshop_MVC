using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Bulky.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly string _apiKey = "9398bc0ba878b63999d4d83dce32ceb5";
        private readonly string _apiSecret = "67b24cb150b41ed478bc30cdc489ac03";

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailjetClient client = new MailjetClient(_apiKey, _apiSecret);

            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.Messages, new JArray {
                new JObject {
                    {
                        "From", new JObject {
                            {"Email", "franciszekglab695@gmail.com"},
                            {"Name", "Bulky Web"}
                        }
                    },
                    {
                        "To", new JArray {
                            new JObject {
                                {"Email", email}
                            }
                        }
                    },
                    {"Subject", subject},
                    {
                        "HTMLPart", htmlMessage
                    }
                }
            });

            await client.PostAsync(request);
        }
    }
}