using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    PlayerM PlayerFliping;
    private SpriteRenderer playerSpriteRenderer = null;
    // Start is called before the first frame update
    void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        PlayerFliping = GetComponent<PlayerM>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerFliping.bMove == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                playerSpriteRenderer.flipX = false;
            }
            if (Input.GetKey(KeyCode.D))
            {
                playerSpriteRenderer.flipX = true;
            }
        }
    }
}
