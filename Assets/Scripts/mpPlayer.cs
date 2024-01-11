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
    private Vector2 inputcontrol;




    private bool facingLeft = true;
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
    }

    private void Update()
    {

        if (photonView.IsMine)
            {

             ProccessInput();
            }
            else
            {
            smoothMovement();
             }


        Animate();
        if (input.x < 0 && !facingLeft || input.x > 0 && facingLeft)
        {
            Flip();
        }
    }


    private void Flip()
    {
        // to face the character right 
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingLeft = !facingLeft;
    }

    private void FixedUpdate()
    {
        bool success = MovePlayer(input);

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


    private void ProccessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        pickFlag = anim.GetBool("PickUp");



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

        input.Normalize();

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


    private void Animate()
    {
        anim.SetFloat("MoveX", input.x);
        anim.SetFloat("MoveY", input.y);
        anim.SetFloat("MoveMagnitude", input.magnitude);
        anim.SetFloat("LastMoveX", lastMovedDirection.x);
        anim.SetFloat("LastMoveY", lastMovedDirection.y);
        anim.SetBool("PickUp", pickFlag);
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

        input = Vector3.Lerp(input, smoothMove, Time.deltaTime * 10);
        
        
    }





    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(inputcontrol);
        }
        else if (stream.IsReading)
        {
            smoothMove = (Vector2) stream.ReceiveNext();
        }
    }


}
