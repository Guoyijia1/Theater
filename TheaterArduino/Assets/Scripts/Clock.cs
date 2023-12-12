using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public ArduinoData arduinoData;

    private const float REAL_SECOND_PER_INGAME_DAY = 60f;

    public GameObject clockHourHand;
    public GameObject clockMinuteHand;

    private Transform clockHourHandTransform;
    private Transform clockMinuteHandTransform;

    private float day;

    private void Start()
    {
        // Find and store a reference to the ArduinoCommunication script
        arduinoData = GetComponent<ArduinoData>();

        
    }

    private void Awake()
    {
        clockHourHandTransform = clockHourHand.transform;
        clockMinuteHandTransform = clockMinuteHand.transform;
    }

   

    // Update is called once per frame
    private void Update()
    {
        //int distanceValue = arduinoData.DistanceValue;
        int distanceValue = arduinoData.DistanceValue;
        int positionValue = arduinoData.PositionValue;

        // Use distanceValue and positionValue as needed
        Debug.Log("Distance from AnotherScript: " + distanceValue + ", Position: " + positionValue);

        day += Time.deltaTime / REAL_SECOND_PER_INGAME_DAY;
        float dayNormalized = day % 1f;

        //float rotationDegreesPerDay = 360f;
        // clockHourHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay);
       // clockHourHandTransform.eulerAngles = new Vector3(0, 0, -positionValue);

        //float hoursPerDay = 24f;
        //clockMinuteHandTransform.eulerAngles = new Vector3(0, 0, -positionValue * hoursPerDay);



    }
}
