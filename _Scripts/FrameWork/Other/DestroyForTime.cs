using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FocusFrame
{
    public class DestroyForTime : MonoBehaviour
    {
        public float stayTime;

        // Use this for initialization
        void OnEnable()
        {
            StartCoroutine(StayForTime());
        }

        IEnumerator StayForTime()
        {
            yield return new WaitForSeconds(stayTime);
            PoolManager.GetInstance.RecycleObject(this.gameObject);
        }
    }
}
