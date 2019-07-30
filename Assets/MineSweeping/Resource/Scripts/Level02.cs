using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Level02 : MonoBehaviour
{
    public GameObject[] grids;
    public GameObject[] dangGrids;
    public GameObject[] safeGrids;
    bool isDangFinished;
    bool isSafeFinished;

    public GameObject completeImg;
    public GameObject completeText;

    float timer = 1f;

    void Awake()
    {
        grids = GameObject.FindGameObjectsWithTag("Grids");
        
    }

    private void Update()
    {
        if (dangGrids[0].tag == "dangerous" && dangGrids[1].tag == "dangerous" && dangGrids[2].tag == "dangerous")
            isDangFinished = true;
        else
            isDangFinished = false;
        //////////////////////////////////

        if (safeGrids[0].tag != "dangerous" && safeGrids[1].tag != "dangerous")
            isSafeFinished = true;
        else
            isSafeFinished = false;
        ////////////

        if (isDangFinished && isSafeFinished)
        {
            Debug.Log("finished");
            //completeImg.SetActive(true);

            for (int i = 0; i < grids.Length; i++)
                Destroy(grids[i].GetComponent<BoxCollider2D>());


            completeImg.SetActive(true);

            Color color;
            color = completeImg.GetComponent<SpriteRenderer>().color;
            completeImg.GetComponent<SpriteRenderer>().color = Vector4.Lerp(color, new Vector4(color.r, color.g, color.b, 255f), 0.005f * Time.deltaTime);


            timer -= Time.deltaTime;
            if (timer < 0)
            {
                completeText.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                    Application.LoadLevel("Level03");
            }
        }
    }

}
