using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 开始界面 按钮事件
/// </summary>

namespace InsectVillage {
    public class StartLogOnCtrl : MonoBehaviour {


        // Use this for initialization
        void Start()
        {
            UIButton[] button = this.gameObject.GetComponentsInChildren<UIButton>();
            for (int i = 0; i < button.Length; i++)
            {
                UIEventListener.Get(button[i].gameObject).onClick = ButtonClick;
            }
        }

        /// <summary>
        /// 按钮事件监听
        /// </summary>
        /// <param name="button"></param>
        public void ButtonClick(GameObject button)
        {
            switch (button.name)
            {
                case "QuestButton":      // 冒险模式
                    break;
                case "ManMachieButton":   // 人机模式
                    ManMachieButtonClick();
                    break;
                case "PVPButton":         // 对战模式
                    break;
                case "AboutUsButton":     // 关于我们
                    break;
            }
        }

        /// <summary>
        /// 人机模式点击
        /// </summary>
        public void ManMachieButtonClick()
        {
            GameObject startUI = ResourcesMgr.GetInstance.LoadObj(ResourcesType.UIWindows, "LobbyUI", false);
            startUI.transform.SetParent(this.transform.parent, false);
        }
    }
}
