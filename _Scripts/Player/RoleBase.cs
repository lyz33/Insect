using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FocusFrame;

/// <summary>
/// 功能描述：角色基类
/// </summary>
namespace InsectVillage
{
    public class RoleBase : MonoBehaviour
    {

        public Vector3 moveForward = Vector3.forward;
        public float moveSpeed = 1;
        public ArrayList movePath;       // 行走路径
        private int moveStep;
        private bool canMove = false;


        private int curPathIndex;
        private float pathLength;
        private Vector3 targetPoint;
        private float radiu = 0.05f;

        private bool isFirset = true;


        public bool isMyMove = true;
        public int coinCount = 2000;


        public List<GameObject> soliderList = new List<GameObject>();
        public List<PathNode> MovedPointList = new List<PathNode>();
        public Color color;

        // Use this for initialization
        void Start()
        {
            soliderList.Add(this.gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            PlayerUpdate();
        }


        public virtual void PlayerUpdate()
        {
            Move();
        }

        public void StartMoveInit(int stepCount)
        {
            movePath = new ArrayList();
            PathNode startNode = new PathNode(transform.position);
            movePath = GridManager.GetInstance.GetPath(startNode, stepCount, moveForward, isFirset);
            if (isFirset)
            {
                isFirset = false;
            }
            canMove = true;
            curPathIndex = 0;
            pathLength = movePath.Count;
            PathNode node = (PathNode)movePath[curPathIndex];
            targetPoint = node.pos;
            moveForward = (targetPoint - transform.position).normalized;
        }

        public void Move()
        {
            if (canMove)
            {
                PathNode node = (PathNode)movePath[curPathIndex];
                targetPoint = node.pos;
                if (Vector3.Distance(transform.position, targetPoint) < radiu)
                {
                    if (curPathIndex < pathLength - 1)
                    {
                        curPathIndex++;
                        PathNode nextNode = (PathNode)movePath[curPathIndex];
                        moveForward = (nextNode.pos - transform.position).normalized;
                    }
                    else
                    {
                        canMove = false;
                        MoveOK();
                    }
                }

                if (curPathIndex >= pathLength) return;
                transform.position += moveForward * moveSpeed * Time.deltaTime;
                transform.LookAt(transform.position + moveForward);
            }
        }


        /// <summary>
        /// 完成行走
        /// </summary>
        public void MoveOK()
        {
            PathNode node = new PathNode(transform.position);
            ArrayList neighbours = GridManager.GetInstance.GetNeighbours(node, moveForward, false);
            if (neighbours.Count > 0)
            {
                for (int i = 0; i < neighbours.Count; i++)
                {
                    PathNode tmpNode = neighbours[i] as PathNode;
                    if (tmpNode.cellType == CellType.BUILDING)
                    {

                    }
                }
            }
            else
            {
                MessageCenter.GetInstance.DispatchEvent("NextRoleDeal", null);
            }
        }

        /// <summary>
        /// 获得士兵
        /// </summary>
        /// <param name="soliderGo"></param>
        public void GetSolider(GameObject soliderGo)
        {
            soliderList.Add(soliderGo);

        }

        /// <summary>
        /// 更新  
        /// </summary>
        /// <param name="node"></param>
        public void UpdateMovedPointList(PathNode node)
        {
            int count = MovedPointList.Count - soliderList.Count;
            if (count == -1)
            {
                MovedPointList.Add(node);
            }
            else if (count == 0)
            {

            }
            else
            {

            }
        }

        /// <summary>
        /// 花费金币
        /// </summary>
        /// <param name="value"></param>
        public void CostCoin(int value)
        {
            if (isBuySuccess(value))
            {
                coinCount -= value;
                // 更新面板
            }
            else
            {
                // 提示金币不足
            }
        }

        /// <summary>
        /// 是否够钱
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool isBuySuccess(int value)
        {
            bool isSuccess = false;
            return isSuccess = (coinCount >= value) ? true : false;
        }
    }
}
