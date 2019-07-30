using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInfo : MonoBehaviour
{
    public int x = -1;
    public int y = -1;
    public int cardNum = -999;
    public int cardNo = -999;
    public enum Belonging
    {
        neutral,
        a,
        b
    }

    public Belonging belonging = Belonging.neutral;
}
