using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Infraestructure.Persistence.Helper
{
    public static class DbExceptionHelper
    {
        public static bool IsUniqueConstraint(Exception ex, string indexName)
        {
            return ex.InnerException?.Message.Contains(indexName) == true;
        }
    }
}
