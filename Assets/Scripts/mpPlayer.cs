using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
[RequireComponent(typeof(BoxCollider2D))]
public class mpPlayer : MonoBehaviourPunCallbacks, IPunObservable
{


    public PhotonView pv;

    private GameObject sceneCamera;
    public GameObject playerCamera;
    public SpriteRenderer sp;
    private Vector2 smoothMove;
    Animator anim;
    public float speed = 0.5f;
    public Rigidbody2D rb;
    public TextMeshProUGUI nameText;
    public ContactFilter2D movementFilter; // Setting for object to collide
    public float collisionOffset = 0.05f; // Offset
    public List<string> tags = new List<string>();
    private List<RaycastHit2D> castCollision = new List<RaycastHit2D>(); // List the collision block
    private Vector2 lastMovedDirection;
    private Vector2 input;

    private Vector3 inputcontrol;
    private Vector2 inputMP;
    private bool pickFlagmp = false;
    private Vector2 lastMovedDirectionmp;
    private float flipX;

    private bool pickFlag = false;


    private bool can_be_picked = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        if (photonView.IsMine)
        {
            nameText.text = PhotonNetwork.NickName;
            sceneCamera = GameObject.Find("Main Camera");
            sceneCamera.SetActive(false);
            playerCamera.SetActive(true);
        }
        else
        {
            nameText.text = pv.Owner.NickName;
        }

        tags.Add("TrashType1");
        tags.Add("TrashType2");
        tags.Add("TrashType3");
        tags.Add("TrashType4");

    }

    private void Update()
    {

        if (photonView.IsMine)
        {

            ProccessInput();
            Animate(input, lastMovedDirection, pickFlag);
            bool success = MovePlayer(input);
            Flip(input.x);
            if (!success)
            {
                // Left/ Right
                success = MovePlayer(new Vector2(input.x, 0));

                if (!success)
                {
                    success = MovePlayer(new Vector2(0, input.y));
                }
            }
        }
        else
        {
            smoothMovement();

        }


    }


    private void Flip(float x)
    {
        if (x > 0)
        {
            sp.flipX = true;
        }
        else if (x < 0) sp.flipX = false;
    }





    private void ProccessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        pickFlag = anim.GetBool("PickUp");

        Debug.Log(Input.GetKeyDown(KeyCode.X));

        if (Input.GetKeyDown(KeyCode.X) && can_be_picked)
        {
            pickFlag = true;
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            pickFlag = false;
        }



        if ((moveX == 0 && moveY == 0) && (input.x != 0 || input.y != 0))
        {
            lastMovedDirection = input;
        }

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        inputcontrol = input;



    }

    private bool MovePlayer(Vector2 direction)
    {
        int count = rb.Cast(direction, movementFilter, castCollision, speed * Time.fixedDeltaTime + collisionOffset);

        if (count == 0 && anim.GetBool("PickUpExit"))
        {
            // No Collision
            rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * direction);
            return true;
        }
        else
        {
            //Collison
            foreach (RaycastHit2D hit in castCollision)
            {
                Debug.Log(hit.ToString());
            }
            return false;
        }
    }


    private void Animate(Vector2 inputmp, Vector2 lastMovedmp, bool pick)
    {
        anim.SetFloat("MoveX", inputmp.x);
        anim.SetFloat("MoveY", inputmp.y);
        anim.SetFloat("MoveMagnitude", inputmp.magnitude);
        anim.SetFloat("LastMoveX", lastMovedmp.x);
        anim.SetFloat("LastMoveY", lastMovedmp.y);
        anim.SetBool("PickUp", pick);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (string tag in tags)
        {
            if (collision.gameObject.tag == tag)
            {
                can_be_picked = true;
            }
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (string tag in tags)
        {
            if (collision.gameObject.tag == tag)
            {
                can_be_picked = false;
            }
        }
    }

    private void smoothMovement()
    {
        //    private Vector3 inputcontrol;
        // private Vector2 inputMP;
        //private bool pickFlagmp = false;
        // private Vector2 lastMovedDirectionmp;
        transform.position = Vector3.Lerp(transform.position, smoothMove, Time.deltaTime * 10);
        Animate(inputMP, lastMovedDirectionmp, pickFlagmp);
        Flip(inputMP.x);

    }





    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(input);
            stream.SendNext(lastMovedDirection);
            stream.SendNext(pickFlag);

        }
        else if (stream.IsReading)
        {
            smoothMove = (Vector3)stream.ReceiveNext();
            inputMP = (Vector2)stream.ReceiveNext();
            lastMovedDirectionmp = (Vector2)stream.ReceiveNext();
            pickFlagmp = (bool)stream.ReceiveNext();
        }

    }


}
