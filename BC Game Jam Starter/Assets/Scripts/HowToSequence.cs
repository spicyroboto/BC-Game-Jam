using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToSequence : MonoBehaviour
{

    public Text instructionText;
    public string levelToLoad;
    public Transform player;
    public Transform pickup;
    public Movement playerMovement;
    public GameObject arrowPlayer;
    public GameObject arrowPickUp;

    // Use this for initialization
    void Start()
    {

        StartCoroutine("DoTutorial");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DoTutorial()
    {
        yield return new WaitForSeconds(1);
        yield return AnimateText("Wow, this is a funky dream you're having...");
        yield return new WaitForSeconds(1);
        yield return AnimateText("Where are you anyway?");
        yield return new WaitForSeconds(1);

        //arrow

        yield return AnimateText("Wait, is that you over there?");
        arrowPlayer.SetActive(true);
        yield return new WaitForSeconds(2);
        arrowPlayer.SetActive(false);
        yield return AnimateText("Why don't you try moving your mouse?");


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