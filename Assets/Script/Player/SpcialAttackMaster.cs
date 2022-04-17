using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpcialAttackMaster : MonoBehaviour
{
    public bool bBungi = false;
    public Image Bungi;
    public Sprite Bungi1;
    public Sprite Bungi2;
    public Sprite Bungi3;
    public Sprite Bungi4;

    PlayerM PlayerAttack;
    int RandomGage;
    public SpriteRenderer playerSpriteRenderer = null;

    private Animator playerAnimator = null;
    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        PlayerAttack = GameObject.Find("Player").GetComponent<PlayerM>();
        playerSpriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        RandomGage = UnityEngine.Random.Range(0, 10);

    }

    bool GageCool = false;

    private void Update()
    {
        if (Bungi.sprite.name == "Gage4" && Input.GetKey(KeyCode.T))
        {
            Bungi.sprite = Bungi1;
            bBungi = true;
            Debug.Log(bBungi + " 분기 스어마");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {



     //   if (collision.gameObject.CompareTag("Enemy") && PlayerAttack.bAttackSprite6 == true)
        {
            if (GageCool == false && collision.gameObject.CompareTag("Enemy") && PlayerAttack.bAttackSprite6 ==true)
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
                StartCoroutine(GageUpDelay());
            }
        }



    }




    IEnumerator GageUpDelay()
    {
        GageCool = true;
        yield return new WaitForSeconds(1f);
        GageCool = false;
    }
    /*




if (playerSpriteRenderer.sprite.name == "swing9")
{
    playerAnimator.SetBool("DashAttacking", false);
    bBungi = false;
    bInvin = false;
    bAttack = false;
}
    }
*/
}
