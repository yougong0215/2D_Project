using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMOve : MonoBehaviour
{
    public Transform folloObject = null;
    public Vector2 velocity = Vector2.zero;
    public float smoothTime = 0f;

    // Update is called once per frame
    void Update()
    {
        //        // ㅋ메라 위치를 따라갈 오브잭트의 위치로 이동시키낟.
        //        transform.position = folloObject.position;
        //        transform.Translate(Vector3.back * 10);

        // SMOOTH 이동

        transform.position = Vector2.SmoothDamp(transform.position, folloObject.position, ref velocity, smoothTime);
        transform.Translate(Vector3.back * 10);
    }
}
