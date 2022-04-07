using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_slime : Enemy
{

    float a = 0;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        EnemyChacer();
        
        a = Time.deltaTime;
    }

    protected override void EnemyChacer()
    {
        float PX = Mathf.Abs(PlayerMove.PlayerX);
        float PY = Mathf.Abs(PlayerMove.PlayerY);
        float EX = Mathf.Abs(transform.position.x);
        float EY = Mathf.Abs(transform.position.y);
        
        if (Mathf.Abs(PX - EX)<= 6 && Mathf.Abs(PY - EY) <= 6)
        {
            
            Debug.Log("종합감지");
            if (transform.rotation.x < PlayerMove.PlayerX)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            } // <<
            if (transform.rotation.x > PlayerMove.PlayerX)
            {Debug.Log("와 : " + a);
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            } // >>

            if (PX - EX <= 2 && EX - PX <= 2 && PY - EY <= 2 && EY - PY <= 2)
            {
                Debug.Log("정밀감지");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)

    {
        

        if (collision.gameObject.CompareTag("AttackMaster") && PlayerMove.bAttack == true)
        {

            Debug.Log("질퍽");
            transform.position = new Vector3(0, 0, 0);
        }


    }
}
