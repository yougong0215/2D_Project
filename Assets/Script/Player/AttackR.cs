using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackR : PlayerMove
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition = new Vector3(0.2f,0,0);
        }
        if (Input.GetKey(KeyCode.A))
        {

            transform.localPosition = new Vector3(-0.2f, 0, 0);
        }
        

        if (PlayerMove.bAttack == true)
        {
            Debug.Log("¿Ã∞≈ªÛº”µ ");
        }
    }
}
