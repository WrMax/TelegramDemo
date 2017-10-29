using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BotFrameworkSample.Controllers
{
    [Route("api/[controller]")]
    [BotAuthentication]
    public class MessagesController : Controller
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            //var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            //var reply = activity.CreateReply(activity.Text);
            //await connector.Conversations.ReplyToActivityAsync(reply);
            if (activity?.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }        
    }
}