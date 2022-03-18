using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public TextMeshProUGUI countKeyText;
    public TextMeshProUGUI countLivesText;

    private Rigidbody rb;

    private float movementX;
    private float movementY;
    private int playerLevel;
    private int countKeys;
    private int countLives;
    public float JumpForce = 10.0f;

    bool isJumpPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        countKeys = 0;
        countLives = 1;
        playerLevel = 1;

        SetCountText();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }
    void SetCountText()
    {
        countKeyText.text = "Nuclear Keys Found: " + countKeys.ToString(); //todo : add to the end here, a / out of /;
    }


private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        
        if (Input.GetKeyDown("space"))//CODE MOD: Adding jumping after so much trial and error. Issue: delayed working?
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            countKeys = countKeys + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("SpeedPill"))
        {
            other.gameObject.SetActive(false);
            speed *= 5;
        }
    }
/*
    public int GetLevel()
    {
        get { return playerLevel};//Code Mod: This getter will allow me to reference this script (I hope) and subsequently use it in that script;
    }
    public int GetKeyCount()
    {
        get { return countKeyText} ; //Code Mod: This getter will allow me to reference this script (I hope) and subsequently use it within that script;
    }*/
}