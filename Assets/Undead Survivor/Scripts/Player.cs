using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector3 inputVec;
    public float speed; 
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Animator animator;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>(); 
        animator = GetComponent<Animator>();
    }
    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
        if (inputVec.x != 0f)
        {
            sprite.flipX = (inputVec.x < 0);
        }
    }
    void LateUpdate()
    {
        animator.SetFloat("Speed", inputVec.magnitude);    
    }

    void FixedUpdate()
    {
        Vector2 moveVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec);
    }
}
