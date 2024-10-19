namespace NetCore.Base.Model.Response
{
    public class Message
    {
        public DateTime DataHora { get; private set; }
        public string Texto { get; private set; }

        public Message() { }

        public Message(string texto)
        {
            Texto = texto;
            DataHora = DateTime.Now;
        }
    }
}
