using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool PlayerCh;
    private Vector2 PlayerRence;
    
    void Start()
    {
        
    }


    void Update()
    {

        EnemyChacer();
    }

    private void EnemyChacer()
    {
        float PX = Mathf.Abs(PlayerMove.PlayerX);
        float PY = Mathf.Abs(PlayerMove.PlayerY);
        float EX = Mathf.Abs(transform.position.x);
        float EY = Mathf.Abs(transform.position.y);

        if (PX - EX <= 6 && EX - PX <= 6 && PY - EY <= 6 && EY - PY <= 6)
        {
            Debug.Log("종합감지");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    
    {

        if(collision.gameObject.CompareTag("AttackMaster") && PlayerMove.bAttack == true)
        {
            
            
                Debug.Log("아야");
            transform.position = new Vector3(0, 0, 0);
        }


    }
}
