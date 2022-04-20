using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackR : MonoBehaviour
{
    SpcialAttackMaster SP;
    PlayerM PlayerAttack;
    bool bSpcial = false;
    void Start()
    {
        PlayerAttack = GameObject.Find("Player").GetComponent<PlayerM>();
        SP = GameObject.Find("Rence").GetComponent<SpcialAttackMaster>();
        transform.localScale = new Vector3(0.3f, 0.55f, 1);
    }

    void Update()
    {
        Debug.Log(SP.bBungi);
        if (SP.bBungi == false)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.localPosition = new Vector3(0.3f, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.localPosition = new Vector3(-0.3f, 0, 0);
            }
        }

        if (SP.bBungi == true)
        {
            transform.localScale = new Vector3(1f, 0.55f, 1);
            transform.localPosition = new Vector3(-0.2f, 0, 0);
            bSpcial = true;
            StartCoroutine(DelayRence());Debug.Log("dad");
        }
    }

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Enemy�� �ȿ� ������
        {

            if (PlayerAttack.bAttackSprite6 == true) // Q�� �����ؼ� �ش� ��������Ʈ�� ����
            {
                if (collision.transform.position.x <= PlayerM.PlayerX)
                {
                    collision.transform.position += new Vector3(-2, 0, 0); // �÷��̾� ��ġ�� ���� �ڷ� �з���
                } // <<
                else if (collision.transform.position.x > PlayerM.PlayerX)
                {
                    collision.transform.position += new Vector3(2, 0, 0);// ���߿� Addforce �� �ٲ�ߵ�
                } // >>
            }
            


        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (SP.bBungi == true)
            {
                other.transform.position += new Vector3(0, 3, 0);
            }
    }

    IEnumerator DelayRence()
    {
        SP.bBungi = false;
        yield return new WaitForSeconds(0.3f);
        
        transform.localScale = new Vector3(0.3f, 0.55f, 1);
        bSpcial = false;
    }
}

