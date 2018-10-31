//@script RequireComponent (AudioSource)

#pragma strict
var FPSController : GameObject;
private var hasKey : boolean;
private var hasGun : boolean;
private var health : int;
public var collecting_sound: AudioClip;
private var isLose : boolean;

function OnControllerColliderHit(c : ControllerColliderHit)
{
	if(c.gameObject.tag == "medpack" || c.gameObject.tag == "gun" || c.gameObject.tag == "key" || c.gameObject.tag == "end_key")
	{
		print("collided with " + c.gameObject.tag);
		Destroy(c.gameObject);
		GetComponent(AudioSource).clip = collecting_sound;
		GetComponent(AudioSource).Play();
		
		if (c.gameObject.tag == "medpack"){
			health = 100;
			GameObject.Find("healthBar")
			.GetComponent(health_bar)
			.setHealth(health);
		}
		else if (c.gameObject.tag == "key"){
			hasKey = true;
			changeUITexture("key", hasKey);
			GameObject.Find("UI_displayMessageToUser")
			.GetComponent(display_message_to_user)
			.displayText("Now go to the portal");
		}
		else if (c.gameObject.tag == "end_key"){
			hasKey = true;
			changeUITexture("key", hasKey);
			GameObject.Find("UI_displayMessageToUser")
			.GetComponent(display_message_to_user)
			.displayText("Find the exit");
		}
		else if (c.gameObject.tag == "gun"){
			hasGun = true;
			changeUITexture("gun", hasGun);
		}
	}
	else if (c.gameObject.tag == "exit_door"){
		if (hasKey){
		GameObject.Find("UI_displayMessageToUser")
		.GetComponent(display_message_to_user)
		.displayText("Teleporting");
		Application.LoadLevel("Default 2");
		}
		else{
			GameObject.Find("UI_displayMessageToUser")
			.GetComponent(display_message_to_user)
			.displayText("Find a portal key!");
			}
	}

	else if (c.gameObject.tag == "game_end"){
		if (hasKey){
		GameObject.Find("UI_displayMessageToUser")
		.GetComponent(display_message_to_user)
		.displayText("The End");
		Application.Quit();
		}
		else{
			GameObject.Find("UI_displayMessageToUser")
			.GetComponent(display_message_to_user)
			.displayText("Find an exit key!");
			}
	}
	else if (c.gameObject.tag == "short_way"){
		GameObject.Find("UI_displayMessageToUser")
		.GetComponent(display_message_to_user)
		.displayText("You found a short way!");
		FPSController = GameObject.Find("FPSController");
    	var playerPos:Vector3 = FPSController.transform.position;
    	playerPos.x = 50;
    	playerPos.y = 50;
    	playerPos.z = 50;
	}

}

function changeUITexture(what : String, display : boolean){
	GameObject.Find("UI_texture_" + what)
		.GetComponent(UI.RawImage)
		.enabled
		= display;
}

function Start(){
	hasGun = false;
	hasKey = false;
	health = 0;
	changeUITexture("key", hasKey);
	changeUITexture("gun", hasGun);
}


