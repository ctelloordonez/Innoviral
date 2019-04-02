using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.tag == "Trap")
        {
            PlayerHealth.health -= 1;
            if(PlayerHealth.health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
