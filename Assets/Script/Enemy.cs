using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [RequireComponent(typeof(SpriteRenderer))] 하위에 꼭 붙힐것
/// </summary>


public class Enemy : MonoBehaviour
{

    void Start()
    {
    }


    void Update()
    {

        EnemyChacer();
    }

    protected virtual void EnemyChacer()
    {
        float PX = Mathf.Abs(PlayerMove.PlayerX);
        float PY = Mathf.Abs(PlayerMove.PlayerY);
        float EX = Mathf.Abs(transform.position.x);
        float EY = Mathf.Abs(transform.position.y);

        if (PX - EX <= 6 && EX - PX <= 6 && PY - EY <= 6 && EY - PY <= 6)
        {
            Debug.Log("종합감지");
            if(PX - EX <= 6)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            } // <<
            if(PX - EX > 6)
            {
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

        if(collision.gameObject.CompareTag("AttackMaster") && PlayerMove.bAttack == true)
        {
            
                Debug.Log("아야");
            transform.position = new Vector3(0, 0, 0);
        }


    }
}
