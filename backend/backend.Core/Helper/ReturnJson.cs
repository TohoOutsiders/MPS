using System;
using System.Collections.Generic;
using System.Text;
using backend.Core.Customers;
using Newtonsoft.Json;

namespace backend.Core.Helper
{
    public static class ReturnJson
    {
        public class Return
        {
            [JsonProperty("code")]
            public CustomerEnum.HttpCode Code { get; set; }
            [JsonProperty("data")]
            public object Data { get; set; }
        }

        public static Return Success(object data = null)
        {
            var model = new Return
            {
                Code = CustomerEnum.HttpCode.Success,
                Data = data
            };

            return model;
        }


        public static Return NotFound(object data = null)
        {
            var model = new Return
            {
                Code = CustomerEnum.HttpCode.NotFound,
                Data = data
            };

            return model;
        }

        public static Return ServerError(object data = null)
        {
            var model = new Return
            {
                Code = CustomerEnum.HttpCode.ServerError,
                Data = data
            };

            return model;
        }

        public static Return Forbidden(object data = null)
        {
            var model = new Return
            {
                Code = CustomerEnum.HttpCode.Forbidden,
                Data = data
            };

            return model;
        }
    }
}
