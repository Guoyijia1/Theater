using UnityEngine;
using System.IO.Ports;
using System.Text.RegularExpressions;

public class ArduinoCommunication : MonoBehaviour
{
    // Set the COM port and baud rate according to your Arduino settings
    public string portName = "/dev/cu.usbmodem1401";
    public int baudRate = 9600;

   // private int counterValue;

    private SerialPort serialPort;


    private const float REAL_SECOND_PER_INGAME_DAY = 60f;

    public GameObject clockHourHand;
    public GameObject clockMinuteHand;

    private Transform clockHourHandTransform;
    private Transform clockMinuteHandTransform;

    private float day;

    //private int counterValue;


    //Ultrosonic
    int distanceData;

    public int GetDistance()
    {
        return distanceData;
    }


    void Start()
    {
        // Initialize the serial port
        serialPort = new SerialPort(portName, baudRate);
        serialPort.Open();

        // You might want to add some delay here to make sure the Arduino is ready
        // e.g., System.Threading.Thread.Sleep(2000);
    }

    private void Awake()
    {
        clockHourHandTransform = clockHourHand.transform;
        clockMinuteHandTransform = clockMinuteHand.transform;
    }

    void Update()
    {

        // Check if there is data available in the serial port
        if (serialPort.IsOpen && serialPort.BytesToRead > 0)
        {
            // Read the data from the serial port
            string data = serialPort.ReadLine();

            //get Ultrosonic data
            distanceData = int.Parse(data);

            // Remove non-numeric characters
            string numericData = Regex.Replace(data, @"[^\d]", "");

            if (distanceData >= 20 && distanceData < 50)
            {
                Debug.Log("Ultrosonic get message:" + distanceData);
            }

            /*
            if (data == "S")
            {
                // Debug for "S" message
                Debug.Log("Received 'S' message");
            }
            */

            // Parse the data into an integer
            if (int.TryParse(numericData, out int counterValue))
            {
                // Now you can use the counterValue in your Unity application
               Debug.Log("Counter Value: " + counterValue);

                //int rotationDegreesPerDay = 360;
                clockHourHandTransform.eulerAngles = new Vector3(0, 0, -counterValue);

                int hoursPerDay = 24;
                clockMinuteHandTransform.eulerAngles = new Vector3(0, 0, -counterValue * hoursPerDay);

            }

            else
            {
                Debug.LogWarning("Failed to parse the received data into an integer. Received data: " + data);
            }
        }

        //day += Time.deltaTime / REAL_SECOND_PER_INGAME_DAY;
        //float dayNormalized = day % 1f;
        //int dayNormalized = counterValue % 1;

        

    }




    /*
    public int CounterValue
    {
        get { return counterValue; }
    }
    */

    void OnApplicationQuit()
    {
        // Close the serial port when the application is closed
        if (serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}