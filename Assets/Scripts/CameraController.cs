using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float smoothing;
    [Header("Following Object")]
    public Transform player;


    [Header("Range")]
    public Vector2 minPosition;
    public Vector2 maxPosition;


    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != player.position)
        {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}