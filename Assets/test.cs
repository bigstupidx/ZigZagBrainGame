﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Animator> ().SetBool ("Run", true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
