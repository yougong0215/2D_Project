using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static bool bAttack = false;
    public static float PlayerX, PlayerY;
    private SpriteRenderer playerSpriteRenderer = null;
    private bool bMove = false;

    public float speed = 0f;
    public float Jumpspeed = 0f;
    private Rigidbody2D rigid = null;
    private Transform PlayerTransform = null;
    public float jumpPower = 0f;

    [SerializeField]
    private int jumpCount = 0;
  //  public UIManager uIManager;

    private Animator playerAnimator = null;

    
    public int maxJummpCount = 2;

    private float amount = 0f;
    // private AudioSource playerAudioSource = null;

   // private bool isGrounded = false;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        PlayerTransform = GetComponent<Transform>(); // 플레이어의 트랜스폼 가져오는것
        rigid = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        //playerAudioSource = GetComponent<AudioSource>();
        // playerAnimator.SetBool("",true);
    }

    void Update()
    {
        DebugRayCast();
        LRMove();
       // IsRun();
        IsGrounded();

        Pering();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            amount = Input.GetAxis("Horizontal");
            PlayerTransform.Translate(Vector2.right * amount * speed * Time.deltaTime);
            Jump();
        }

        PlayerX = transform.position.x;
        PlayerY = transform.position.y;
    }


    private void LRMove()
    {
        if (bMove == false)
        {
            if (Input.GetKey(KeyCode.D))
            {

                PlayerTransform.Translate(Vector2.right * speed * Time.deltaTime);
                if (Input.GetKey(KeyCode.S))
                {
                    playerSpriteRenderer.flipX = false;
                }
                else
                {
                    playerSpriteRenderer.flipX = true;
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("A");
                PlayerTransform.Translate(Vector2.left * speed * Time.deltaTime);
                if (Input.GetKey(KeyCode.S))
                {
                    playerSpriteRenderer.flipX = true;
                    Debug.Log("S");
                }    
                else
                {
                    playerSpriteRenderer.flipX = false;
                }

            }
        }
    }




    private void Jump()
    {


        if (jumpCount < maxJummpCount)
        {

            //playerAudioSource.Play();
            jumpCount++;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }


    }

    private void IsGrounded()
    {
        if(rigid.velocity.y > 0)
        {
            return;
        }
        RaycastHit2D raycastHit2D = Physics2D.Raycast(PlayerTransform.position, Vector3.down, 2, LayerMask.GetMask("Ground"));
        if (raycastHit2D.collider != null)
        {

            jumpCount = 0;
            //  playerAnimator.SetBool("Jumping", false);
            //  Debug.Log(raycastHit2D.collider.gameObject.name);
        }
        else
        {
            //  playerAnimator.SetBool("Jumping", true);

        }

    }


    private void DebugRayCast()
    {
        Debug.DrawRay(PlayerTransform.position, Vector3.down, Color.blue);
    }

    private void Pering()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerAnimator.SetTrigger("Pering");
            Debug.Log("Q");
        }
        

        if(bAttack == false)
        if (playerSpriteRenderer.sprite.name == "Pering4" || playerSpriteRenderer.sprite.name == "Pering5" || playerSpriteRenderer.sprite.name == "Pering6")
        {
                bAttack = true;
                Debug.Log("성공");
                bMove = true;
                
        }
        if (playerSpriteRenderer.sprite.name == "idle")
        {
               bAttack = false;
                bMove = false;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)

    {

        if (collision.gameObject.CompareTag("Enemy"))
        {

            Debug.Log("맞음");
            transform.position = new Vector3(16, 0, 0);
        }


    }


}
