using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FocusFrame
{
    /***事件中心***/
    public delegate void OnNotification(Notification notific);
    public class MessageCenter 
    {
        private static MessageCenter instance;

        public static MessageCenter GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new MessageCenter();
                return instance;
            }
        }

        public Dictionary<string, OnNotification> eventListener = new Dictionary<string, OnNotification>();

        //注册事件
        public void AddEventListener(string eventName, OnNotification notific)
        {
            if (!eventListener.ContainsKey(eventName))
            {
                eventListener.Add(eventName, notific);
            }
        }
        //移除事件
        public void RemoveEventListener(string eventName)
        {
            if (eventListener.ContainsKey(eventName))
            {
                eventListener.Remove(eventName);
            }
        }
        //分发事件
        public void DispatchEvent(string eventName, Notification notific)
        {
            if (eventListener.ContainsKey(eventName))
            {
                eventListener[eventName](notific);
            }
        }
        //分发事件
        public void DispatchEvent(string eventName, GameObject sender, object param)
        {
            if (eventListener.ContainsKey(eventName))
            {
                eventListener[eventName](new Notification(sender, param));
            }
        }
        //分发事件
        public void DispatchEvent(string eventName, object param)
        {
            if (eventListener.ContainsKey(eventName))
            {
                eventListener[eventName](new Notification(param));
            }
        }

        public bool HasEventListener(string eventName)
        {
            return eventListener.ContainsKey(eventName);
        }
    }
}
