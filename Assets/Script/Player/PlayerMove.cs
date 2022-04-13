using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public static bool bBungi= false;

    public Image Bungi;
    public Sprite Bungi1;
    public Sprite Bungi2;
    public Sprite Bungi3;
    public Sprite Bungi4;

    public static bool bInvin = false;
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
        if (Input.GetKeyDown(KeyCode.T) && Bungi.sprite.name == "Gage4")
        {
            bBungi = true;
        }
        BungiAttack();

        PlayerX = transform.position.x;
        PlayerY = transform.position.y;
    }

    private void BungiAttack()
    { // 1 무적 - 2 일단 스프라이트 넣은게 없으니 돌진공격
        if (bBungi == true)
        {
            if (Bungi.sprite.name == "Gage4")
            {
                bAttack = true;
                bInvin = true;
                playerAnimator.SetBool("DashAttacking", true);
                Debug.Log("분기 공격");

            }
        }

        if (playerSpriteRenderer.sprite.name == "swing6")
        {
            transform.position += new Vector3(0.5f, 0, 0);
        }

        if (playerSpriteRenderer.sprite.name == "swing9")
        {
            playerAnimator.SetBool("DashAttacking", false);
            Bungi.sprite = Bungi1;
            bBungi = false;
            bInvin = false;
            bAttack = false;    
        }
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

                if (Enemy.bDamaged == true)
                {
                    BungiGage();
                }
                bAttack = true;
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

            
            //transform.position = new Vector3(0, 0, 0);
        }


    }

    private void BungiGage()
    {
        
        if (Bungi.sprite.name == "Gage1")
        {
            Bungi.sprite = Bungi2;
        }
        else if (Bungi.sprite.name == "Gage2")
        {
            Bungi.sprite = Bungi3;
        }
        else if (Bungi.sprite.name == "Gage3")
        {
            Bungi.sprite = Bungi4;
        }
    }
}
