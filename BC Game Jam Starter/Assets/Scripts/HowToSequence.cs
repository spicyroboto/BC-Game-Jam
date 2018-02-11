using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToSequence : MonoBehaviour {

    public Text instructionText;
    public string levelToLoad;
    public Transform player;
    public Transform pickup;
    public Movement playerMovement;
    
	// Use this for initialization
	void Start () {

        StartCoroutine("DoTutorial");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator DoTutorial()
    {
        yield return new WaitForSeconds(1);
        instructionText.text = "Wow, this is a funky dream you're having...";
        yield return new WaitForSeconds(3);
        instructionText.text = "Where are you anyway?";
        yield return new WaitForSeconds(2);

        //arrow

        instructionText.text = "Wait, is that you over there? Why don't you try moving your mouse?";

        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (Vector3.Distance(Input.mousePosition, Camera.current.WorldToScreenPoint(player.position)) < 32.0f)
            {
                break;
            }
        }

        yield return new WaitForSeconds(0.25f);
        instructionText.text = "Well, aren't you looking a little sleepy?";

        yield return new WaitForSeconds(3);
        instructionText.text = "Hey, what's that over there?";
        yield return new WaitForSeconds(2);
        instructionText.text = "Why don't you try moving your mouse again?";

        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (Vector3.Distance(Input.mousePosition, Camera.current.WorldToScreenPoint(pickup.position)) < 32.0f)
            {
                break;
            }
        }

        yield return new WaitForSeconds(.25f);
        instructionText.text = "Ohh, shiny. Let's go check it out.";
        yield return new WaitForSeconds(2.5f);
        instructionText.text = "Use the arrow keys to move.";

        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (playerMovement.GetCount() > 0)
            {
                break;
            }
        }

        yield return new WaitForSeconds(1);
        instructionText.text = "Nice!";
        yield return new WaitForSeconds(1.5f);
        instructionText.text = "Think you can find them all before you wake up?";
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(levelToLoad);

    }


    // Hey, what's that over there? 
    // Why don't you try moving your mouse over there?

    // Function to make arrow blink over pickup

    // Some crap that checks if mouse is over treasure or not

    // if mouse is over treasure, text: Great! Now come pick this up

    // Some crap that checks that the piece is picked up

    // if picked up, text: Alright, now can you find them all before you wake up?

    // LoadNextScene - Regular Gameplay
}
