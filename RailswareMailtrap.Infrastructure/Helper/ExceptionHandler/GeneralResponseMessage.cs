using Newtonsoft.Json;

namespace RailswareMailtrap.Infrastructure.Helper.ExceptionHandler
{
    public class GeneralResponseMessage<T>
    {

        [JsonProperty("resultCode")]
        public int ResultCode { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
        [JsonProperty("messages")]
        public List<ErrorDetail> Messages { get; set; }


        public GeneralResponseMessage()
        {


        }

        public GeneralResponseMessage(T data)
        {
            Data = data;
        }

        public GeneralResponseMessage(ErrorDetail errors)
        {
            Messages = new List<ErrorDetail>();
            Messages.Add(errors);
        }
    }
}

