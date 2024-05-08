namespace RailswareMailtrap.Application.Models.Response
{
    public class SendMailResponse
    {
        public bool Success { get; set; }
        public string[] Message_ids { get; set; }
    }

}
