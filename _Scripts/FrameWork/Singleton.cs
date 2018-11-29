using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FocusFrame
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        protected static T instance;
        protected static bool isExit = false;
        public static T GetInstance
        {
            get
            {
                if (instance == null&&!isExit)
                {
                    instance = FindObjectOfType<T>();
                    if (FindObjectsOfType<T>().Length > 1)
                        return instance;
                    if (instance == null)
                    {
                        string name = typeof(T).Name;
                        GameObject go = GameObject.Find(name);
                        if (go == null)
                        {
                            go = new GameObject(name);
                        }
                        instance = go.AddComponent<T>();
                    }
                }
                return instance;
            }
        }
        public virtual void OnDestroy()
        {
            instance = null;
            isExit = true;
        }
    }
}
