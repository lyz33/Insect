using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 路径节点
/// </summary>
namespace InsectVillage
{
    public enum CellType
    {
        NONE,                // 这个表示可行走
        BUILDING,
        OBSTACLE             // 障碍物
    }
    public class PathNode
    {
        public Vector3 pos;

        public PathNode parentNode;     // 父子点

        public bool isObstacle;         // 可以是障碍物，也可是兵营等等

        public CellType cellType;

        public PathNode()
        {
            parentNode = null;
        }

        public PathNode(Vector3 pos)
        {
            this.pos = pos;
            parentNode = null;
            isObstacle = false;
            cellType = CellType.NONE;
        }

        /// <summary>
        /// 标志为障碍物
        /// </summary>
        public void MaskAsObstacle()
        {
            this.isObstacle = true;
        }


        public void MaskCellType(CellType value)
        {
            cellType = value;
        }
    }

}
