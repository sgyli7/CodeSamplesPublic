var target : Transform;
var elbowTarget : Transform;

private var inverseKinematicsScript : inverseKinematics;

function Start(){
	inverseKinematicsScript = GetComponent(inverseKinematics);
}

function Update () {
	inverseKinematicsScript.target = target.position;
	inverseKinematicsScript.elbowTarget = elbowTarget.position;
	inverseKinematicsScript.CalculateIK();
}