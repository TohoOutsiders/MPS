using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Core.Customers
{
    public class CustomerEnum
    {
        public enum UserRole
        {
            Admin = 1,
            User = 11
        }

        public enum HttpCode
        {
            Success = 200,
            NotFound = 404,
            Forbidden = 403,
            ServerError = 500
        }

        public enum Verification
        {
            True = 1,
            False = 0
        }
    }
}
