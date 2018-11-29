using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InsectVillage
{
    public class StartSceneCtrl : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            LoadStartSceneUI();
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// 加载开始场景交互UI
        /// </summary>
        void LoadStartSceneUI()
        {
            GameObject uiRoot = ResourcesMgr.GetInstance.LoadObj(ResourcesType.UIWindows, "UI Root", false);
            GameObject startUI = ResourcesMgr.GetInstance.LoadObj(ResourcesType.UIWindows, "StartMenuUI", false);
            startUI.transform.SetParent(uiRoot.transform,false);
        }
    }
}
