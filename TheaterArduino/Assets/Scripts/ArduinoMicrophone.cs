using UnityEngine;
using System.IO.Ports;
using System.Text.RegularExpressions;

public class ArduinoMicrophone : MonoBehaviour
{

    public string portName = "/dev/cu.usbmodem1401";
    public int baudRate = 9600;

    // private int counterValue;

    private SerialPort serialPort;


   


    void Start()
    {
        // Initialize the serial port
        serialPort = new SerialPort(portName, baudRate);
        serialPort.Open();

        // You might want to add some delay here to make sure the Arduino is ready
        // e.g., System.Threading.Thread.Sleep(2000);
    }

   

    void Update()
    {

        // Check if there is data available in the serial port
        if (serialPort.IsOpen && serialPort.BytesToRead > 0)
        {
            string data = serialPort.ReadLine();

            // Check the identifier and parse the data accordingly
             if (data == "S")
            {
                // Debug for "S" message
                Debug.Log("Received 'S' message");
            }
            else if (data == "U")
            {
                // Debug for "U" message
                Debug.Log("Received 'U' message");
            }

            else
            {
                Debug.LogWarning("Failed to parse the received data into an integer. Received data: " + data);
            }
        }
    }


    void OnApplicationQuit()
    {
        // Close the serial port when the application is closed
        if (serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
