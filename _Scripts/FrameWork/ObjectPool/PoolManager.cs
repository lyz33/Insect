using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FocusFrame
{
    public class PoolManager : Singleton<PoolManager>
    {
        public MyPool<GameObject> pool;

        void Awake()
        {
            pool = new MyPool<GameObject>(GetObject, RecycleObject);
        }

        /// <summary>
        /// 拿东西
        /// </summary>
        /// <param name="name">物体的名称</param>
        ///  /// <param name="isLocal">是否从本地拿取</param>
        /// <returns></returns>
        public GameObject GetObject(string name)
        {
            GameObject go = null;
            if (!pool.dic.ContainsKey(name) || pool.dic[name].Count == 0)
            {
                //实例化
              //  go = Instantiate(ResourcesManager.GetInstance.GetPrefabForDic(name), Vector3.zero, Quaternion.identity) as GameObject;
                go.name = name;
            }
            else
            {
                go = pool.Create(name);
                go.SetActive(true);
            }
            return go;
        }
        /// <summary>
        /// 从本地读取
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GameObject GetObjectLocal(string name)
        {
            GameObject go = null;
            if (!pool.dic.ContainsKey(name) || pool.dic[name].Count == 0)
            {
                //实例化
               // print(name);
                go = Instantiate(Resources.Load(name), Vector3.zero, Quaternion.identity) as GameObject;
                go.name = name;
            }
            else
            {
                go = pool.Create(name);
                go.SetActive(true);
            }
            return go;
        }

        /// <summary>
        /// 拿东西，并在设置父物体，和位置
        /// </summary>
        /// <param name="name">物体名称</param>
        /// <param name="spwanPos">位置</param>
        /// <param name="parent">父物体</param>
        /// <returns></returns>
        public GameObject GetObject(string name, Vector3 spwanPos, Quaternion rotation, Transform parent)
        {
            GameObject go = GetObject(name);
            go.transform.position = spwanPos;
            go.transform.rotation = rotation;
            go.transform.SetParent(parent);
            return go;
        }

        /// <summary>
        /// 回收物体
        /// </summary>
        /// <param name="go">需回收物体对象</param>
        public void RecycleObject(GameObject go)
        {
            string name = go.name;
            go.SetActive(false);
            pool.Reset(name, go);
        }

        /// <summary>
        /// 只取一次的物体
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Object GetOnceObjectLocal(string name)
        {
            Object obj = null;
            obj = Resources.Load(name);
            return obj;
        }

        /// <summary>
        /// 延时回收物体
        /// </summary>
        /// <param name="go">需回收物体对象</param>
        /// <param name="timer">延时时间</param>
        public void RecycleObject(GameObject go, float timer)
        {
            StartCoroutine(WaitForTime(go, timer));
        }

        IEnumerator WaitForTime(GameObject go, float timer)
        {
            yield return new WaitForSeconds(timer);
            RecycleObject(go);
        }
    }
}

