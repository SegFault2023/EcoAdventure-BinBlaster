using UnityEngine;
using Photon.Pun;
using UnityEngine.Tilemaps;

public class mpManager : MonoBehaviour
{
    public GameObject playerPrefab;
    [Header("Boundaries")]
    public float boundX = 2.0f;
    public float boundY = 2.0f;
    void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {

        float x = Random.Range(transform.position.x - boundX, transform.position.x + boundX);
        float y = Random.Range(transform.position.y - boundY, transform.position.y + boundY);
        float z = playerPrefab.transform.position.z; // Keep the original z value

        Vector3 spawnPoint = new Vector3(x, y, z);

        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint, playerPrefab.transform.rotation);
    }
    void OnDrawGizmos()
    {
        // Green
        Rect rect = new Rect(transform.position.x - boundX, transform.position.y - boundY, boundX * 2, boundY * 2);
        Gizmos.color = new Color(0.1f, 1.0f, 0.0f);
        DrawRect(rect);
    }

    void DrawRect(Rect rect)
    {
        Gizmos.DrawWireCube(new Vector3(rect.center.x, rect.center.y, 0.01f), new Vector3(rect.size.x, rect.size.y, 0.01f));
    }
}
