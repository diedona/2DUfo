using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D _rigidBody;
    public float _speed = 6.5f;

    private Vector2 movement;    

    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.calculateMovement();
    }

    private void calculateMovement()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal") * Time.deltaTime, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        movement *= _speed;
    }

    private void FixedUpdate()
    {
        _rigidBody.AddForce(movement, ForceMode2D.Impulse);
    }
}
