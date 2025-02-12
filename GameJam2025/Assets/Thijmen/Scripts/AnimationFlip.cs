using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    bool flipped;
    [SerializeField] private float movementSpeed = 3.0f;
    private Vector2 movement;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        anim.SetFloat("Speed", Mathf.Abs(movement.magnitude * movementSpeed));

        if (movement.x < 0)
        {
            flipped = true;
        }
        else if (movement.x > 0)
        {
            flipped = false;
        }
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));
    }

    private void FixedUpdate()
    {
        if (movement != Vector2.zero)
        {
            var xMovement = movement.x * movementSpeed * Time.deltaTime;
            var yMovement = movement.y * movementSpeed * Time.deltaTime;
            this.transform.Translate(new Vector3(xMovement, yMovement, 0), Space.World);
        }
    }
}
