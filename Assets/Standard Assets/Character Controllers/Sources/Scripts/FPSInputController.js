private var motor : CharacterMotor;

function Awake () {
	motor = GetComponent(CharacterMotor);
}

function Update () {
	//motor.inputJump = Input.GetButton("Jump");
}

@script RequireComponent (CharacterMotor)
@script AddComponentMenu ("Character/FPS Input Controller")
