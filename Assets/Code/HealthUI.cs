using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour {

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

	// Use this for initialization
	void Start () {
        PlayerHealth.healthRemainingEvent += UpdateHeartsShowing;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateHeartsShowing(int health) {
        switch(health) {
        case 3:
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            break;
        case 2:
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
            break;
        case 1:
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
            break;
        case 0:
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
            break;
        }
    }

    private void OnDestroy() {
      PlayerHealth.healthRemainingEvent -= UpdateHeartsShowing;  
    }
}
