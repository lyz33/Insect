using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using FocusFrame;

namespace InsectVillage
{
    /// <summary>
    /// 资源类型
    /// </summary>
    public enum ResourcesType
    {
        /// <summary>
        /// ui场景
        /// </summary>
        UIScene,
        /// <summary>
        /// ui窗口
        /// </summary>
        UIWindows,
        /// <summary>
        /// 角色
        /// </summary>
        Role,
        /// <summary>
        /// 特效
        /// </summary>
        Effect
    }
    public class ResourcesMgr : Singleton<ResourcesMgr>
    {
        public Hashtable hs;

        public ResourcesMgr()
        {
            hs = new Hashtable();
        }
        /// <summary>
        /// 加载资源从Resources
        /// </summary>
        /// <param name="rt">类型</param>
        /// <param name="path">路径</param>
        /// <param name="isCache">是否缓存</param>
        /// <returns></returns>
        public GameObject LoadObj(ResourcesType rt, string path, bool isCache)
        {
            StringBuilder sbr = new StringBuilder();
            switch (rt)
            {
                case ResourcesType.UIScene:
                    sbr.Append("UIPrefab/UIScene/");
                    break;
                case ResourcesType.UIWindows:
                    sbr.Append("UIPrefab/UIWindows/");
                    break;
                case ResourcesType.Role:
                    sbr.Append("RolePrefab/");
                    break;
                case ResourcesType.Effect:
                    sbr.Append("EffectPrefab/");
                    break;
            }
            sbr.Append(path);

            GameObject go = null;// 

            if (hs.ContainsKey(path))
            {
                go = hs[path] as GameObject;
            }
            else
            {
                go = GameObject.Instantiate(Resources.Load(sbr.ToString(), typeof(GameObject))) as GameObject;
                if (isCache)
                {
                    hs.Add(path, go);
                }
            }
            return go;
        }
    }
}