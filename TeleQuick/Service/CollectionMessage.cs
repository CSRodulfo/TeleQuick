using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using TeleQuick.Business;
using TeleQuick.IService;

namespace TeleQuick.Service
{
    public class CollectionMessage : ObservableCollection<Message> , ICollectionMessage
    {
        //public void Add(string prop1, string prop2)
        //{
        //    base.Add(new Message { Prop1 = prop1, Prop2 = prop2 });
        //}

        public CollectionMessage()
            :base()
        {
            this.CollectionChanged += this.OnCollectionChanged;
        }

        public void AddMessage(Message message)
        {
            base.Add(message);
        }


        public void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

        }


    }
}