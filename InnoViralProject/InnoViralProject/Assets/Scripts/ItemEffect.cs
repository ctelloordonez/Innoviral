using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{

  //  public GameObject effect;
    private Transform player;
    public GameObject light;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Submarine").transform;
        light.SetActive(false);
    }

    // Update is called once per frame
    public void Use()
    {
        light.SetActive(true);
    }
}
