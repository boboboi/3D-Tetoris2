// Fades light over time

var lightIntensity = 2.0;
var fadeSpeed = 1.0;

function Update () {
	lightIntensity = Mathf.Max (lightIntensity - Time.deltaTime*fadeSpeed, 0.0);
	GetComponent(Light).intensity = lightIntensity;
}