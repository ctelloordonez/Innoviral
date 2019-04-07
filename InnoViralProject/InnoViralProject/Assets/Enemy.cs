using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void TakeDamage()
    {
        Health -= 1;
        if(Health <= 0)
        {
            Debug.Log("TakeDamage");
            Destroy(gameObject);
        }
    }
}
