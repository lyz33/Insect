using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FocusFrame;
/// <summary>
/// 程序主类
/// </summary>

namespace InsectVillage
{
    public class GameManager : Singleton<GameManager>
    {

        public RoleBase[] PlayerArray;
        public RoleBase currentRoleBase { get; set; }
        private int currentRoleIndex = 0;

        public Transform uiRoot { get; private set; }

        // Use this for initialization
        void Start()
        {
            MessageCenter.GetInstance.AddEventListener("NextRoleDeal", NextRoleDeal);
        }

        void OnDisable()
        {
            MessageCenter.GetInstance.RemoveEventListener("NextRoleDeal");
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// 下一个角色处理
        /// </summary>
        public void NextRoleDeal(Notification notific)
        {
            currentRoleIndex++;
            if (currentRoleIndex >= PlayerArray.Length)
            {
                currentRoleIndex = 0;
            }
            currentRoleBase = PlayerArray[currentRoleIndex];
            currentRoleBase.isMyMove = true;
        }
    }
}
