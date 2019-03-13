using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform follow;


    void FixedUpdate()
    {

        if (follow.position.x > transform.position.x)
        {
            Vector3 newPos = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
            transform.position = newPos;
            


        }
    }
}
