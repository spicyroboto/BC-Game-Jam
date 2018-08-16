using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToSequence : MonoBehaviour
{
    /// <summary>
    /// Instruction text to be shown during tutorial sequence
    /// </summary>
    public Text instructionText;

    /// <summary>
    /// Next scene to load
    /// </summary>
    /// <remarks>
    /// Set this in the editor
    /// </remarks>
    public string levelToLoad;

    /// <summary>
    /// Reference to player. Used to update tutorial progression
    /// </summary>
    public Transform player;

    /// <summary>
    /// Reference to an item player must pick up. Used to update tutorial progression
    /// </summary>
    public Transform pickup;

    /// <summary>
    /// Reference to player speed/keyboard component
    /// </summary>
    public Movement playerMovement;

    /// <summary>
    /// Arrow to be shown around player object
    /// </summary>
    public GameObject arrowPlayer;

    /// <summary>
    /// Arrow to be shown around pickup object
    /// </summary>
    public GameObject arrowPickUp;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        StartCoroutine("DoTutorial");
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

    }

    /// <summary>
    /// Coroutine that steps the player through the tutorial
    /// </summary>
    IEnumerator DoTutorial()
    {
        playerMovement.MovementActive = false;
        yield return new WaitForSeconds(1);
        yield return AnimateText("Wow, this is a funky dream you're having...");
        yield return new WaitForSeconds(1);
        yield return AnimateText("Where are you anyway?");
        yield return new WaitForSeconds(1);

        // arrow appears after this point

        yield return AnimateText("Wait, is that you over there?");
        arrowPlayer.SetActive(true);
        yield return new WaitForSeconds(2);
        arrowPlayer.SetActive(false);
        yield return AnimateText("Why don't you try moving your mouse?");

        // player now able to move mouse
        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (Vector3.Distance(Input.mousePosition, Camera.current.WorldToScreenPoint(player.position)) < 32.0f)
            {
                break;
            }
        }

        yield return new WaitForSeconds(0.25f);
        yield return AnimateText("Well, aren't you looking a little sleepy?");

        yield return new WaitForSeconds(1);
        yield return AnimateText("Hey, what's that over there?");
        arrowPickUp.SetActive(true);
        yield return new WaitForSeconds(2);
        arrowPickUp.SetActive(false);
        yield return new WaitForSeconds(.25f);
        yield return AnimateText("Why don't you try moving your mouse again?");

        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (Vector3.Distance(Input.mousePosition, Camera.current.WorldToScreenPoint(pickup.position)) < 32.0f)
            {
                break;
            }
        }

        yield return new WaitForSeconds(.25f);
        yield return AnimateText("Ohh, shiny. Let's go check it out.");
        yield return new WaitForSeconds(1);
        yield return AnimateText("Use the arrow keys to move.");
        playerMovement.MovementActive = true;

        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (playerMovement.GetCount() > 0)
            {
                break;
            }
        }

        yield return new WaitForSeconds(1);
        yield return AnimateText("Nice!");
        yield return new WaitForSeconds(.5f);
        yield return AnimateText("Think you can find them all before you wake up?");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(levelToLoad);

    }

    /// <summary>
    /// Makes text appear on screen gradually
    /// </summary>
    /// <param name="strComplete">
    /// The string to animate/show on screen
    /// </param>
    IEnumerator AnimateText(string strComplete)
    {
        int i = 0;
        instructionText.text = "";
        while (i < strComplete.Length)
        {
            instructionText.text += strComplete[i++];
            yield return new WaitForSeconds(0.1f);
        }
    }
}