using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPlastics : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Submarine")
        {
            Destroy(gameObject);
            Score.scoreValue += 1;
        }
    }
}
