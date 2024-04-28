using System;
using PedometerU;
using UnityEngine;

public class person : MonoBehaviour
{
    private int totalSteps = 0;
    private Pedometer pedometer;


    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerPrefs.GetInt("IntValue"))
        {
            case 1:
                transform.position = new Vector3(-120f, -507f, -371f);
                break;
            case 2:
                transform.position = new Vector3(172f, -506f, -374f);
                GameObject go = GameObject.Find("Main Camera");
                go.transform.position = new Vector3(189f, -389f, -392f);
                break;
            default:
                transform.position = new Vector3(-120f, -507f, -371f);
                break;
        }

        pedometer = new Pedometer(OnStep);
        // Reset UI
        OnStep(0, 0);
    }

    private void OnStep(int steps, double distance)
    {

        totalSteps = steps;
    }

    // Update is called once per frame
    void Update()
    {
        
            float distanceToMove = totalSteps * 10.0f;

            transform.Translate(Vector3.forward * distanceToMove);
        
    }

    private void OnDisable()
    {
        // Release the pedometer
        pedometer.Dispose();
        pedometer = null;
    }

    void OnGUI()
    {
        // Calculate the center of the screen
        float centerX = Screen.width / 2;
        float centerY = Screen.height / 2;

        // Define the size of the text box
        float width = 700;
        float height = 400;

        // Calculate the position of the text box
        float x = centerX - (width / 2);
        float y = centerY - (height / 2);

        // Make a text field that modifies stringToEdit
        string outText = "Total Steps: " + totalSteps.ToString();

        GUIStyle style = new GUIStyle(GUI.skin.textField);
        style.fontSize = 26;



        GUI.TextField(new Rect(x, y, width, height), outText, style);

    }
}