using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerM : MonoBehaviour
{
    // �б� ����
    private bool bAttackCoolDown;

    public bool bAttackSprite6 = false;

    public static bool bInvin = false; // ����
    public static bool bAttack = false; // ���� Ȱ��ȭ ����
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
           
        playerAnimator = GetComponent<Animator>();
        PlayerTransform = GetComponent<Transform>(); // �÷��̾��� Ʈ������ �������°�
        playerSpriteRenderer = GetComponent<SpriteRenderer>();

        //playerAudioSource = GetComponent<AudioSource>();
        // playerAnimator.SetBool("",true);
    }

    void Update()
    {
        Pering();
        PIdle();
        PlayerX = transform.position.x;
        PlayerY = transform.position.y;
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

        



}
