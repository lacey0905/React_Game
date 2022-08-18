using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed;

    public void FixedUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, GameManager.cameraTarget.position, cameraSpeed * Time.smoothDeltaTime);
        newPos = new Vector3(newPos.x, Mathf.Clamp(newPos.y, 3f, newPos.y), newPos.z);
        transform.position = newPos;
    }

}
