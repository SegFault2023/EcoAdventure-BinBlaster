using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnTrash : MonoBehaviour
{
    public Transform[] trashArray;
    public LayerMask layerList;
    [Header("Boundries")]
    public float boundX = 2.0f;
    public float boundY = 2.0f;

    public float objectCount = 5;
    

    void Start()
    {
        int count = 0;

        
   

        while (count < objectCount)
        {
            int trashChooser = Random.Range(0, trashArray.Length);

            Transform trash = trashArray[trashChooser];

            float xCol = trash.GetComponent<BoxCollider2D>().size.x / 100;
            float yCol = trash.GetComponent<BoxCollider2D>().size.y / 100;

            float x = Random.Range(transform.position.x-boundX, transform.position.x + boundX);
            float y = Random.Range(transform.position.y - boundY, transform.position.y + boundY);
            Vector2 spawnPoint = new Vector2(x, y);

            Vector2 colliderPointA = new Vector2(x - xCol, y - yCol);
            Vector2 colliderPointB = new Vector2(x + xCol, y + yCol);


            Collider2D Collision = Physics2D.OverlapArea(colliderPointA, colliderPointB, layerList);



            if (Collision == false)
            {

                Instantiate(trash, spawnPoint, Quaternion.identity);

                count++;
            }

            if(count == 100)
            {
                break;
            }

        }        
    }
  

    void OnDrawGizmos()
    {
        // Green
        Rect rect = new Rect(transform.position.x - boundX, transform.position.y - boundY, boundX*2, boundY*2);
        Gizmos.color = new Color(0.0f, 1.0f, 0.0f);
        DrawRect(rect);
    }

    void DrawRect(Rect rect)
    {

        Gizmos.DrawWireCube(new Vector3(rect.center.x, rect.center.y, 0.01f), new Vector3(rect.size.x, rect.size.y, 0.01f));
    }


}



