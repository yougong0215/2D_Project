using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitR : PlayerMove
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition = new Vector3(0.2f, -0.1f, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition = new Vector3(0.07f, -0.1f, 0);
        }
    }
}
