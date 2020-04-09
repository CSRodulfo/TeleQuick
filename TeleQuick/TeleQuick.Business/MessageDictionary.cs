using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeleQuick.Business
{
    public enum MyEnum
    {
        Logging,
        Logged,
        Scrapping,
        Scrapped,
        Procesing,
        Procesed
    }

    public class MessageDictionary
    {
        Dictionary<MyEnum, Message> dictionary = new Dictionary<MyEnum, Message>();
        int totalAccount = 0;

        public MessageDictionary(string Concessionary, int totalAccount)
        {
            this.totalAccount = totalAccount;
            dictionary.Add(MyEnum.Logging, new Message(Concessionary, "Validando login de sesion"));
            dictionary.Add(MyEnum.Logged, new Message(Concessionary, "Login de sesion exitoso"));
            dictionary.Add(MyEnum.Scrapping, new Message(Concessionary, "Comienzo de Scrapy"));
            dictionary.Add(MyEnum.Scrapped, new Message(Concessionary, "Scrapy exitoso"));
            dictionary.Add(MyEnum.Procesing, new Message(Concessionary, "Comienzo Cabecera y Detalle de exitoso"));
            dictionary.Add(MyEnum.Procesed, new Message(Concessionary, "Cabecera y Detalle de exitoso"));
        }

        public Message GetMessage(MyEnum key)
        {
            Message rtn;

            dictionary.

            dictionary.TryGetValue(key, out rtn);

            return rtn;
        }

        public int Count()
        {
            return dictionary.Count();
        }

    }
}
