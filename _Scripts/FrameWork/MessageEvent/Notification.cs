using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FocusFrame
{
    /***信息***/
    public class Notification
    {

        //消息分发者
        public GameObject sender;

        public object param;

        //只需有信息内容即可
        public Notification(object param)
        {
            this.param = param;
        }
        //知道发送者是谁和信息内容
        public Notification(GameObject sender, object param)
        {
            this.sender = sender;
            this.param = param;
        }
    }
}
