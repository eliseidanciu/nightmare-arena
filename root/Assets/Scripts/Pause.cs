using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public bool gameIsPaused = false;
    public GameObject pauseMenu;
    private object otherObject;
    AudioSource audioSource;


    void Start () {
        // audioSource = GameObject.Find("Player").GetComponent<AudioSource>();
        otherObject = GameObject.Find("CameraHolder").GetComponent<CameraController>(); 
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if(gameIsPaused)
            {
                otherObject = GameObject.Find("CameraHolder").GetComponent<CameraController>().enabled = true;
                AudioListener.volume = 1f;
                Resume();
               
            }
        else
        {
                otherObject = GameObject.Find("CameraHolder").GetComponent<CameraController>().enabled=false;
                AudioListener.volume = 0f;
                //audioSource.mute=true;
                MenuStart();

            }
        }

    }


     public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

     public void MenuStart()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    
        
    }


