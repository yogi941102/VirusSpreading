using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardGrid : GridInfo
{
    public bool canClick;

    void Start()
    {
        canClick = false;
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //点击后标记为A/B
        if (GameManager.instance.gameState == GameManager.GameState.aFirstMove)
        {
            MarkAsA();
            DisableThis();
            GameManager.instance.AGrids.Add(gameObject);
            GameManager.instance.gameState = GameManager.GameState.bFirstMove;
        }
        else if (GameManager.instance.gameState == GameManager.GameState.bFirstMove)
        {
            MarkAsB();
            DisableThis();
            GameManager.instance.BGrids.Add(gameObject);
            GameManager.instance.gameState = GameManager.GameState.aMove;
        }
    }

    private void DisableThis()
    {
        Destroy(GetComponent<StandardGrid>());
    }

    public void MarkAsA()
    {
        GetComponent<GridInfo>().belonging = Belonging.a;
    }

    public void MarkAsB()
    {
        GetComponent<GridInfo>().belonging = Belonging.b;
    }
}
