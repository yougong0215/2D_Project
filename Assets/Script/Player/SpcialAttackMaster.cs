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


    protected SpriteRenderer playerSpriteRenderer = null;
    private void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && playerSpriteRenderer.sprite.name == "Pering6")
        {
            StartCoroutine(GageUpDelay());
        }

        if (Input.GetKeyDown(KeyCode.T) && Bungi.sprite.name == "Gage4")
        {
            bBungi = true;
        }
    }
    IEnumerator GageUpDelay()
    {
        yield return new WaitForSeconds(5f);
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
    /*
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
*/
}
