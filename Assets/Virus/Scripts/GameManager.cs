using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private BoardManager boardScript;
    private bool doingSetup = true;
    public enum GameState
    {
        aFirstMove,
        bFirstMove,
        aMove,
        bMove,
        aFree,
        bFree,
        aNewCard,
        bNewCard
    }

    public GameState gameState;

    public List<GameObject> AGrids = new List<GameObject>();
    public List<GameObject> BGrids = new List<GameObject>();

    //初始化
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        //获取boardmanager组件
        boardScript = GetComponent<BoardManager>();

        //生成board以及初始化信息
        InitGame();

        //第一步是A玩家先动
        gameState = GameState.aFirstMove;
    }

    private void Update()
    {
        if (doingSetup)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
          InitGame();
    }

    void InitGame()
    {
        doingSetup = true;
        boardScript.SetupScene();
        doingSetup = false;

        gameState = GameState.aFirstMove;
    }
}
