using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerM
{
    float speed = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = GetComponent<Transform>(); // 플레이어의 트랜스폼 가져오는것

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(base.bMove + " 자식");
        if (base.bMove == false)
        {
            if (Input.GetKey(KeyCode.D))
            {

                PlayerTransform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                PlayerTransform.Translate(Vector2.left * speed * Time.deltaTime);
          

            }
        }
    }
}
