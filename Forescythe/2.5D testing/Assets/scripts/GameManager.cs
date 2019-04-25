using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour {
    public static GameManager gm;
    public bool ForescytheChecker;
    //public Transform tf;
    public ForeScythe fs;
    // Use this for initialization
    void Awake () {
        if (gm == null)
        {
            DontDestroyOnLoad(gameObject);
            gm = this;
        }
        else if(gm!=this)
        {
            Destroy(gameObject);
        }
        //grabs the saved position from player prefs and fills my variables with info
    }
	
	// Update is called once per frame
	void Update () {
        ForescytheChecker = fs.foreScytheOn;
        //PlayerPrefs.SetFloat("MyPositionX", transform.position.x);
        //PlayerPrefs.SetFloat("MyPositionY", transform.position.y);
        //PlayerPrefs.SetFloat("MyPositionZ", transform.position.z);
        
        //PlayerPrefs.SetFloat("MyRoationX", transform.eulerAngles.x);
        //PlayerPrefs.SetFloat("MyRotationY", transform.eulerAngles.y);
        //PlayerPrefs.SetFloat("MyRotationZ", transform.eulerAngles.z);
    }



}
