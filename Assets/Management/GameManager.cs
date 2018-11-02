using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;
    public bool pause = false;
    private float fixedDeltaTime;

	void Start () {
        fixedDeltaTime = Time.fixedDeltaTime;
	}
	
	void Update () {
        if(CrossPlatformInputManager.GetButton("Fire1")){
            recording = false;
        } else{
            recording = true;
        }

        PauseOrResumeGame();

        if (Input.GetKeyDown(KeyCode.P)){
            pause = !pause;
        }
	}

    private void PauseOrResumeGame()
    {
        if(pause){
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;
        }else{
            Time.timeScale = 1;
            Time.fixedDeltaTime = fixedDeltaTime;
        }

    }

    private void OnApplicationPause(bool pause)
    {
        this.pause = pause;
    }
}
