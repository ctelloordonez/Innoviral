using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level4Manager : MonoBehaviour
{
    private int pieces;
    public GameObject door;

    public void CollectPiece()
    {
        pieces++;
        if(pieces == 2)
        {
            Destroy(door);
        }
    }
   
}
