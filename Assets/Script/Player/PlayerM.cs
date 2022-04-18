using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerM : MonoBehaviour
{
    SpcialAttackMaster Sp;
    // �б� ����
    private bool bAttackCoolDown;

    public bool bAttackSprite6 = false;

    public static bool bInvin = false; // ����
    public bool bAttack = false; // ���� Ȱ��ȭ ����
    public static float PlayerX, PlayerY; // �÷��̾� ���� ��ġ

    // �̵�����
    public bool bMove = false; // ������ true�Ǽ� �� ������



    // ������Ʈ
    private Animator playerAnimator = null;
    public SpriteRenderer playerSpriteRenderer = null;
    protected Transform PlayerTransform = null;


    // private AudioSource playerAudioSource = null;

    // private bool isGrounded = false;
    void Start()
    {
        Sp = GameObject.Find("Rence").GetComponent<SpcialAttackMaster>();
        playerAnimator = GetComponent<Animator>();
        PlayerTransform = GetComponent<Transform>(); // �÷��̾��� Ʈ������ �������°�
        playerSpriteRenderer = GetComponent<SpriteRenderer>();

        //playerAudioSource = GetComponent<AudioSource>();
        // playerAnimator.SetBool("",true);
    }

    void Update()
    {
        PJump();
        SpcialAttack();
        Pering();
        PIdle();
        PlayerX = transform.position.x;
        PlayerY = transform.position.y;
    }

    bool jumpClear = false;
    void PJump()
    {
        if (playerSpriteRenderer.sprite.name == "JumpM1" && jumpClear == false)
        {
            StartCoroutine(Jumpiniing());
        }
    }
    IEnumerator Jumpiniing()
    {
        jumpClear = true;
        bMove = true;
        yield return new WaitForSeconds(0.5f);
        bMove = false;
        jumpClear = false;
    }

    void SpcialAttack()
    {
        if (Sp.bBungi == true)
        {
            Debug.Log("�ù��� �б�" + Sp.bBungi);
            playerAnimator.SetTrigger("DashAttacting");
            
            if (playerSpriteRenderer.flipX == false)
            {
                transform.position += new Vector3(-3f, 0, 0);
            }
            if (playerSpriteRenderer.flipX == true)
            {
                transform.position += new Vector3(3f, 0, 0);
            }
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
            bAttackSprite6 = false;
            bMove = false;
        }
        
    }
    private void Pering()
    {

        if (Input.GetKeyDown(KeyCode.Q) && bAttackCoolDown == false)
        {

            playerAnimator.SetTrigger("Pering");
                bAttackCoolDown = true;
            bAttack = true;
            
        }
        
         // �Ʒ��� �Դϴ�
         // �б� ������ ����
        if (playerSpriteRenderer.sprite.name == "Pering6")
        {

            bAttackSprite6 = true;
            bMove = true;
        }
    }

    IEnumerator PeringDelay()
    {
        yield return new WaitForSeconds(1f);
        bAttackCoolDown = false;
        CorutineCoolMaster = false;
    }


    private void DelayRence()
    {
        transform.localScale = new Vector3(0.3f, 0.55f, 1);
    }


}
