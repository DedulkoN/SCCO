using System;


namespace AcsessSCCO
{
   static class Logger
    {
        public static void inLog(string message, int userId)
        {
            MsQuery.Query.RunEdit(string.Format(" INSERT INTO [UserLog](UserID, [UserLog],[DateLog]) VALUES ({0}  ,'{1}', '{2}')",
                userId,
                message,
                DateTime.Now));
        }

    }
}
