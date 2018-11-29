using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 网格管理
/// </summary>
namespace InsectVillage
{
    public class GridManager : MonoBehaviour
    {
        public static GridManager GetInstance;
        //public static GridManager GetInstance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new GridManager();
        //        }
        //        return instance;
        //    }
        //}
        public int numOfRows = 9;                       // 行数
        public int numOfColumns = 12;                   // 列数
        public int gridCellSize = 2;                    // 网格大小
        private GameObject[] obstacleList;              // 存储障碍点
        private GameObject[] campList;                  // 兵营
        private GameObject[] villageList;               // 村庄
        private PathNode[,] nodes;                      //  整个网格数组
        public Vector3 origin;                          // 网格原点
        public bool showGrid = false;

        // Use this for initialization
        void Awake()
        {
            GetInstance = this;
            obstacleList = GameObject.FindGameObjectsWithTag("Obstacle");
            campList = GameObject.FindGameObjectsWithTag("Camp");
            villageList = GameObject.FindGameObjectsWithTag("Village");
        }

        void Start()
        {
            CalculateObstacles();
        }
        // Update is called once per frame
        void Update()
        {

        }

        public void CalculateObstacles()
        {
            nodes = new PathNode[numOfRows, numOfColumns];
            int index = 0;
            // 获取所有网格
            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfColumns; j++)
                {
                    PathNode node = new PathNode(GetGridCellCenter(index));
                    nodes[i, j] = node; // 数组存储
                    index++;
                }
            }

