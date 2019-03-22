using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeMenu
{
    [System.Serializable]
    public class NodeData
    {
        public int id;
        public string Name;
        public bool NodeIsOpen =true;
        /// <summary>
        /// Y轴层级 0-Root
        /// </summary>
        public int LevelY = 0;
        /// <summary>
        /// X轴层级 0-Root
        /// </summary>
        public int LevelX;
        public float widthPos=50;
        public float PosY => LevelY * widthPos;
        public float PosX => LevelX * 20;
        public List<NodeData> NodeDatas { get; } = new List<NodeData>();

        public NodeData(int id, string str)
        {
            this.id = id;
            Name = str;
         }

        public void AddNodeDatas(params NodeData[] nodes)
        {
            foreach (var item in nodes)
            {
                NodeDatas.Add(item);
                item.LevelX = LevelX + 1;
            }
        }
        
    }
}
