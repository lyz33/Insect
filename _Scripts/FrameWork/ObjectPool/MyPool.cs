using System.Collections;
using System.Collections.Generic;
using System;
namespace FocusFrame
{
    /***对象池：拿(创建)/存(回收)***/
    public class MyPool<T> where T : class
    {
        public Action<T> reset;//回收对象的委托
                               //private Func<T> create;//创建对象的委托(由于没参数的)
        public delegate T createDelegate(string name);//创建对象的委托
        private createDelegate create;
        public Dictionary<string, List<T>> dic;//使用栈存储

        public MyPool(createDelegate _create, Action<T> _reset)
        {
            this.create = _create;
            this.reset = _reset;
            dic = new Dictionary<string, List<T>>();
        }
        //创建
        public T Create(string name)
        {
            T t = null;
            List<T> list = null;
            if (dic.ContainsKey(name))
            {
                list = GetListForName(name);
                t = list[0];
                list.Remove(t);
            }
            return t;
        }
        //回收
        public void Reset(string name, T t)
        {
            if (!dic.ContainsKey(name))
            {
                dic[name] = new List<T> { t };
            }
            else
            {
                GetListForName(name).Add(t);
            }
        }
        //清空字典数据
        public void ClearStack()
        {
            dic.Clear();
        }
        //根据名字获得List列表
        public List<T> GetListForName(string name)
        {
            List<T> list = null;
            dic.TryGetValue(name, out list);
            return list;
        }
    }
}
