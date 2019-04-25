using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.AI;
public class ForeScythe : MonoBehaviour {
    //how many second ForeScythe is active for
    public int ForeScythetime;
    private NavMeshAgent agent;
    // player's transform
    public Transform tf;
    [HideInInspector]
    //bool that turns on and off the AI controls
    public bool foreScytheOn;
    //position
    private float ThisCharacterXPosition;
    private float ThisCharacterYPosition;
    private float ThisCharacterZPosition;
    //rotation
    private float ThisCharacterXRotation;
    private float ThisCharacterYRotation;
    private float ThisCharacterZRotation;
    void Start () {
        tf = GetComponent<Transform>();
        foreScytheOn = false;
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        
    }
    // The save function where the player's position is saved when ForeScythe is activated and also activates a bool to tell the AI to take over
    public void Save()
    {
        Debug.Log("saving");
        // saves the position as float in player prefs for each x,y,z value
        PlayerPrefs.SetFloat("MyPositionX", transform.position.x);
        PlayerPrefs.SetFloat("MyPositionY", transform.position.y);
        PlayerPrefs.SetFloat("MyPositionZ", transform.position.z);

        PlayerPrefs.SetFloat("MyRotationX", transform.eulerAngles.x);
        PlayerPrefs.SetFloat("MyRotationY", transform.eulerAngles.y);
        PlayerPrefs.SetFloat("MyRotationZ", transform.eulerAngles.z);
        // sets the local float variables equal to the saved floats 
        ThisCharacterXPosition = PlayerPrefs.GetFloat("MyPositionX");
        ThisCharacterYPosition = PlayerPrefs.GetFloat("MyPositionY");
        ThisCharacterZPosition = PlayerPrefs.GetFloat("MyPositionZ");

        ThisCharacterXRotation = PlayerPrefs.GetFloat("MyRotationX");
        ThisCharacterYRotation = PlayerPrefs.GetFloat("MyRotationY");
        ThisCharacterZRotation = PlayerPrefs.GetFloat("MyRotationZ");
        //turns on AI control
        foreScytheOn = true;
    }
    //loads the player's position after ForeScythe has run it's course
    public void Load()
    {
        Debug.Log("loading");
        //turns AI control off
        foreScytheOn = false;
        agent.isStopped = true;
        // grabs the poisitions from earlier that were stored and makes them the current position
        tf.position = new Vector3(ThisCharacterXPosition, ThisCharacterYPosition, ThisCharacterZPosition);
        tf.rotation = Quaternion.Euler(0, 0, 0);


    }
    // The Forescythe coroutine that has both the save and load functions
    IEnumerator Forescythe()
    {
        Save();
        //continues the ForeScthe actions for the alloted amount of seconds
        yield return new WaitForSecondsRealtime(ForeScythetime);
        Load();
    }

    //  public void Forescythe()
    //  {
    //      Save();
    //     Debug.Log("saving");
    // Load();
    // }

}
