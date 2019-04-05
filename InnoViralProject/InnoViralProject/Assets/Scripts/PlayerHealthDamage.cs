using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.tag == "Trap")
        {
            SubmarineHealth.playerHealth -= 1;
            if(SubmarineHealth.playerHealth == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
