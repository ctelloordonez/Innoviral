using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject bladeTrailPrefab;
    public float minCuttingVelocity = .001f;

    bool isCutting = false;

    Vector3 previousPosition;
    Vector3 touchPos;

    GameObject currentBladeTrail;

    Camera _camera;
    SphereCollider _sphereCollider;
    Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _sphereCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchPos = _camera.ScreenToWorldPoint(touch.position);
            touchPos.x = transform.position.x;

            if(touch.phase == TouchPhase.Moved && !isCutting)
            {
                StartCutting();
            }

            else if(touch.phase == TouchPhase.Ended && isCutting)
            {
                StopCutting();
            }

            if (isCutting)
            {
                UpdateCut();
            }
        }

       
    }

    void UpdateCut()
    {
        Vector3 newPosition = touchPos;
        transform.position = newPosition;

        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
        _sphereCollider.enabled = velocity > minCuttingVelocity;
        previousPosition = newPosition;
    }

    void StartCutting()
    {
        isCutting = true;
        previousPosition = touchPos;
        _sphereCollider.enabled = false;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
    }

    void StopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
        _sphereCollider.enabled = false;
    }
}
