using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Infrastructure.OkReponse
{
    public class TextResponse : IHttpActionResult
    {
        public string Text { get; set; }

        public TextResponse(string text)
        {
            this.Text = text;
        }

        public Task<HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {

            var response = new HttpResponseMessage(HttpStatusCode.OK);



            response.Content = new StringContent(this.Text);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/xml");
            return Task.FromResult(response);
        }
       
    }

    public class OkResponse<T> : IHttpActionResult
    {
        public CommonResponse CommonResponse { get; set; }

        public OkResponse(string message)
        {
            this.CommonResponse = new CommonResponse(0, message);
        }

        public OkResponse(int code, string message)
        {
            this.CommonResponse = new CommonResponse(code, message);
        }

        public OkResponse(int code, dynamic data)
        {
            this.CommonResponse = new CommonResponse(0, data);
        }
        public Task<HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {

            var response = new HttpResponseMessage(HttpStatusCode.OK);



            //response.Content = new StringContent(Json.JsonParser.Serialize(this.CommonResponse));
            string resout = JsonConvert.SerializeObject(this.CommonResponse, Formatting.Indented, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
            response.Content = new StringContent(resout);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return Task.FromResult(response);
        }
    }

    public class OkReponse : IHttpActionResult
    {

        public CommonResponse CommonResponse { get; set; }

        public OkReponse()
        {
            this.CommonResponse = new CommonResponse();
        }

        public OkReponse(string message)
        {
            this.CommonResponse = new CommonResponse(0, message);
        }


        public OkReponse(int code, string message)
        {
            this.CommonResponse = new CommonResponse(code, message);
        }

        public OkReponse(int code, dynamic data)
        {
            this.CommonResponse = new CommonResponse(code, data);
        }


        public OkReponse(dynamic data)
        {
            this.CommonResponse = new CommonResponse(0, data);


        }

        public Task<HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {

            var response = new HttpResponseMessage(HttpStatusCode.OK);



            //response.Content = new StringContent(Json.JsonParser.Serialize(this.CommonResponse));
            string resout = JsonConvert.SerializeObject(this.CommonResponse, Formatting.Indented, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
            response.Content = new StringContent(resout);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return Task.FromResult(response);
        }

    }




    public class CommonResponse<T>
    {
        public bool Flag { get; set; }

        public T Value { get; set; }

        public int Code { get; set; }

        public string Msg { get; set; }

        //public CommonResponse(bool flag, dynamic data)
        //{
        //    this.Flag = flag;
        //    this.Data = data;
        //}

        public CommonResponse(bool flag, int code, string msg)
        {
            this.Flag = flag;
            this.Msg = msg;
            this.Code = code;
        }


    }

    public class CommonResponse
    {

        public dynamic Value { get; set; }

        public int Code { get; set; }

        public string Msg { get; set; }

        public CommonResponse() { }

        public CommonResponse(int code, dynamic data)
        {
            this.Code = code;
            this.Value = data;
        }

        public CommonResponse(int code, string msg)
        {

            this.Code = code;
            this.Msg = msg;
        }
    }

    public class ApiJsonSetting
    {
        //public static JsonMediaTypeFormatter CurrentJsonMediaTypeFormatter
        //{
        //    get
        //    {
        //        var jsonSetting = new JsonSerializerSettings 
        //        {
        //            DateFormatString = "yyyy-MM-dd'T'HH:mm:s",
        //            NullValueHandling = NullValueHandling.Ignore,

        //        };

        //        return new JsonMediaTypeFormatter()
        //        {

        //            SerializerSettings = jsonSetting
        //        };

        //    }

        //}
    }
}
