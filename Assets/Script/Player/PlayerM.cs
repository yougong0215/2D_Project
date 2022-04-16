using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerM : MonoBehaviour
{
    // 분기 모음
    private bool bAttackCoolDown;

    public bool bAttackSprite6 = false;

    public static bool bInvin = false; // 무적
    public static bool bAttack = false; // 공격 활성화 유무
    public static float PlayerX, PlayerY; // 플레이어 실제 위치
    
    // 이동관련
    public bool bMove = false; // 공격중 true되서 못 움직임



    // 컴포넌트
    private Animator playerAnimator = null;
    public SpriteRenderer playerSpriteRenderer = null;
    protected Transform PlayerTransform = null;


    // private AudioSource playerAudioSource = null;

   // private bool isGrounded = false;
    void Start()
    {
           
        playerAnimator = GetComponent<Animator>();
        PlayerTransform = GetComponent<Transform>(); // 플레이어의 트랜스폼 가져오는것
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
        
         // 아랫쪽 입니다
         // 분기 게이지 충전
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
