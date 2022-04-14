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
        //        // ���޶� ��ġ�� ���� ������Ʈ�� ��ġ�� �̵���Ű��.
        //        transform.position = folloObject.position;
        //        transform.Translate(Vector3.back * 10);

        // SMOOTH �̵�

        transform.position = Vector2.SmoothDamp(transform.position, folloObject.position, ref velocity, smoothTime);
        transform.Translate(Vector3.back * 10);
    }
}
