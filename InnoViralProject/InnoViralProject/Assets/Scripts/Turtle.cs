using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    Unit unit;
    bool trapped;

    // Start is called before the first frame update
    void Start()
    {
        unit = GetComponent<Unit>();
        trapped = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Trapped
    {
        get
        {
            return trapped;
        }
        set
        {
            trapped = value;

            if (trapped)
                gameObject.layer = 9;
            else
                gameObject.layer = 0;

            unit.enabled = !trapped;
        }
    }
}
