using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class two_PlayerMovement : MonoBehaviour
{
    [SerializeField] private float mSpeed;

    private Rigidbody2D _body; 

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        transform.Translate(direction * mSpeed);
    }
}
