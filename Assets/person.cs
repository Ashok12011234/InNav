using System;
using System.Collections;
using PedometerU;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class person : MonoBehaviour
{
    private int totalSteps = 0;
    private Pedometer pedometer;
    Vector3 startVector;
    float singleStepDistance = 0.5f;
    public float compassSmooth = 50.5f;
    private float m_lastMagneticHeading = 0f;

    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerPrefs.GetInt("IntValue"))
        {
            case 1:
                startVector = new Vector3(-145f, -504f, -427f);
                transform.position = startVector ;
                break;
            case 2:
                startVector = new Vector3(172f, -506f, -374f);
                transform.position = startVector;
                GameObject go = GameObject.Find("Main Camera");
                go.transform.position = new Vector3(189f, -389f, -392f);
                break;
            default:
                startVector = new Vector3(-145f, -504f, -427f);
                transform.position = startVector;
                break;
        }

        pedometer = new Pedometer(OnStep);
        // Reset UI
        OnStep(0, 0);

        Input.location.Start();
        // Start the compass.
        Input.compass.enabled = true;
        StartCoroutine(UpdateRotationRoutine());

    }

    private IEnumerator UpdateRotationRoutine()
    {
        while (true)
        {
            float currentMagneticHeading = (float)Math.Round(Input.compass.magneticHeading, 2);
            if (m_lastMagneticHeading < currentMagneticHeading - compassSmooth || m_lastMagneticHeading > currentMagneticHeading + compassSmooth)
            {
                m_lastMagneticHeading = currentMagneticHeading;
                transform.rotation = Quaternion.Euler(0, m_lastMagneticHeading, 0);
            }
            //transform.localRotation = Quaternion.Euler(0, -Input.compass.trueHeading * 10, 0);
            yield return new WaitForSeconds(0.15f);
        }
    }

    private void OnStep(int steps, double distance)
    {

        totalSteps = steps;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToMove = totalSteps * singleStepDistance;
        transform.position = startVector + new Vector3(0,0, distanceToMove);
    }

    private void OnDisable()
    {
        // Release the pedometer
        pedometer.Dispose();
        pedometer = null;
    }

    //void OnGUI()
    //{
    //    // Calculate the center of the screen
    //    float centerX = Screen.width / 2;
    //    float centerY = Screen.height / 2;

    //    // Define the size of the text box
    //    float width = 700;
    //    float height = 400;

    //    // Calculate the position of the text box
    //    float x = centerX - (width / 2);
    //    float y = centerY - (height / 2);

    //    // Make a text field that modifies stringToEdit
    //    string outText = "Total Steps: " + totalSteps.ToString() + " compasssss : " + Input.compass.trueHeading.ToString();

    //    GUIStyle style = new GUIStyle(GUI.skin.textField);
    //    style.fontSize = 26;



    //    GUI.TextField(new Rect(x, y, width, height), outText, style);

    //}
}