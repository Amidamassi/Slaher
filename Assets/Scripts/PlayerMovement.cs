using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]


public class PlayerMovement : MonoBehaviour
{
    public float rotSpeed = 15.0f;
    public float moveSpeed = 6.0f;
    public float jumpSpeed = 15.0f;
    public float gravity = -9.8f;
    public float terminalVelocity = -10.0f;
    public float onGroundFall = -1.5f;
    private float _vertSpeed=-1.5f;
    private CharacterController _charactercontroller;
    private Vector3 movement = Vector3.zero;
    private Vector3 rotate = Vector3.zero;
    private bool onGround = false;
    private RaycastHit hit;
    [SerializeField] private Transform target;
    private ControllerColliderHit colliderOnGround;
    private float verInput;
    private float horInput;
    private void Start()
    {
        _charactercontroller = GetComponent<CharacterController>();
        
    }
    void Update()
    {
       


        horInput = Input.GetAxis("Horizontal");
        verInput = Input.GetAxis("Vertical");

        if (horInput != 0 || verInput != 0)
        {
            movement.x = horInput * moveSpeed;
            movement.z = verInput * moveSpeed;
            movement.y = 0;
            movement = Vector3.ClampMagnitude(movement, moveSpeed);
            Quaternion tmp = target.rotation;
            movement = target.TransformDirection(movement);
            target.rotation = tmp;
            rotate.x = movement.x;
            rotate.z = movement.z;
            Quaternion direction = Quaternion.LookRotation(rotate);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);
        }
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float chek = (_charactercontroller.height + _charactercontroller.radius) / 2;
            onGround = hit.distance < chek;
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
          //  if (colliderOnGround != null)
         //   {
               
            }
            if (_charactercontroller.isGrounded)
            {
                if (Vector3.Dot(movement, colliderOnGround.normal) < 0)
                {
                    movement = colliderOnGround.normal * moveSpeed;
                }
                else
                {
                    movement += colliderOnGround.normal * moveSpeed;
                }
         //   }
        }
        movement.y = _vertSpeed;
        movement *= Time.deltaTime;
        _charactercontroller.Move(movement);
        target.transform.Translate(movement.x, 0, movement.z ,Space.World);

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        colliderOnGround = hit;
    }
  
}
