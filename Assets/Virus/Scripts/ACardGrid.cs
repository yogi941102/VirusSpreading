using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACardGrid : GridInfo
{
    public List<GameObject> ShinyGrids = new List<GameObject>();
    private BoardManager boardManager;

    private void Start()
    {
        boardManager = Camera.main.GetComponent<BoardManager>();
    }

    private void OnMouseOver()
    {
        ShowBenefits();
    }

    private void OnMouseDown()
    {
        if (GameManager.instance.gameState == GameManager.GameState.aMove)
        {
            //SpreadTheVirus();
            //MarkCardAsUsed();
            GameManager.instance.gameState = GameManager.GameState.bMove;
        }
    }

    void ShowBenefits()
    {
        for(int i = 0; i < GameManager.instance.AGrids.Count; i++)
        {
            for(int j = 0; j < boardManager.allGrids.Count; j++)
            {
                GridInfo gridInfo;
                gridInfo = boardManager.allGrids[j].GetComponent<GridInfo>();


                //if(grid.cardNo == GameManager.instance.AGrids[i].GetComponent<GridInfo>().cardNo)
            }
            //if (GameManager.instance.AGrids[i].GetComponent<GridInfo>().cardNo)
        }
    }
}
