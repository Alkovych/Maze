using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public Text timer;
	private float minutes = 0;
	private float seconds = 0;
	private float Time_played;

	void Start(){

	}
	
	void Update(){
		timer = GetComponent<Text>();
		Time_played += Time.deltaTime;
		seconds = (Time_played % 60);
		minutes = (Time_played / 60) % 60;
		timer.text = string.Format ("{0:00} : {1:00}", minutes, seconds);
	}

}
