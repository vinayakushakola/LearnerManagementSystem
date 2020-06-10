//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using Experimental.System.Messaging;
using System;

namespace LMSCommonLayer.DBModels
{
    public class MSMQSender
    {
        /// <summary>
        /// It is used to Send data to the Queue
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="token">token</param>
        public static void SendToMsmq(string email, string token)
        {
            try
            {
                string path = @".\Private$\LMSQueue";
                MessageQueue messageQueue = null;
                if (!MessageQueue.Exists(path))
                {
                    MessageQueue.Create(path);
                }
                messageQueue = new MessageQueue(path);
                messageQueue.Label = "Learner Management System Mail Sending";
                Message message = new Message(token);
                message.Formatter = new BinaryMessageFormatter();
                messageQueue.Send(message, email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
