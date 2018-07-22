using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopSceneDialog : MonoBehaviour {

    public Text text;
    private List<string> displayStrings;
    private int currDisplayIndex;

    private float letterTimer;
    public float letterTimeLimit;
    private int currentLetter;

	// Use this for initialization
	void Start () {
        currDisplayIndex = 0;
        currentLetter = 0;
        //I'm just gonna intialize the text here cause that's easier, this can be done better
        displayStrings = new List<string>();
        displayStrings.Add("Hi My Name is Goku");
        displayStrings.Add("Going after the town Bandit Vegeta?");
        displayStrings.Add("You need a better gun. Bring me parts. I can make it");
        text.text = "";
		
	}
	
	// Update is called once per frame
	void Update () {
		if(currentLetter < displayStrings[currDisplayIndex].Length) {
            letterTimer += Time.deltaTime;
            if(letterTimer >= letterTimeLimit) {
                currentLetter++;
                letterTimer = 0.0f;
                text.text = displayStrings[currDisplayIndex].Substring(0, currentLetter);
            }
            //If they press the fire key skip to the end
            if(Input.GetButtonDown("Fire1")) {
                currentLetter = displayStrings[currDisplayIndex].Length;
                text.text = displayStrings[currDisplayIndex].Substring(0, currentLetter);
            }
        }
        else {
            if(Input.GetButtonDown("Fire1")) {
                currentLetter = 0;
                currDisplayIndex++;
                if(currDisplayIndex < displayStrings.Count) {
                    letterTimer = 0.0f;
                    text.text = displayStrings[currDisplayIndex].Substring(0, currentLetter);
                }
                else {
                    SceneManager.LoadScene(1);
                }
            }
        }
	}
}
