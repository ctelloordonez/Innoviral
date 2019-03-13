using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndMove : MonoBehaviour
{
    [SerializeField]
    public float speed;

    Rigidbody2D rb;

    Touch touch;
    Vector3 touchPosition, whereToMove;
    bool isMoving;

    float previousDistanceToTouchPos, currentDistanceToTouchPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isMoving)
            currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;

        if(Input.touchCount > 1)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                previousDistanceToTouchPos = 0;
                currentDistanceToTouchPos = 0;
                isMoving = true;
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;
                whereToMove = (touchPosition - transform.position).normalized;
                rb.velocity = new Vector2(whereToMove.x * speed, whereToMove.y * speed);

            }
            if ( currentDistanceToTouchPos > previousDistanceToTouchPos)
            {
                isMoving = false;
                rb.velocity = Vector2.zero;
            }
            if (isMoving)
                previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;

        }
    }
}
