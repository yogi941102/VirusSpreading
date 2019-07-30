using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int maximum;
        public int minimum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }


    public int columns = 10;
    public int rows = 10;
    public int numberPerColor = 20;
    public int objectCount = 20;

    public GameObject[] greenTiles;
    public GameObject[] blueTiles;
    public GameObject[] redTiles;
    public GameObject[] orangeTiles;
    public GameObject[] purpleTiles;
    public GameObject[] cards;

    //public GameObject green1;
    //public GameObject green2;
    //public GameObject green3;
    //public GameObject green4;
    //public GameObject green5;

    //public GameObject blue1;
    //public GameObject blue2;
    //public GameObject blue3;
    //public GameObject blue4;
    //public GameObject blue5;

    //public GameObject red1;
    //public GameObject red2;
    //public GameObject red3;
    //public GameObject red4;
    //public GameObject red5;

    //public GameObject orange1;
    //public GameObject orange2;
    //public GameObject orange3;
    //public GameObject orange4;
    //public GameObject orange5;

    //public GameObject purple1;
    //public GameObject purple2;
    //public GameObject purple3;
    //public GameObject purple4;
    //public GameObject purple5;

    private GameObject boardHolder;
    public GameObject board;
    private List<Vector3> gridPositions = new List<Vector3>();
    public List<GameObject> allGrids = new List<GameObject>();

    void InitialiseList()
    {
        Destroy(boardHolder);
        boardHolder = new GameObject("Board");

        gridPositions.Clear();
        
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
                gridPositions.Add(new Vector3(x, y, 0f));
        }
    }

    //实例化道具卡
    void MakeCards()
    {
        for(int i = 0; i < cards.Length; i++)
        {
            GameObject instanceA =
                Instantiate(cards[i], new Vector3(-3, i, 0f), Quaternion.identity) as GameObject;
            instanceA.GetComponent<GridInfo>().cardNum = i;

            GameObject instanceB =
                Instantiate(cards[i], new Vector3(12, i, 0f), Quaternion.identity) as GameObject;
            instanceB.GetComponent<GridInfo>().cardNum = i;

            instanceA.transform.SetParent(boardHolder.transform);
            instanceB.transform.SetParent(boardHolder.transform);
        }
    }

    //随机位置
    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray)
    {
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

            GameObject instance = 
                Instantiate(tileChoice, randomPosition, Quaternion.identity) as GameObject;
            allGrids.Add(instance);

            //记录位置
            GridInfo gridInfo;
            gridInfo = instance.GetComponent<GridInfo>();
            gridInfo.x = (int)randomPosition.x;
            gridInfo.y = (int)randomPosition.y;
            gridInfo.cardNo = (int)randomPosition.y * 10 + (int)randomPosition.x;

            instance.transform.SetParent(boardHolder.transform);
        }
    }

    public void SetupScene()
    {
        InitialiseList();
        LayoutObjectAtRandom(greenTiles);
        LayoutObjectAtRandom(redTiles);
        LayoutObjectAtRandom(orangeTiles);
        LayoutObjectAtRandom(purpleTiles);
        LayoutObjectAtRandom(blueTiles);

        MakeCards();
    }
}
