using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]


public class PlayerMovement : MonoBehaviour
{
    public float pushForce = 3.0f;
    public float rotSpeed = 15.0f;
    public float moveSpeedHor = 6.0f;
    public float jumpSpeed = 15.0f;
    public float gravity = -9.8f;
    public float terminalVelocity = -10.0f;
    public float onGroundFall = -1.5f;
    private float _vertSpeed=-1.5f;
    private CharacterController _charactercontroller;
    private Vector3 playerMovement = Vector3.zero;
    private Vector3 rotate = Vector3.zero;
    private bool onGround = false;
    private RaycastHit hit;
    [SerializeField] private Transform playerCamera;
    private ControllerColliderHit colliderOnGround;
    private float verInput;
    private float horInput;
    private float rangeForFloor;
    private Vector3 prevPlayerPosition;
    private Vector3 cameraMovement;
    private void Start()
    {
        _charactercontroller = GetComponent<CharacterController>();
        prevPlayerPosition = this.transform.position;


    }
    void Update()
    {
        

        horInput = Input.GetAxis("Horizontal");
        verInput = Input.GetAxis("Vertical");
        if (horInput != 0 || verInput != 0)
        {
            playerMovement = MoveRealativeToTargetHor(playerMovement, playerCamera);
            Quaternion direction = Quaternion.LookRotation(playerMovement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);
        }
/*     if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float rangeForFloor = (_charactercontroller.height + _charactercontroller.radius) / 3;
            onGround = hit.distance<rangeForFloor;
        }
        if (onGround)
        {
            if (Input.GetButton("Jump"))
            {
                _vertSpeed = jumpSpeed;
            }
            else
            {
                _vertSpeed = onGroundFall;
            }

        }
        else
        {
            _vertSpeed += gravity * 5 * Time.deltaTime;
            if (_vertSpeed < terminalVelocity)
            {
                _vertSpeed = terminalVelocity;
            }
            if (colliderOnGround != null)
            {

            }
            if (_charactercontroller.isGrounded)
            {
                if (Vector3.Dot(playerMovement, colliderOnGround.normal) < 0)
                {
                    playerMovement = colliderOnGround.normal * moveSpeedHor;
                }
                else
                {
                    playerMovement += colliderOnGround.normal * moveSpeedHor;
                }
            }
        }*/
        playerMovement.y = _vertSpeed;
        playerMovement *= Time.deltaTime;
        _charactercontroller.Move(playerMovement);
        cameraMovement = this.transform.position - prevPlayerPosition;
        prevPlayerPosition = this.transform.position;
        playerCamera.transform.Translate(cameraMovement,Space.World);

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        colliderOnGround = hit;

        Rigidbody body = hit.collider.attachedRigidbody;
        if (body != null && body.isKinematic)
        {
            body.velocity = hit.moveDirection * pushForce;
        }
    }
    public Vector3 MoveRealativeToTargetHor(Vector3 moveRealativeTo, Transform target)
    {
        moveRealativeTo.x = horInput * moveSpeedHor;
        moveRealativeTo.z = verInput * moveSpeedHor;
        moveRealativeTo.y = 0; 
        moveRealativeTo = Vector3.ClampMagnitude(moveRealativeTo, moveSpeedHor);
        return moveRealativeTo;
    }

}
