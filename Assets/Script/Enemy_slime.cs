using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_slime : Enemy
{
    private float Timer = 0;
    private Animator SlimeAnimator = null;
    
    private SpriteRenderer EnemySpriteRenderer = null;
    // Start is called before the first frame update
    void Start()
    {
        SlimeAnimator = GetComponent<Animator>();
        EnemySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyChacer();

    }

    protected override void EnemyChacer()
    {
        float PX = Mathf.Abs(PlayerMove.PlayerX);
        float PY = Mathf.Abs(PlayerMove.PlayerY);
        float EX = Mathf.Abs(transform.position.x);
        float EY = Mathf.Abs(transform.position.y);

        if (Mathf.Abs(PX - EX) <= 6 && Mathf.Abs(PY - EY) <= 6)
        {

            Debug.Log("X : " + PlayerMove.PlayerX);
            Debug.Log("E : " + transform.position.x);
            if (transform.position.x <= PlayerMove.PlayerX)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            } // <<
            if (transform.position.x > PlayerMove.PlayerX)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            } // >>

            if (PX - EX <= 2 && EX - PX <= 2 && PY - EY <= 2 && EY - PY <= 2
               && bAttackLock == false)
            {
                bAttackLock = true;
                Attacking();
            }
        }
    }

    private void Attacking()
    {
        SlimeAnimator.SetTrigger("Attack");
        if (EnemySpriteRenderer.sprite.name == "slime3")
        {
            bAttack = true;
        }

        
        if (EnemySpriteRenderer.sprite.name == "slime_idle")
        {
            Timer += Time.deltaTime;
            if(Timer > 1)
            bAttack = false;
        }

    }




}
