using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 建筑基类
/// </summary>
namespace InsectVillage
{
    /// <summary>
    /// 建筑类型
    /// </summary>
    public enum BuildType
    {
        /// <summary>
        /// 兵营
        /// </summary>
        CAMP,
        /// <summary>
        /// 村庄
        /// </summary>
        VILLAGE,
        /// <summary>
        /// 健身房
        /// </summary>
        GYM,
        /// <summary>
        /// 医院
        /// </summary>
        HOSPITAL,
        /// <summary>
        /// 武器店
        /// </summary>
        WEAPONHSHOP,
        /// <summary>
        /// 道具
        /// </summary>
        PROPSHOP,
        /// <summary>
        ///食物店
        /// </summary>
        FOODSHOP,
        /// <summary>
        /// 青蛙格
        /// </summary>
        FROG
    }
    public class BuildBase : MonoBehaviour
    {
        public BuildType buildType;
        public GameObject dialogGO;

        // Use this for initialization
        void Start()
        {

        }

        /// <summary>
        /// 遇建筑弹出窗口
        /// </summary>
        /// <param name="role"></param>
        public virtual void SetDialog(RoleBase role)
        {

        }

        /// <summary>
        /// 面板上Yes处理
        /// </summary>
        public virtual void DealToEvent()
        {

        }

        /// <summary>
        /// 面板上No处理
        /// </summary>
        /// <param name="buildBase"></param>
        public virtual void NotDealToEvent()
        {

        }

        /// <summary>
        /// 生成Dialog
        /// </summary>
        /// <param name="dialogName"></param>
        protected void CreateDialog(string dialogName)
        {
            dialogGO = ResourcesMgr.GetInstance.LoadObj(ResourcesType.UIWindows,dialogName,false);
            dialogGO.transform.SetParent(GameManager.GetInstance.uiRoot);
            dialogGO.transform.localPosition = Vector3.zero;
            dialogGO.transform.localScale = Vector3.zero;
        }
    }
}
