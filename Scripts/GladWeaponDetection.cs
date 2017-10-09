using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladWeaponDetection : MonoBehaviour {

	public int spearsWithinReach = 0;
	public int gladiusesWithinReach = 0;
	public int macesWithinReach = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Spear") {
			spearsWithinReach++;
		}
		else if (other.tag == "Gladius") {
			gladiusesWithinReach++;
		}
		if (other.tag == "Mace") {
			macesWithinReach++;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Spear") {
			spearsWithinReach--;
		}
		else if (other.tag == "Gladius") {
			gladiusesWithinReach--;
		}
		if (other.tag == "Mace") {
			macesWithinReach--;
		}
	}
}
