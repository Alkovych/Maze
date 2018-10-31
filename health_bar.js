private var currHealth: int = 45;
private var currentColor : Texture2D;
public var style: GUIStyle;
public var textureRed : Texture2D; 
public var textureGreen : Texture2D;
public var textureOrange : Texture2D;
public var textureBlack : Texture2D;

function OnGUI(){
	
	if (currHealth >= 67)
		currentColor = textureGreen;
	else if (currHealth >= 34)
		currentColor = textureOrange;
	else
		currentColor = textureRed;
		
	style.normal.background = textureBlack;
	GUI.Box(Rect(0, 0, 100, 20), "", style);
	style.normal.background = currentColor;
	GUI.Box(Rect(0, 0, currHealth, 20), "", style);
}

public function setHealth(updatedValue : int){
	currHealth = updatedValue;
}

