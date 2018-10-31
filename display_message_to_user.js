#pragma strict

private var timer : float;
private var displayTime : float;
private var timerIsActive : boolean;
private var message : String;
private var uiText : UI.Text;

function startTimer(){
		timer = 0.0f;
		uiText.text = message;
		timerIsActive = true;
		displayTime = 3.0f;
	}

	function Start(){
		uiText = GetComponent(UI.Text);
	}

	function Update(){
		if (timerIsActive) {
			timer += Time.deltaTime;
			if (timer > displayTime){
				timerIsActive = false;
				uiText.text = "";
			}
		}
	}
	function displayText(mes:String){
		message = mes;
		startTimer ();
	}