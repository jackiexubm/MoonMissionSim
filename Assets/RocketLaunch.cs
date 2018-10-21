using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RocketLaunch : MonoBehaviour {

    public GameObject rocket;
    const float engineBurnBeforeLaunchTime = 10.0f;
    const float maxTilt = 10f;
    const float altitudeAcceleration = 10.0f;
    const float xAcceleration = 1.0f;


    bool launched = false;
    float timeAtLaunch;
    Vector3 initialPosition;
    Vector3 initialRotation;


    public void updateRocketTransform()
    {
        Debug.Log(UnityEngine.Time.time);

        float timeInAir = UnityEngine.Time.time - timeAtLaunch - engineBurnBeforeLaunchTime;
        if (timeInAir < 0) return;

        float newAltitude = calculateAltitude(timeInAir);
        float newTilt = calculateTilt(timeInAir);
        float newOffset = calculateOffset(timeInAir);

        rocket.transform.position = new Vector3(initialPosition.x, initialPosition.y + newAltitude, initialPosition.z);
        rocket.transform.eulerAngles = new Vector3(initialRotation.x + newTilt, initialRotation.y, initialRotation.z);


    }

    public static float calculateAltitude(float timeInAir)
    {
        float altitude = 0.5f * altitudeAcceleration * timeInAir * timeInAir;
        return altitude;
    }

    public static float calculateTilt(float timeInAir)
    {
        float tilt = Math.Min(maxTilt, timeInAir - 5);
        if (tilt < 0) return 0;
        // about 1/2 deg per sec up to max tilt - start tilting 5 sec in
        return tilt/2;
    }

    public static float calculateOffset(float timeInAir)
    {
        float offset = 0.5f * xAcceleration * timeInAir * timeInAir;
        return offset;
    }

    public void beginLaunch()
    {
        // store begin time
        timeAtLaunch = UnityEngine.Time.time;
        launched = true;
        turnOnEngines();
    }

    public void turnOnEngines()
    {

    }

    // Use this for initialization
    void Start () {
        initialPosition = rocket.transform.position;
        initialRotation = rocket.transform.eulerAngles;
    }
	
	// Update is called once per frame
	void Update () {
        if (launched)
        {
            updateRocketTransform();
        }else
        {
            beginLaunch();
        }
    }
}
