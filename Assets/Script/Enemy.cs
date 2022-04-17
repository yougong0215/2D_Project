using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [RequireComponent(typeof(SpriteRenderer))] 하위에 꼭 붙힐것
/// </summary>


public class Enemy : MonoBehaviour
{
    protected bool bAttackLock = false;
    public static bool bAttack = false;
    public static bool bDamaged = false;

    void Start()
    {
    }


    void Update()
    {

        EnemyChacer();
    }

    protected virtual void EnemyChacer()
    {
        float PX = Mathf.Abs(PlayerM.PlayerX);
        float PY = Mathf.Abs(PlayerM.PlayerY);
        float EX = Mathf.Abs(transform.position.x);
        float EY = Mathf.Abs(transform.position.y);

        if (PX - EX <= 6 && EX - PX <= 6 && PY - EY <= 6 && EY - PY <= 6)
        {
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
            }
        }

        
    }

    
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttackMaster"))
        {
            bDamaged = true;
            StartCoroutine(DamagedClear());
        }
    }
    
     protected virtual IEnumerator DamagedClear()
    {
        yield return new WaitForSeconds(0.2f);
        bDamaged = false;
    }
}
