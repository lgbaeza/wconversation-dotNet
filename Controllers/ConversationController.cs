using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatsonSamples.Models;

namespace WatsonSamples.Controllers
{
    public class ConversationController : Controller
    {
        // GET: Conversation
        public ActionResult Index()
        {

            //Initial call to the service for getting a conversationID and a conversation context
            WCInitialMessage msg = new WCInitialMessage("");
            WCMessageResponse watsonResponse = new WCMessageResponse();
            watsonResponse = WatsonConversationClient.ConverseWatsonInitial(msg);

            //Subsequent Watson Conversation calls
            string userInput = "Quiero reservar un vuelo"; //Read user input from UI
            //Assign userinput to the message object, and then pass it to watson client
            watsonResponse.input.text = userInput;
            watsonResponse = WatsonConversationClient.ConverseWatson(watsonResponse);

            //Starting from the watson Response, do the necessary application logic from here to show the conversation on the UI

            ViewBag.wc_Response = watsonResponse.output.text[0];

            return View();
        }
    }
}