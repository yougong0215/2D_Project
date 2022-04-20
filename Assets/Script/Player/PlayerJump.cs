using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Sprite WaitJump;

    public int maxJummpCount = 1;
    [SerializeField]
    private int jumpCount = 0;
    public float jumpPower = 0f;
    private bool jumpct;

    // ÄÄÆ÷³ÍÆ®
    PlayerM PlayerJumpi;
    private Animator playerAnimator = null;
    protected Transform PlayerTransform = null;
    private Rigidbody2D rigid = null;
    private SpriteRenderer playerSpriteRenderer = null;

    void Start()
    {
        PlayerJumpi = GameObject.Find("Player").GetComponent<PlayerM>();
        PlayerTransform = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }


    bool EndJumpCLear = false;
    // Update is called once per frame
    void Update()
    {
        if (jumpCount < maxJummpCount && Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetTrigger("StartJumping");
            StartCoroutine(JumpSans());
        }

        RaycastHit2D raycastHit2D = Physics2D.Raycast(PlayerTransform.position, Vector3.down, 2f, LayerMask.GetMask("Ground"));
        if (raycastHit2D.collider != null && jumpCount >= 1)
        {
            StartCoroutine(JumpClear());
        }
        if (jumpCount >= 1)
        {
            if (rigid.velocity.y > 2)
            {
                playerAnimator.SetFloat("velocityY", 3f);
            }
            else if (rigid.velocity.y <= 2 && rigid.velocity.y >= -2)
            {
                playerAnimator.SetFloat("velocityY", 0);
            }
            else if (rigid.velocity.y < -2)
            {
                playerAnimator.SetFloat("velocityY", -3);
                
            }

            if(rigid.velocity.y < -0.5f)
            {
                EndJumpCLear = true;
            }
        }

        if (EndJumpCLear == true)
        {
            if (rigid.velocity.y == 0 && jumpCount >= 1)
            {
                playerAnimator.SetTrigger("EndJump");
                EndJumpCLear = false;
                jumpCount = 0;
            }
            
            
        }
        
    }

    IEnumerator JumpClear()
    {
        yield return new WaitForSeconds(1f);
        {
            jumpct = false;
        }
    }


    IEnumerator JumpSans()
    {
        jumpct = true;
        jumpCount++;
        yield return new WaitForSeconds(0.5f);

        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }
}
