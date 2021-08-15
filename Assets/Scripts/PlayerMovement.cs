// 
// Copyright (c) SunnyMonster
//

using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Options")]
    public float speed = 40f;

    private CharacterController2D controller;
    private float horizontalMove = 0f;
    private float verticalInput = 0f;

    private void Start()
    {
        controller = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, Input.GetButton("Jump") || (GravitySwitch.instance.gravityIsFlipped ? verticalInput < 0 : verticalInput > 0));
    }
}
