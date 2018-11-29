using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FocusFrame;
/// <summary>
/// 购买村庄的对话框
/// </summary>
namespace InsectVillage
{
    public class DialogBase : MonoBehaviour
    {

        public UILabel tipText;

        public UIButton yesBtn;
        public UIButton noBtn;

        public BuildBase build;
        // Use this for initialiutzation
        void Start()
        {
            if (!tipText)
                tipText = transform.Find("TipLabel").GetComponent<UILabel>();
            if (!yesBtn)
                yesBtn = transform.Find("YesButton").GetComponent<UIButton>();
            if (!noBtn)
                noBtn = transform.Find("NoButton").GetComponent<UIButton>();
        }

        public void Init(BuildBase b)
        {
            Start();
            build = b;
            yesBtn.onClick.Add(new EventDelegate(YesButtonClick));
            noBtn.onClick.Add(new EventDelegate(NoButtonClick));
        }

        public virtual void YesButtonClick()
        {
            //  village.Buy(GameManager.GetInstance.currentRoleBase);
            build.DealToEvent();
        }

        public virtual void NoButtonClick()
        {
            build.NotDealToEvent();
            PoolManager.GetInstance.RecycleObject(this.gameObject);
        }
    }
}
