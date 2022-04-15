using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float speed = 5;

    public bool bMove;

    PlayerM PlayerMbMove;

    // Start is called before the first frame update
    protected Transform PlayerTransform = null;
    void Start()
    {
        PlayerTransform = GetComponent<Transform>();
        PlayerMbMove = GameObject.Find("Player").GetComponent<PlayerM>();
    }

    // Update is called once per frame
    void Update()
    {
        bMove = PlayerMbMove.bMove;
        Debug.Log(bMove + " ÀÚ½Ä");
        if (bMove == false)
        {
            if (Input.GetKey(KeyCode.D))
            {

                PlayerTransform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                PlayerTransform.Translate(Vector2.left * speed * Time.deltaTime);
          

            }

            /////////////////////////////////////////////////////////////////////

        }


    }
}
