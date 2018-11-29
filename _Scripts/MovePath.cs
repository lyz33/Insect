using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 获取的行走路径
/// </summary>
namespace InsectVillage
{
    public class MovePath : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// 计算路径,世界方向x右正，z上正
        /// </summary>
        /// <param name="startPoint">开始点</param>
        /// <param name="stepCount">步数</param>
        /// <param name="forward">方向</param>
        /// <returns></returns>
        public static ArrayList CalculatePath(PathNode startPoint,int stepCount,Vector3 forward)
        {
            ArrayList arrayList = new ArrayList();
            //GridManager.GetInstance.GetNeighbours(startPoint,arrayList);

            //Vector3 cellPos = node.position;
            //int cellIndex = GetGridIndex(cellPos);
            //int row = GetRow(cellIndex);
            //int col = GetColumn(cellIndex);
            //PathNode next
            // 把相邻的节点放到openArray中，但节点只能是可行走的
            //for (int i=0;i<arrayList.Count;i++)
            //{
            //    PathNode neighbour = (PathNode)arrayList[i];
            //    if(neighbour)
            //}
            return arrayList;
        } 
    }
}
