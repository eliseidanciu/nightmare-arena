using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCredits : MonoBehaviour {

	void Update () {
        if ((Input.anyKeyDown))
        {
            Application.LoadLevel("MainMenu");
        }
    }
}
