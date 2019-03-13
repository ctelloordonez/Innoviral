using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToMove : MonoBehaviour
{
    public float speed = 10f;
    public float acceleration = 1f;
    public float turnSpeed = 10f;

    Rigidbody m_RigidBody;

    Touch touch;
    Vector3 touchPosition, whereToMove;
    bool isMoving = false;
    Vector3 movement;

    float curSpeed;

    float previousDistanceToTouchPos, currentDistanceToTouchPos;

    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        curSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        if (isMoving)
            currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            Debug.DrawLine(transform.position, touchPosition, Color.white);

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("touchPosition: " + touchPosition);
                Debug.Log("touch.position: " + touch.position);

                previousDistanceToTouchPos = 0;
                currentDistanceToTouchPos = 0;
                isMoving = true;
                touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.farClipPlane));
                touchPosition.z = transform.position.z;
                whereToMove = (touchPosition - transform.position).normalized;
                m_RigidBody.velocity = new Vector3(whereToMove.x, whereToMove.y, 0).normalized * speed;
             //   transform.LookAt(touchPosition);

            }
        }

        if (currentDistanceToTouchPos > previousDistanceToTouchPos)
        {
            isMoving = false;
            m_RigidBody.velocity = Vector3.zero;
        }

        if (isMoving)
            previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;
    }

    private void Turn()
    {

    }
}
