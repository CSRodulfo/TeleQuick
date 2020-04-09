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
    public class CollectionMessage : ObservableCollection<Message>, ICollectionMessage
    {
        public CollectionMessage()
            : base()
        {
            this.CollectionChanged += this.OnCollectionChanged;
        }

        public void AddMessage(Message message)
        {
            base.Add(message);
        }

        public void AddMessage(string concesionary, string description)
        {
            base.Add(new Message(concesionary, description));
        }

        public void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

        }
    }
}