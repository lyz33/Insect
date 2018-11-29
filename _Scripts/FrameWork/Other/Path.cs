using UnityEngine;

/// <summary>
/// 功能描述：路径
/// </summary>
namespace FocusFrame
{
    public class Path : MonoBehaviour
    {
        public bool bDebug = true;
        public Transform[] pointArray;
        public float Radius = 2.0f;
        public Color lineColor;

        void Awake()
        {
            ArrayInit();
        }

        /// <summary>
        /// 数组初始化
        /// </summary>
        public void ArrayInit()
        {
            if (pointArray.Length == 0)
                pointArray = gameObject.GetComponentsInChildren<Transform>();
        }

        /// <summary>
        /// 获取长度
        /// </summary>
        public float Length
        {
            get
            {
                return pointArray.Length;
            }
        }

        /// <summary>
        /// 获取节点位置
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Vector3 GetPoint(int index)
        {
            return pointArray[index].position;
        }

        void OnDrawGizmos()
        {
            if (!bDebug) return;

            for (int i = 0; i < pointArray.Length - 1; i++)
            {
                Debug.DrawLine(pointArray[i].position, pointArray[i + 1].position, lineColor);
            }
        }
    }
}
