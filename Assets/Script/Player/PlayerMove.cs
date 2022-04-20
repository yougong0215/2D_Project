using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float speed = 5;

    PlayerM PlayerMbMove;
    private Animator playerAnimator = null;
    // Start is called before the first frame update
    protected Transform PlayerTransform = null;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        PlayerTransform = GetComponent<Transform>();
        PlayerMbMove = GameObject.Find("Player").GetComponent<PlayerM>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerMbMove.bMove == false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                PlayerTransform.Translate(Vector2.right * speed * Time.deltaTime);
                playerAnimator.SetBool("Dash", true);
            }
            if (Input.GetKey(KeyCode.A))
            {
                PlayerTransform.Translate(Vector2.left * speed * Time.deltaTime);
                playerAnimator.SetBool("Dash", true);
            }

            /////////////////////////////////////////////////////////////////////

        }
        else if(PlayerMbMove.bMove == true)
        {
            playerAnimator.SetBool("Dash", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnimator.SetBool("Dash", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnimator.SetBool("Dash", false);
        }
    }
}
