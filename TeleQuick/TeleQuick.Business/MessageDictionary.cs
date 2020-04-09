using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeleQuick.Business
{
    public enum MyEnum
    {
        Starting,
        Started,
        Logging,
        Logged,
        Scrapping,
        Scrapped,
        Procesing,
        Procesed,
        Finishing,
        Finished
    }

    public class MessageDictionary
    {
        List<Tuple<MyEnum, Message>> list = new List<Tuple<MyEnum, Message>>();
        int totalAccount = 0;

        public MessageDictionary(string Concessionary, int totalAccount)
        {
            this.totalAccount = totalAccount;
            list.Add(Tuple.Create(MyEnum.Starting, new Message(Concessionary, "Comenzando procesamiento")));
            list.Add(Tuple.Create(MyEnum.Started, new Message(Concessionary, "Comienzo del procesamiento")));
            list.Add(Tuple.Create(MyEnum.Logging, new Message(Concessionary, "Validando login de sesion")));
            list.Add(Tuple.Create(MyEnum.Logged, new Message(Concessionary, "Login de sesion exitoso")));
            list.Add(Tuple.Create(MyEnum.Scrapping, new Message(Concessionary, "Comienzo de Scrapy")));
            list.Add(Tuple.Create(MyEnum.Scrapped, new Message(Concessionary, "Scrapy exitoso")));
            list.Add(Tuple.Create(MyEnum.Procesing, new Message(Concessionary, "Comienzo Cabecera y Detalle de exitoso")));
            list.Add(Tuple.Create(MyEnum.Procesed, new Message(Concessionary, "Cabecera y Detalle de exitoso")));
            list.Add(Tuple.Create(MyEnum.Finishing, new Message(Concessionary, "Finalizando procesamiento")));
            list.Add(Tuple.Create(MyEnum.Finished, new Message(Concessionary, "Finalizado")));
        }

        public Message GetMessage(MyEnum key)
        {
            var a = list.First(m => m.Item1 == key);
            a.Item2.Percentil = (decimal)1 / (list.Count * totalAccount) * 100;

            return a.Item2;
        }

        public int Count()
        {
            return list.Count();
        }

    }
}
