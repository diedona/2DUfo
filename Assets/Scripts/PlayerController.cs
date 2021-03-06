﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D _rigidBody;
    public float _speed = 6.5f;
    public Text _bottomText;
    public GameObject _pickupsParent1;
    public GameObject _pickupsParent2;

    private Vector2 movement;
    private int points;
    private int picked;
    private bool gameOver;

    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _bottomText = GameObject.Find("PointsText").GetComponent<Text>();
        this.gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.calculateMovement();
    }

    private void FixedUpdate()
    {
        if (!this.gameOver)
        {
            _rigidBody.AddForce(movement, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("ok");
        if (collision.gameObject.CompareTag("PickUp"))
        {
            var gameObject = collision.gameObject;
            var pickup = gameObject.GetComponent<PickupController>();

            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);

            this.points += pickup.Points;
            this.picked++;
            this.updatePointsText();
            this.checkEndGame();
        }
    }

    private void calculateMovement()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal") * Time.deltaTime, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        movement *= _speed;
    }

    private void updatePointsText()
    {
        _bottomText.text = "PONTUAÇÃO: " + this.points.ToString();
    }

    private void checkEndGame()
    {
        var pickups = GameObject.FindGameObjectsWithTag("PickUp");

        if (pickups.Length == 0)
        {
            if (_pickupsParent1.activeInHierarchy)
            {
                _pickupsParent1.SetActive(false);
                _pickupsParent2.SetActive(true);
                this.resetPlayerPosition();
            }
            else
            {
                _pickupsParent2.SetActive(false);
                this.endGame();
            }
        }
    }

    private void endGame()
    {
        this.gameOver = true;
        this.resetPlayerPosition();
        _bottomText.text = "GANHOU! Total: " + this.points.ToString() + " pontos!";
    }

    private void resetPlayerPosition()
    {
        _rigidBody.transform.position = Vector2.zero;
        _rigidBody.velocity = Vector2.zero;
    }
}
