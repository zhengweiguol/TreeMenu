using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeMenu
{
    public class TreeMenu : MonoBehaviour
    {
        public NodeUI NodeUIItem;
        public NodeData rootNode;
        public int index;
        public float NodeWidth;
        public int levelY=0;
        public List<NodeUI> nodeUIs = new List<NodeUI>();
        void Start()
        {
            rootNode = new NodeData(1,"章节");
            rootNode.LevelX = 0;
            NodeData node01 = new NodeData(2, "第一章");
            NodeData node02 = new NodeData(3, "第二章");
            NodeData node03 = new NodeData(4, "第三章");
            rootNode.AddNodeDatas(node01, node02, node03);

            NodeData node010 = new NodeData(10, "关卡01");

            NodeData node011 = new NodeData(11, "关卡02");
            NodeData node012 = new NodeData(12, "关卡03");
            node01.AddNodeDatas(node010, node011, node012);

            for (int i = 0; i < 4; i++)
            {
                node010.AddNodeDatas(new NodeData(node010.id * 10 + i, $"阶段{node010.id * 10}"));
            }
            NodeData node020 = new NodeData(20, "关卡20");
            NodeData node021 = new NodeData(21, "关卡21");
            NodeData node022 = new NodeData(22, "关卡23");
            node02.AddNodeDatas(node020, node021, node022);
            CreateTree(rootNode);
            RefreshPos();
        }

        void CreateTree(NodeData data)
        {
            GameObject obj = Instantiate(NodeUIItem.gameObject, this.transform, false);
            obj.SetActive(true);
            NodeUI UI = obj.GetComponent<NodeUI>();
            UI.SetData(data);
            UI.BtnOnClick = ClickTreeItem;
            nodeUIs.Add(UI);
            foreach (var item in data.NodeDatas)
            {
                CreateTree(item);
            }
        }

        public void ClickTreeItem(NodeUI nodeUI)
        {
            nodeUI.Data.NodeIsOpen = !nodeUI.Data.NodeIsOpen;
            RefreshPos();
        }
        /// <summary>
        /// 刷新节点位置
        /// </summary>
        public void RefreshPos() {
            levelY = 0;
            InitNodeY(rootNode);
            SetNodeY(rootNode);
            foreach (var item in nodeUIs)
            {
                item.SetPos();
            }
        }
        /// <summary>
        /// 还原Y轴索引
        /// </summary>
        /// <param name="data"></param>
        void InitNodeY(NodeData data)
        {
            data.LevelY = -100;
            foreach (var item in data.NodeDatas)
            {
                InitNodeY(item);
            }
        }

        void SetNodeY(NodeData data)
        {
            levelY += 1;
            data.LevelY = levelY;
            if (data.NodeIsOpen)
            {
                foreach (var item in data.NodeDatas)
                {
                    SetNodeY(item);
                }
            }
        }

       
        void Update()
        {

        }
    }
}
   
