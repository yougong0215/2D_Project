using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackR : MonoBehaviour
{
    void Start()
    {
        
        transform.localScale = new Vector3(0.3f, 0.8f, 1);
    }

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
        //&& playerSpriteRenderer.sprite.name == "Pering6"
        if(collision.gameObject.CompareTag("Enemy") )
        {
            if (collision.transform.position.x <= PlayerM.PlayerX)
            {
                collision.transform.position += new Vector3(-2, 0, 0);
            } // <<
            else if (collision.transform.position.x > PlayerM.PlayerX)
            {
                collision.transform.position += new Vector3(2, 0, 0);
            } // >>
        }

    }

    private void DelayRence()
    {
        transform.localScale = new Vector3(0.3f, 0.8f, 1);
    }
}
