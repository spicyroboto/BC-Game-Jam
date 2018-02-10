using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;
    public Text countText;

    private Rigidbody2D rb2d;
    private int count;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        SetCountText();
    }

    // Update is called once per frame
    void Update () {

        //Store the current horizontal input in the float moveHorizontal
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement
        Vector2 inputVector = new Vector2(moveHorizontal, moveVertical);
		
        rb2d.velocity = inputVector * speed;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

}