            if (obstacleList != null && obstacleList.Length > 0)
            {
                foreach (GameObject go in obstacleList)
                {
                    int cellIndex = GetGridIndex(go.transform.position);
                    int col = GetColumn(cellIndex);
                    int row = GetRow(cellIndex);
                    //nodes[row, col].MaskAsObstacle();
                    nodes[row, col].MaskCellType(CellType.OBSTACLE);
                }
            }

         
        }

        /// <summary>
        /// 根据第几个网格获取网格的中心点
        /// </summary>
        /// <param name="index"></param>
        public Vector3 GetGridCellCenter(int index)
        {
            Vector3 cellPos = GetGridCellPosition(index);
            cellPos.x += (gridCellSize / 2.0f);
            cellPos.z += (gridCellSize / 2.0f);

            return cellPos;
        }

        /// <summary>
        /// 根据第几个网格获取得位置
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Vector3 GetGridCellPosition(int index)
        {
            int column = GetColumn(index);
            int row = GetRow(index);
            float xPosInGrid = column * gridCellSize;
            float zPosInGrid = row * gridCellSize;

            return origin + new Vector3(xPosInGrid, 0, zPosInGrid);
        }

        /// <summary>
        /// 根据位置获取第几个网格
        /// </summary>
        /// <returns></returns>
        public int GetGridIndex(Vector3 pos)
        {
            pos -= origin;
            int column = (int)(pos.x / gridCellSize);  // 列数
            int row = (int)(pos.z / gridCellSize);     // 行数
            return (numOfColumns * row + column);
        }

        /// <summary>
        /// 获取第几列
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetColumn(int index)
        {
            int col = index % numOfColumns;
            return col;
        }

        /// <summary>
        /// 获取第几行
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetRow(int index)
        {
            int row = index / numOfColumns;
            return row;
        }

        /// <summary>
        ///获取当前点附件可能的点，不能往回走
        /// </summary>
        /// <returns></returns>
        public ArrayList GetNeighbours(PathNode node, Vector3 forward, bool canMove)
        {
            ArrayList arrayList = new ArrayList();
            Vector3 cellPos = node.pos;
            int cellIndex = GetGridIndex(cellPos);
            int row = GetRow(cellIndex);
            int col = GetColumn(cellIndex);

            int rightNodeRow = 0;
            int rightNodeCol = 0;
            //相邻右格
            if (forward.x >= 0)
            {
                rightNodeRow = row;
                rightNodeCol = col + 1;
                AssignNeighour(rightNodeRow, rightNodeCol, arrayList, canMove);
            }

            // 相邻左格
            if (forward.x <= 0)
            {
                rightNodeRow = row;
                rightNodeCol = col - 1;
                AssignNeighour(rightNodeRow, rightNodeCol, arrayList, canMove);
            }

            // 相邻上格
            if (forward.z >= 0)
            {
                rightNodeRow = row + 1;
                rightNodeCol = col;
                AssignNeighour(rightNodeRow, rightNodeCol, arrayList, canMove);
            }

            // 相邻下格
            if (forward.z <= 0)
            {
                rightNodeRow = row - 1;
                rightNodeCol = col;
                AssignNeighour(rightNodeRow, rightNodeCol, arrayList, canMove);
            }
            return arrayList;
        }

        /// <summary>
        /// 存储有可能的相邻格子
        /// </summary>
        /// <param name="row">行</param>
        /// <param name="col">纵</param>
        /// <param name="neighbour">存储数组</param>
        /// <param name="CanMove">是否用于行走的</param>
        private void AssignNeighour(int row, int col, ArrayList neighbour, bool CanMove)
        {
            if (row != -1 && col != -1 && row < numOfRows && col < numOfColumns)
            {
                PathNode node = nodes[row, col];
                if (CanMove)
                {
                    if (node.cellType == CellType.NONE)
                    {
                        neighbour.Add(node);
                    }
                }
                else
                {
                    if (node.cellType != CellType.NONE && node.cellType != CellType.OBSTACLE)
                    {
                        neighbour.Add(node);
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startPoint">开始点</param>
        /// <param name="stepCount">步数</param>
        /// <param name="forward">方向,单位向量</param>
        /// <param name="IsFirst">刚刚开始,即第一次沿角色方向为准</param>
        /// <returns></returns>
        public ArrayList GetPath(PathNode node, int stepCount, Vector3 forward, bool IsFirst)
        {
            ArrayList arrayList = new ArrayList();

            //Vector3 cellPos = node.pos;
            //int cellIndex = GetGridIndex(cellPos);
            //int row = GetRow(cellIndex);
            //int col = GetColumn(cellIndex);

            //  PathNode nextNode = null;
            for (int i = 0; i < stepCount; i++)
            {
                if (IsFirst)
                {
                    Vector3 cellPos = node.pos;
                    int cellIndex = GetGridIndex(cellPos);
                    int row = GetRow(cellIndex);
                    int col = GetColumn(cellIndex);
                    node = nodes[(row + (int)forward.z), (col + (int)forward.x)];
                    arrayList.Add(node);
                }
                else
                {
                    PathNode oldNode = node;
                    ArrayList neighbour = GetNeighbours(node, forward, true);
                    if (neighbour.Count == 1)
                    {
                        node = (PathNode)neighbour[0];
                        arrayList.Add(node);
                    }
                    else if (neighbour.Count == 2)
                    {
                        float index = Random.Range(0f, 1f);
                        if (index > 0.5f)
                        {
                            node = (PathNode)neighbour[0];
                        }
                        else
                        {
                            node = (PathNode)neighbour[1];
                        }
                        arrayList.Add(node);
                    }
                    forward = (node.pos - oldNode.pos).normalized;
                }
            }
            return arrayList;
        }

        void OnDrawGizmos()
        {
            if (showGrid)
            {
                DebugDrawGrid(origin, numOfRows, numOfColumns, gridCellSize, Color.red);
            }
        }


        private void DebugDrawGrid(Vector3 origin, int numRows, int numColumns, float cellSize, Color color)
        {
            float width = numColumns * cellSize;
            float height = numRows * cellSize;
            for (int i = 0; i < numRows + 1; i++)
            {
                Vector3 startPos = origin + i * cellSize * new Vector3(0.0f, 0.0f, 1.0f);
                Vector3 endPos = startPos + width * new Vector3(1.0f, 0.0f, 0.0f);
                Debug.DrawLine(startPos, endPos, color);
            }
            for (int i = 0; i < numColumns + 1; i++)
            {
                Vector3 startPos = origin + i * cellSize * new Vector3(1.0f, 0.0f, 0.0f);
                Vector3 endPos = startPos + height * new Vector3(0.0f, 0.0f, 1.0f);
                Debug.DrawLine(startPos, endPos, color);
            }
        }
    }
}
