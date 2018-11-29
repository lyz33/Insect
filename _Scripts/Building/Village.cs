using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 村庄的功能
/// </summary>

namespace InsectVillage
{

    public class Village : BuildBase
    {
        public RoleBase master;    // 属于谁的
        public int buyPrice;
        public int levelUpPrice;
        public int level;
        public int maxLevel = 3;
        public int tollPrice;     // 过路费 

        private Material mat;

        // Use this for initialization
        void Start()
        {
            mat = this.GetComponent<Renderer>().material;
        }

        public override void SetDialog(RoleBase role)
        {
            base.SetDialog(role);
            if (master == null)  // 没人占领，，是否购买
            {
                CreateDialog("BuyVillageDialog");
            }
            else // 已有人占领，
            {
                if (master == role)  // 还是自己遇上，，是否升级
                {
                    CreateDialog("LevelUpVillageDialog");
                }
                else                 // 如果是其他人遇上了，，提示上交过路费
                {
                    CreateDialog("TollVillageDialog");
                }
            }
        }

        public override void DealToEvent()
        {
            if (master == null)  // 没人占领，，是否购买
            {
                BuyVillage();
            }
            else // 已有人占领，
            {
                if (master == GameManager.GetInstance.currentRoleBase)  // 还是自己遇上，，是否升级
                {
                    LevelUp();
                }
                else
                {
                    GetCoins();
                }
            }
        }

        public override void NotDealToEvent()
        {
            if (master)
            {
                if (master != GameManager.GetInstance.currentRoleBase)  
                {
                    // 处理战斗
                    Battle(); 
                }
            }
        }


        /// <summary>
        /// 面板上No处理
        /// </summary>
        /// <param name="buildBase"></param>
        public virtual void NotDealToEvent(BuildBase buildBase)
        {

        }


        /// <summary>
        /// 购买
        /// </summary>
        public void BuyVillage()
        {
            master = GameManager.GetInstance.currentRoleBase;
            mat.SetColor("_Color", master.color);
        }

        /// <summary>
        /// 升级
        /// </summary>
        public void LevelUp()
        {
            level++;
            if (level > maxLevel)
            {
                level = maxLevel;
            }
        }

        /// <summary>
        /// 获得过路费
        /// </summary>
        public void GetCoins()
        {
            // todo  是否直接给英雄
        }

        /// <summary>
        /// 战斗
        /// </summary>
        public void Battle()
        {
            // todo
        }
    }
}
