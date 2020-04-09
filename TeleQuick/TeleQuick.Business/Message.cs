namespace TeleQuick.Business
{
    public class Message
    {
        private string _concesionary;
        private string _description;
        private int _percentil;

        public Message(string concesionary, string description)
        {
            _concesionary = concesionary;
            _description = description;
        }


        public string Concesionary
        {
            get { return _concesionary; }
        }

        public string Description
        {
            get { return _description; }
        }

        public int Percentil
        {
            get { return _percentil; }
        }

    }
}
