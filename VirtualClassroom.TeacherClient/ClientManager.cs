using System;
using VirtualClassroom.TeacherClient.TeacherServiceReference;

namespace VirtualClassroom.TeacherClient
{
    /// <summary>
    /// Manages connections to the service
    /// </summary>
    class ClientManager
    {
        private static TeacherServiceClient clientInstance;

        /// <summary>
        /// Creates a new connection to the service or uses an existing one
        /// </summary>
        /// <returns>A working connection to the service</returns>
        public static TeacherServiceClient GetClient()
        {
            if(clientInstance == null)
            {
                clientInstance = new TeacherServiceClient();
            }

            return clientInstance;
        }

        /// <summary>
        /// Closes the existing connection to the service
        /// </summary>
        public static void CloseClient()
        {
            if (clientInstance != null)
            {
                clientInstance.Close();
            }
        }
    }
}
