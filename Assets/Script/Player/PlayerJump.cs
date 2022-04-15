using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    
    public int maxJummpCount = 1;
    [SerializeField]
    private int jumpCount = 0;
    public float jumpPower = 0f;

    protected Transform PlayerTransform = null;
    private Rigidbody2D rigid = null;

    void Start()
    {
        PlayerTransform = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (jumpCount < maxJummpCount && Input.GetKey(KeyCode.Space))
        {

            //playerAudioSource.Play();
            jumpCount++;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        RaycastHit2D raycastHit2D = Physics2D.Raycast(PlayerTransform.position, Vector3.down, 2f, LayerMask.GetMask("Ground"));
        if (raycastHit2D.collider != null && jumpCount >= 1)
        {

            jumpCount = 0;
            //  playerAnimator.SetBool("Jumping", false);
            //  Debug.Log(raycastHit2D.collider.gameObject.name);
        }
        else
        {
            //  playerAnimator.SetBool("Jumping", true);

        }

    }
}
