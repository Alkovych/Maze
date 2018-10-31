using UnityEngine;
using System.Collections;
public class PlayerControllerHelper : MonoBehaviour
{
    public GameObject player;
    public int speedRotation = 3;
    public int speed = 5;
    public AnimationClip anima;
    public int jumpSpeed = 50;
    public NetworkView nView;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        player = (GameObject)this.gameObject;
        nView = GetComponent<NetworkView>();
    }
    void Update()
    {
        if (nView.isMine)
        {
            CharacterController controller = GetComponent<CharacterController>();
            if (controller.isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                if (Input.GetButton("Jump"))
                    moveDirection.y = jumpSpeed;

            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
    }
}
