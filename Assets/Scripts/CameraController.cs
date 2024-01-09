using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public float smoothing;
    [Header("Following Object")]
    public Transform player;
<<<<<<< Updated upstream


    [Header("Range")]
    public Vector2 minPosition;
    public Vector2 maxPosition;


    void Start()
    {
        
    }
=======
    [Header("Boundaries")]
    public float boundX = 0.15f;
    public float boundY = 0.05f;
>>>>>>> Stashed changes

    private Tilemap tilemap;
    private BoundsInt bounds;

    void Start()
    {
      
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != player.position)
        {
<<<<<<< Updated upstream
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
=======
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
        print(" jjjjjjjjjjjjj" + (bounds.x + bounds.size.x)+" "+ bounds.x);
        print("yyyyyyyyyyyyyyyyy " + (bounds.y + bounds.size.y) + " " + bounds.y);

        targetPosition.x = Mathf.Clamp(targetPosition.x, bounds.x, bounds.x + bounds.size.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, bounds.y, bounds.y + bounds.size.y);
        print(" current x" + targetPosition.x);
        print("current  y " + targetPosition.y);

        transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
>>>>>>> Stashed changes
    }
}