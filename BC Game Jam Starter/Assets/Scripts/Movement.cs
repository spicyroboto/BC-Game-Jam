using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    /// <summary>
    /// Current game score
    /// </summary>
    public static int totalScore;

    /// <summary>
    /// Player speed
    /// </summary>
    public float speed;

    /// <summary>
    /// Converted count into text
    /// </summary>
    public Text countText;

    /// <summary>
    /// Next scene to load
    /// </summary>
    /// <remarks>
    /// Set this in the editor
    /// </remarks>
    public string levelToLoad;

    /// <summary>
    /// Bool that determines whether player can move or not
    /// </summary>
    public bool MovementActive;

    private Rigidbody2D rb2d;

    /// <summary>
    /// Count of objects found
    /// </summary>
    private int count;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        SetCountText();
        MovementActive = true;
    }

    // Update is called once per frame
    void Update () {

        ApplyPlayerMovement();

     }

    /// <summary>
    /// Handles object collision for pickup items and updates score accordingly
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive(false);
            GetComponent<AudioSource>().Play();
            count = count + 1;
            totalScore = count;
            SetCountText();
        }
    }

    /// <summary>
    /// Changes player velocity based on the keyboard/controller input
    /// </summary>
    void ApplyPlayerMovement()
    {
        float moveHorizontal = 0;
        float moveVertical = 0;
        if (MovementActive)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }
        //Use the two store floats to create a new Vector2 variable movement
        Vector2 inputVector = new Vector2(moveHorizontal, moveVertical);

        rb2d.velocity = inputVector * speed;

        GetComponent<Animator>().SetBool("IsMoving", inputVector.magnitude > 0.01);
    }

    /// <summary>
    /// Sets the current count text of pick up objects found
    /// </summary>
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 5)
        {
            totalScore = count;
            SceneManager.LoadScene(levelToLoad);
        }
    }

    public int GetCount()
    {
        return count;
    }
}
