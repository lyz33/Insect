using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FocusFrame;
/// <summary>
/// 记录骰子数
/// </summary>
namespace InsectVillage
{
    public class NumOfDish : Singleton<NumOfDish>
    {

        // Use this for initialization
        void Start()
        {

        }

        /// <summary>
        /// 随机骰子数
        /// </summary>
        /// <returns></returns>
        public int RandomNum()
        {
            return Random.Range(1,7);
        }
    }
}
