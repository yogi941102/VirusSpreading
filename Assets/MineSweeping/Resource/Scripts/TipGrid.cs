using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipGrid : MonoBehaviour
{
    Canvas canvas;
    Text text;
    bool finished;
    GameObject chatBox;
    GameObject greenTick;

    public enum TipType
    {
        notAssigned,
        d_4_0,
        d_4_1,
        d_4_2,
        d_4_3,
        s_4_1,
        s_4_2,
        s_4_3
    }
    public TipType tipType = TipType.notAssigned;

    public GameObject[] m_4SideGrids;
    public Animator animator;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
        text = FindObjectOfType<Text>();
        text = GameObject.FindGameObjectWithTag("TipText").GetComponent<Text>();
        chatBox = GameObject.FindGameObjectWithTag("Chatbox");
        greenTick = GameObject.FindGameObjectWithTag("GreenTick");
        greenTick.GetComponent<Image>().enabled = false;

    }

    private void Update()
    {
        int m_4DangCount = Get4SidesDangCount();
        int m_4SafeCount = Get4SidesSafeCount();
        
        switch (tipType)
        {
            case TipType.d_4_0:
                finished = (m_4DangCount == 0);
                break;
            case TipType.d_4_1:
                finished = (m_4DangCount == 1);
                break;
            case TipType.d_4_2:
                finished = (m_4DangCount == 2);
                break;
            case TipType.d_4_3:
                finished = (m_4DangCount == 3);
                break;
            case TipType.s_4_1:
                finished = (m_4SafeCount == 1);
                break;
            case TipType.s_4_2:
                finished = (m_4SafeCount == 2);
                break;
            case TipType.s_4_3:
                finished = (m_4SafeCount == 3);
                break;
        }
    }

    private void OnMouseEnter()
    {
        //显示提示
        ShowTip();
        //范围指示器
        Indicate();
        //播放怪物动画
        if (animator != null)
            animator.SetBool("isMouseOver", true);
    }

    private void OnMouseOver()
    {
        chatBox.transform.position = Input.mousePosition + new Vector3(40f,90f,0);
    }

    private void OnMouseExit()
    {
        HideTip();
        HIdeIndicate();

        if(animator!=null)
            animator.SetBool("isMouseOver", false);
    }

    void ShowTip()
    {
        chatBox.SetActive(true);
        //修改提示颜色
        if (finished)
            MarkAsFinished();
        else
            MarkAsUnfinished();

        //修改提示内容
        switch (tipType)
        {
            case TipType.d_4_0:
                text.text = "周围的4块方块都没有毒";
                break;
            case TipType.d_4_1:
                text.text = "周围的4块方块中1块有毒";
                break;
            case TipType.d_4_2:
                text.text = "周围的4块方块中2块有毒";
                break;
            case TipType.d_4_3:
                text.text = "周围的4块方块中3块有毒";
                break;
            case TipType.s_4_1:
                text.text = "周围的4块方块中1块有毒";
                break;
            case TipType.s_4_2:
                text.text = "周围的4块方块中2块有毒";
                break;
            case TipType.s_4_3:
                text.text = "周围的4块方块中3块有毒";
                break;
        }
    }

    void HideTip()
    {
        text.text = null;
        chatBox.SetActive(false);
    }

    void Indicate() { }
    void HIdeIndicate() { }

    //获取4面dangerous的数量
    int Get4SidesDangCount()
    {
        int m_4DangCount = 0;

        for(int i = 0; i < m_4SideGrids.Length; i++)
        {
            if (m_4SideGrids[i].tag == "dangerous")
                m_4DangCount++;
        }

        return m_4DangCount;
    }

    //获取4面safe的数量
    int Get4SidesSafeCount()
    {
        int m_4SafeCount = 0;

        for (int i = 0; i < m_4SideGrids.Length; i++)
        {
            if (m_4SideGrids[i].tag == "safe")
                m_4SafeCount++;
        }

        return m_4SafeCount;
    }

    void MarkAsFinished()
    {
        greenTick.GetComponent<Image>().enabled = true;
        //text.color = Color.green;
    }

    void MarkAsUnfinished()
    {
        greenTick.GetComponent<Image>().enabled = false;
        //text.color = Color.red;
    }
}
