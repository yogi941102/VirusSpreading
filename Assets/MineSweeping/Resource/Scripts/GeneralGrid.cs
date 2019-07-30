using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralGrid : MonoBehaviour
{
    public enum Status { neutral, safe, dangerous }
    public Status status = Status.neutral;

    public GameObject template;
    public Sprite dangerous;
    public Sprite neutral;
    public Sprite safe;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        template = GameObject.FindGameObjectWithTag("Template");

        dangerous = template.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
        neutral = template.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite;
        safe = template.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnMouseDown()
    {
        switch (status)
        {
            case Status.neutral:
                SetAsDangerous();
                status = Status.dangerous;
                tag = "dangerous";
                break;
            case Status.dangerous:
                SetAsSafe();
                status = Status.safe;
                tag = "safe";
                break;
            case Status.safe:
                SetAsNeutral();
                status = Status.neutral;
                tag = "neutral";
                break;
        }
    }

    void SetAsDangerous()
    {
        spriteRenderer.sprite = dangerous;
    }

    void SetAsSafe()
    {
        spriteRenderer.sprite = safe;
    }

    void SetAsNeutral()
    {
        spriteRenderer.sprite = neutral;
    }
}
