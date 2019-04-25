using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {
    public ForeScythe fs;
    public SpriteRenderer sr;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Changes Color if Forescythe is active
	void Update () {
        if (fs.foreScytheOn == false)
        {
            sr.color = Color.blue;
        }
        else
        {
            sr.color = Color.red;
        }
    }
}
