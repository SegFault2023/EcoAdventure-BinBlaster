using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class mpItem : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite sprite;

    private bool can_be_picked = false;
    private InventoryManager inventoryManager;
    void destroytrash()
    {
        this.GetComponent<PhotonView>().RPC("destroy", RpcTarget.AllBuffered);
    }
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    void Update()
    {
        if (can_be_picked && Input.GetKeyDown(KeyCode.X))
        {
            Boolean is_added = inventoryManager.AddItem(itemName, sprite, this.tag);

            if (is_added)
            {
                destroytrash();
            }
        }
    }
    [PunRPC]
    public void destroy()
    {
        Destroy(this.gameObject);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            can_be_picked = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            can_be_picked = false;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // You can add more conditions to send specific information if needed.
        if (stream.IsWriting)
        {
            stream.SendNext(can_be_picked);
        }
        else if (stream.IsReading)
        {
            // Update the variable on other clients
            can_be_picked = (bool)stream.ReceiveNext();
        }
    }
}
