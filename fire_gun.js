public var nbBullets: int;
private var ui_bullets;
function Update(){

	if(Input.GetButtonDown("Fire1")){
		if (nbBullets > 0){
		var hit : RaycastHit;
		var ray = Camera.main.ScreenPointToRay (Vector3(Screen.width/2, Screen.height/2));
		
		if (Physics.Raycast (ray, hit, 100)){
			print("You fired at the " +hit.collider.gameObject.tag);
		}
		nbBullets--;
		print ("You have " + nbBullets + " bullets");
	}
}
}

function Start(){
	Cursor.visible = false;
	ui_bullets = GameObject.Find("UI_bullets").GetComponent(UI.Text);
	ui_bullets.text = getTextForUIBullet(GameObject.
	Find("UI_texture_crosshair").GetComponent(fire_gun).nbBullets);
	GameObject.Find("UI_texture_crosshair").GetComponent(UI.RawImage).
	enabled=false;
	
}

function getTextForUIBullet(nbBullets: int){
	return "Bullets: " + nbBullets;
}