//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

namespace LMSMsmq
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @".\Private$\LMSQueue";
            MsmqListener msmqListener = new MsmqListener(path);
            msmqListener.Start();
        }
    }
}
