using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public static Player2 instance;
    public float MoveSpeed;

    public float jumpForce;

    public float gravityscale = 5f;

    public float bounceForce = 8f;

    private Vector3 moveDirection;

    public CharacterController charController;

    private Camera thecam;

    public GameObject playermodel;

    public float rotateSpeed;

    public Animator anim;


    public bool isKnocking;

    public float knockBackLength = .5f;

    private float knockbackCounter;

    public Vector2 knockbackPower;

    public GameObject[] playerPieces;

    public bool stopMove;



    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        thecam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isKnocking && !stopMove)
        {
            float ystore = moveDirection.y;

            //moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            moveDirection = (transform.forward * Input.GetAxisRaw("Player2 Vertical")) + (transform.right * Input.GetAxisRaw("Player2 Horizontal"));
            moveDirection.Normalize();
            moveDirection = moveDirection * MoveSpeed;
            moveDirection.y = ystore;

            if (charController.isGrounded)
            {
                moveDirection.y = 0f;
                if (Input.GetButtonDown("Jump2"))
                {
                    AudioManager.instance.PlaySFX(10);
                    moveDirection.y = jumpForce;
                }
            }

            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityscale;

            //transform.position = transform.position + (moveDirection * Time.deltaTime * MoveSpeed);

            charController.Move(moveDirection * Time.deltaTime);

            if (Input.GetAxisRaw("Player2 Horizontal") != 0 || Input.GetAxisRaw("Player2 Vertical") != 0)
            {
                transform.rotation = Quaternion.Euler(0f, thecam.transform.rotation.eulerAngles.y, 0f);
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
                //playermodel.transform.rotation = newRotation;
                playermodel.transform.rotation = Quaternion.Slerp(playermodel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);

            }
        }

        if (isKnocking)
        {
            knockbackCounter -= Time.deltaTime;

            float ystore = moveDirection.y;
            moveDirection = playermodel.transform.forward * -knockbackPower.x;
            moveDirection.y = ystore;

            if (charController.isGrounded)
            {
                moveDirection.y = 0f;
            }

            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityscale;

            charController.Move(moveDirection * Time.deltaTime);

            if (knockbackCounter <= 0)
            {
                isKnocking = false;
            }
        }

        if (stopMove)
        {
            moveDirection = Vector3.zero;
            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityscale;
            charController.Move(moveDirection);
        }
        anim.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));
        anim.SetBool("Grounded", charController.isGrounded);
    }

    public void KnockBack()
    {
        isKnocking = true;
        knockbackCounter = knockBackLength;
        Debug.Log("Knocked Back");

        moveDirection.y = knockbackPower.y;

        charController.Move(moveDirection * Time.deltaTime);
    }

    public void Bounce()
    {
        moveDirection.y = bounceForce;
        charController.Move(moveDirection * Time.deltaTime);
    }
}
