using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackR : PlayerMove
{

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0.3f, 0.8f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition = new Vector3(0.3f, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {

            transform.localPosition = new Vector3(-0.3f, 0, 0);
        }


    }

    private void OnTriggerStay2D(Collider2D collision)

    {
        

        if (collision.gameObject.CompareTag("Enemy") && PlayerMove.bAttack == true && PlayerMove.bBungi == false)
        {
            Enemy.bDamaged = true;
            
            if (collision.transform.position.x <= PlayerMove.PlayerX)
            {
                collision.transform.position += new Vector3(-2, 0, 0);
            } // <<
            else if (collision.transform.position.x > PlayerMove.PlayerX)
            {
                collision.transform.position += new Vector3(2, 0, 0);
            } // >>
            
        }
        if (PlayerMove.bAttack == true && PlayerMove.bBungi == true)
        {
            transform.localScale = new Vector3(2f, 0.8f, 1);
            transform.localPosition = new Vector3(0, 0, 0);
            if (collision.gameObject.CompareTag("Enemy"))
            {
                
                Invoke("DelayRence", 1f);
                Enemy.bDamaged = true;
                
                collision.transform.position += new Vector3(0, 3, 0);
            }
        }
    }

    private void DelayRence()
    {
        Debug.Log("너가 멍청한거야 ㅋㅋ");
        transform.localScale = new Vector3(0.3f, 0.8f, 1);
    }
}
