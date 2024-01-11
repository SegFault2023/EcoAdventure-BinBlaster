using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class cameramp : MonoBehaviour
{
    [Header("Following Object")]
    public Transform player;
    [Header("Boundaries")]
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    private Tilemap tilemap;
    private BoundsInt bounds;

    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        float deltaX = player.position.x - transform.position.x;

        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < player.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        float deltaY = player.position.y - transform.position.y;

        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < player.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        // Add clamping based on Tilemap bounds
        tilemap = FindObjectOfType<Tilemap>();
        tilemap.CompressBounds();

        bounds = tilemap.cellBounds;

        Vector3 targetPosition = transform.position + delta;
     
        targetPosition.x = Mathf.Clamp(targetPosition.x, bounds.x, bounds.x + bounds.size.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, bounds.y, bounds.y + bounds.size.y);
     
        transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
    }
}
