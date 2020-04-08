using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using TeleQuick.Business;

namespace TeleQuick.IService
{
    public interface ICollectionMessage
    {
        event NotifyCollectionChangedEventHandler CollectionChanged;
        void Add(Message message);
    }
}
