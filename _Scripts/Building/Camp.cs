using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InsectVillage
{
    public class Camp : BuildBase
    {
        public int buyPrice;
        public string soliderName;

        public override void SetDialog(RoleBase role)
        {
            CreateDialog("BuySoliderDialog");
        }

        public override void DealToEvent()
        {
            BuySolider();
        }

        public void BuySolider()
        {
            GameObject soliderGo = ResourcesMgr.GetInstance.LoadObj(ResourcesType.Role,soliderName,false);

        }
    }
}
