using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    const float minPathUpdateTime = .2f;
    const float pathUpdateMoveThreshold = .5f;
    
    public Transform target;
    public float speed = 2.5f;
    public float turnDistance = 5f;
    public float turnSpeed = 3f;
    public float stoppingDistance = 10;

    Path path;
    int targetIndex;

    private void Start()
    {
        StartCoroutine(UpdatePath());
    }

    /*void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, target.position) > 10)
        {
            PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
        }
    }*/

    public void OnPathFound(Vector3[] waypoints, bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            path = new Path(waypoints, transform.position, turnDistance, stoppingDistance);
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    /*IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = path[0];
        while (true)
        {
            if (transform.position == currentWaypoint)
            {
                targetIndex++;

                if ( targetIndex >= path.Length)
                {
                    yield break;
                }

                currentWaypoint = path[targetIndex];
            }

            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            //Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);    // Rotation 
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);      // Rotation
            yield return null;
        }
    }*/
    
    IEnumerator UpdatePath()
    {
        if (Time.timeSinceLevelLoad < .3f)
        {
            yield return new WaitForSeconds(.3f);
        }
        PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);

        float sqrMoveThreshold = pathUpdateMoveThreshold * pathUpdateMoveThreshold;
        Vector3 targetPositionOld = target.position;

        while (true)
        {
            yield return new WaitForSeconds(minPathUpdateTime);
            if((target.position - targetPositionOld).sqrMagnitude > sqrMoveThreshold)
            {
                PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
                targetPositionOld = target.position;
            }
        }
    }


    IEnumerator FollowPath()
    {
        bool followingPath = true;
        int pathIndex = 0;
        transform.LookAt(path.lookPoints[0]);

        float speedPercent = 1;

        while (followingPath)
        {
            Vector2 position2D = new Vector2(transform.position.z, transform.position.y);
            while(path.turnBoundaries[pathIndex].HasCrossedLine(position2D))
            {
                if(pathIndex == path.finishLineIndex)
                {
                    followingPath = false;
                    break;
                }

                else
                {
                    pathIndex++;
                }
            }
            
            if (followingPath)
            {
                if(pathIndex >= path.slowDownIndex && stoppingDistance > 0)
                {
                    speedPercent = Mathf.Clamp01(path.turnBoundaries[path.finishLineIndex].DistanceFromPoint(position2D) / stoppingDistance);
                    if (speedPercent < 0.01f)
                    {
                        followingPath = false;
                    }
                }

                Quaternion targetRotation = Quaternion.LookRotation(path.lookPoints[pathIndex] - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
                transform.Translate(Vector3.forward * Time.deltaTime * speed * speedPercent, Space.Self);
            }


            yield return null;
        }
    }

    /*IEnumerator UpdatePath()
    {
        if(Time.timeSinceLevelLoad < .3f)
        {
            yield return new WaitForSeconds(.3f);
        }
        PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);

        float sqrMoveThreshold = pathUpdateMoveThreshold * pathUpdateMoveThreshold;
        Vector3 targetPositionOld = target.position;

        while (true)
        {
            yield return new WaitForSeconds(minPathUpdateTime);
            if ((target.position - targetPositionOld).sqrMagnitude > sqrMoveThreshold)
            {
                PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
                targetPositionOld = target.position;
            }
        }

    }

    IEnumerator FollowPath()
    {
        bool followingPath = true;
        int pathIndex = 0;
        transform.LookAt(path.lookPoints[0]);

        float speedPercent = 1;

        while (followingPath)
        {
            Vector2 position2D = new Vector2(transform.position.z, transform.position.y);
            while (path.turnBoundaries[pathIndex].HasCrossedLine(position2D))
            {
                if(pathIndex == path.finishLineIndex)
                {
                    followingPath = false;
                    break;
                }

                else
                {
                    pathIndex++;
                }
            }

            if (followingPath)
            {
                
            }

            yield return null;
        }
    }*/

    public void OnDrawGizmos()
    {
        if (path != null)
        {
            path.DrawWithGizmos();
        }
    }
}
