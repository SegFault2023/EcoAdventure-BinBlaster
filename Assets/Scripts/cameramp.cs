using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class cameramp : MonoBehaviour
{
    [Header("Following Object")]
    public Transform player;
   

    public float smoothing = 0.07f;

    [Header("Range")]
    public Vector2 minPosition;
    public Vector2 maxPosition;

    void Start()
    {

        if (GameObject.Find("City"))
        {
            minPosition = new Vector2(0, -6.4f);
            maxPosition = new Vector2(9, 15);
        }
        else
        {
            minPosition = new Vector2(3, -5.7f);
            maxPosition = new Vector2(7.14f, 16);
        
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position != player.position)
        {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        }

    
    }

    
}
