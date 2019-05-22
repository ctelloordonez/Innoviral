using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public GameObject music;
   


    public void Use()
    {
        music.SetActive(!music.activeSelf);  
      
    }


}
