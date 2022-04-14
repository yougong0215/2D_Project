using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    // 분기 모음
    public static bool bBungi= false;
    public Image Bungi;
    public Sprite Bungi1;
    public Sprite Bungi2;
    public Sprite Bungi3;
    public Sprite Bungi4;
    private bool bAttackCoolDown;


    public static bool bInvin = false; // 무적
    public static bool bAttack = false; // 공격 활성화 유무
    public static float PlayerX, PlayerY; // 플레이어 실제 위치
    
    // 이동관련
    private bool bMove = false; // 공격중 true되서 못 움직임
    public float speed = 0f; 
    public float jumpPower = 0f;
    public int maxJummpCount = 1;
    [SerializeField]
    private int jumpCount = 0;
    private float amount = 0f;


    // 컴포넌트
    private Animator playerAnimator = null;
    private SpriteRenderer playerSpriteRenderer = null;
    private Rigidbody2D rigid = null;
    private Transform PlayerTransform = null;


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
        LRMove();
       // IsRun();
       

        Pering();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            amount = Input.GetAxis("Horizontal");
            PlayerTransform.Translate(Vector2.right * amount * speed * Time.deltaTime);
            Jump();
        }
        IsGrounded();

        if (Input.GetKeyDown(KeyCode.T) && Bungi.sprite.name == "Gage4")
        {
            bBungi = true;
        }
        BungiAttack();
        PIdle();
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
                PlayerTransform.Translate(Vector2.left * speed * Time.deltaTime);
                if (Input.GetKey(KeyCode.S))
                {
                    playerSpriteRenderer.flipX = true;
                    
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
        RaycastHit2D raycastHit2D = Physics2D.Raycast(PlayerTransform.position, Vector3.down, 2f, LayerMask.GetMask("Ground"));
        if (raycastHit2D.collider != null && jumpCount >= 1)
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

    bool CorutineCoolMaster = false;
    private void PIdle()
    {
        if (bAttackCoolDown == true && playerSpriteRenderer.sprite.name == "idle")
        {
            if (CorutineCoolMaster == false)
            {
                CorutineCoolMaster = true;
                StartCoroutine(PeringDelay());
            }
        }
        if(playerSpriteRenderer.sprite.name == "idle")
        {
            bAttack = false;
            bMove = false;
        }
        
    }
    private void Pering()
    {

        if (Input.GetKeyDown(KeyCode.Q) && bAttackCoolDown == false)
        {
            
            
                playerAnimator.SetTrigger("Pering");
                bAttackCoolDown = true;
            
        }
        

         // 분기 게이지 충전
        if (bAttack == false && playerSpriteRenderer.sprite.name == "Pering6")
        {

                bAttack = true;
                bMove = true;

                if (Enemy.bDamaged == true)
                {
                    BungiGage();
                }
                
        }
    }

    IEnumerator PeringDelay()
    {
        yield return new WaitForSeconds(1f);
        bAttackCoolDown = false;
        CorutineCoolMaster = false;
    }

    private void BungiAttack()
    { // 1 무적 - 2 일단 스프라이트 넣은게 없으니 돌진공격
        
            if (bBungi == true && Bungi.sprite.name == "Gage4")
            {
            Bungi.sprite = Bungi1;
            bAttack = true;
                bInvin = true;
                playerAnimator.SetBool("DashAttacking", true);
                Debug.Log("분기 공격");

            }
        

        if (playerSpriteRenderer.sprite.name == "swing6")
        {
            if (playerSpriteRenderer.flipX == false)
            {
                transform.position += new Vector3(-1f, 0, 0);
            }
            if (playerSpriteRenderer.flipX == true)
            {
                transform.position += new Vector3(1f, 0, 0);
            }
        }

        if (playerSpriteRenderer.sprite.name == "swing9")
        {
            playerAnimator.SetBool("DashAttacking", false);
            bBungi = false;
            bInvin = false;
            bAttack = false;
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
