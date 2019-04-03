using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePuzzle : MonoBehaviour
{

    [SerializeField]
    private Transform[] pieces;

    [SerializeField]
    private GameObject winText;

    public static bool youWin;

    // Start is called before the first frame update
    void Start()
    {
        
        winText.SetActive(false);
        youWin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pieces[0].rotation.z == 0 &&
            pieces[1].rotation.z == 0 &&
            pieces[2].rotation.z == 0 &&
            pieces[3].rotation.z == 0 &&
            pieces[4].rotation.z == 0 &&
            pieces[5].rotation.z == 0)
        {
            youWin = true;
            winText.SetActive(true);
        }


    }
}
