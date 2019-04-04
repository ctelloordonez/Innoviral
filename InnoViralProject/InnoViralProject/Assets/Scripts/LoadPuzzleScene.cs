using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPuzzleScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Submarine")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("puzzle");
          
        }
    }
}
