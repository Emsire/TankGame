using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform targetPlayer;
    private Vector3 pos;

    public float H = 10;

    private void LateUpdate()
    {
        pos.x = targetPlayer.position.x;
        pos.z = targetPlayer.position.z;
        pos.y = H;

        this.transform.position = pos;
    }

}
