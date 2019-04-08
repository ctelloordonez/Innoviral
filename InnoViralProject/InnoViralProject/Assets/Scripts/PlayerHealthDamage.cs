using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.tag == "Enemy")
        {
            SubmarineHealth.playerHealth -= 1;
            if(SubmarineHealth.playerHealth == 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
            }
        }
    }
}
