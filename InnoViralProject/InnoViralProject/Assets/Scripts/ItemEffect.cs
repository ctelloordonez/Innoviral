using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{

  //  public GameObject effect;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Submarine").transform;
    }

    // Update is called once per frame
    public void Use()
    {
        // Instantiate(effect, player.position, Quaternion.identity);
        PlayerHealth.health += 1;
        Destroy(gameObject);
    }
}
