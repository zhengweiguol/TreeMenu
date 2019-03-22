using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace TreeMenu {
    public class NodeUI : MonoBehaviour
    {
        public NodeData Data;
        /// <summary>
        /// 箭头按钮
        /// </summary>
        public Button btnArrow;
        public Text textName;
        RectTransform rectTransform;
        public Action<NodeUI> BtnOnClick;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            btnArrow.onClick.AddListener(OnClickBtn);
        }

        void OnClickBtn()
        {
            BtnOnClick?.Invoke(this);
            SetArrowBtnState(Data.NodeIsOpen);
        }

        void SetArrowBtnState(bool i)
        {
            if (i)
                btnArrow.transform.localEulerAngles = new Vector3(0, 0, 0);
            else
                btnArrow.transform.localEulerAngles = new Vector3(0, 0, 90);
        }
        public void SetData(NodeData nodeData)
        {
            Data = nodeData;
            textName.text = nodeData.Name;
            rectTransform.anchoredPosition = new Vector2(Data.PosX, 0);
            btnArrow.gameObject.SetActive(Data.NodeDatas.Count <= 0 ? false : true);
            SetArrowBtnState(Data.NodeIsOpen);
        }

        public void SetPos()
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -Data.PosY); 
        }
        

    }
}

