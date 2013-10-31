using UnityEngine;
using System.Collections;

public static class TrajectoryHelper 
{
	public static Vector3 GetTrajectoryVelocity(Vector3 startingPosition, Vector3 targetPosition, float lob, Vector3 gravity)
    {
        float physicsTimestep = Time.fixedDeltaTime;
        float timestepsPerSecond = Mathf.Ceil(1f/physicsTimestep);
 
        //By default we set n so our projectile will reach our target point in 1 second
        float n = lob * timestepsPerSecond;
 
        Vector3 a = physicsTimestep * physicsTimestep * gravity;
        Vector3 p = targetPosition;
        Vector3 s = startingPosition;
 
        Vector3 velocity = (s + (((n * n + n) * a) / 2f) - p) * -1 / n;
 
        //This will give us velocity per timestep. The physics engine expects velocity in terms of meters per second
        velocity /= physicsTimestep;
        return velocity;
    }
}
