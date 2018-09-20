using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healt : MonoBehaviour {

    public Image[] listHealth;

	// Use this for initialization
	void Start () {
		
	}
	
    public void TakeDamage(float contador){

        if(contador.Equals(1)){
            listHealth[2].enabled = false;
        }

        if(contador.Equals(2)){
            listHealth[1].enabled = false;
        }

        if(contador.Equals(3)){
            listHealth[0].enabled = false;
        }

        //listHealth[2].enabled = false;
    }
}
