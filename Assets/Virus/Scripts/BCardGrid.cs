using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCardGrid : GridInfo
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        //ShowBenefits();
    }

    private void OnMouseDown()
    {
        if (GameManager.instance.gameState == GameManager.GameState.bMove)
        {
            //SpreadTheVirus();
            //MarkCardAsUsed();
            GameManager.instance.gameState = GameManager.GameState.aMove;
        }
    }
}
