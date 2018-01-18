﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;

    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    private int pickUpsNumber;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        pickUpsNumber = 10;
        SetCountText();
        winText.text = "";
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if(count >= pickUpsNumber)
        {
            winText.text = "You Win!";
        }
    }
}
