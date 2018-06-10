using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIInstructions : MonoBehaviour {
    public GameObject fireBallTips;
    public GameObject skillTips;

    float durationPerTip;
    float timeLeft;

	void Start ()
    {
        durationPerTip = 5f;
        timeLeft = durationPerTip * 2;
        fireBallTips.SetActive(false);
        skillTips.SetActive(false);
	}
	
	void Update ()
    {

        fireBallTips.SetActive(true);
        timeLeft -= Time.deltaTime;
        if(timeLeft <= durationPerTip)
        {
            fireBallTips.SetActive(false);
            skillTips.SetActive(true);
            if (timeLeft <= 0)
            {
                skillTips.SetActive(false);
            }
        }
        
	}
}
