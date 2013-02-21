using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualClassroom.TeacherClient.TeacherServiceReference;

namespace VirtualClassroom.TeacherClient
{
    class ClientManager
    {
        private static TeacherServiceClient clientInstance;

        public static TeacherServiceClient GetClient()
        {
            if(clientInstance == null)
            {
                clientInstance = new TeacherServiceClient();
            }

            return clientInstance;
        }

        public static void CloseClient()
        {
            if (clientInstance != null)
            {
                clientInstance.Close();
            }
        }
    }
}
