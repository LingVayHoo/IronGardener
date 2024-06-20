using System;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Physics")]
    public float SpeedForce = 100;
    public float JumpForce;

    [Header("Positions")]
    [Tooltip("Min X coordinate when the player can moove")]
    public float minXposition;
    [Tooltip("Max X coordinate when the player can moove")]
    public float maxXposition;


    private Rigidbody _rigidbody;
    private Animator _animator;
    private PlayerAnimation playerAnimator;

    private PlayerPositionEnum playerSide;
    private bool isGrounded = true;

    private float x;
    private float NewPosX;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        playerAnimator = new PlayerAnimation(_animator);

        playerSide = PlayerPositionEnum.middle;
    }

    private void FixedUpdate()
    {
        x = Mathf.Lerp(x, NewPosX, SpeedForce * Time.deltaTime);
        transform.Translate((x - transform.position.x) * Vector2.right);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    public void MoveLeft()
    {
        if (playerSide == PlayerPositionEnum.middle)
        {
            NewPosX = maxXposition;
            playerSide = PlayerPositionEnum.left;
        }
        else
            if (playerSide == PlayerPositionEnum.right)
        {
            NewPosX = 0;
            playerSide = PlayerPositionEnum.middle;
        }

    }

    public void MoveRight()
    {
        if (playerSide == PlayerPositionEnum.middle)
        {
            NewPosX = minXposition;
            playerSide = PlayerPositionEnum.right;
        }
        else
            if (playerSide == PlayerPositionEnum.left)
        {
            NewPosX = 0;
            playerSide = PlayerPositionEnum.middle;
        }
    }
    public void GetDown()
    {
        //вниз
        //playerAnimator.ChangeSlidingBool(true);
    }

    public void GetUp()
    {
        //вниз
       // playerAnimator.ChangeSlidingBool(false);
    }

    private void OnTriggerStay(Collider other)
    {
        isGrounded = true;
        //playerAnimator.ChangeJumpAnimBool(isGrounded);

    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
       // playerAnimator.ChangeJumpAnimBool(isGrounded);
    }

}
