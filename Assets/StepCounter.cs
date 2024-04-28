using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepCounter : MonoBehaviour
{
    private float[] gravity = new float[3];
    private float[] smoothed = new float[3];
    private bool toggle;
    private double prevY;
    private double threshold;
    private bool ignore;
    private int countdown;
    private int stepCount;

    //public Text accText;
    //public Text stepCountText;
    //public Text thresholdText;
    //public Toggle countToggle;
    //public Slider seek;

    void Start()
    {
        //seek.value = 0;
        //seek.minValue = 0;
        //seek.maxValue = 40;
        //implementListeners();
    }

    void Update()
    {
        Input.gyro.enabled = true;
        gravity[0] = Input.acceleration.x;
        gravity[1] = Input.acceleration.y;
        gravity[2] = Input.acceleration.z;
        smoothed = lowPassFilter(gravity, smoothed);
        //accText.text = "x: " + gravity[0] + " y: " + gravity[1] + " z: " + gravity[2] + " ignore: " + ignore + " countdown: " + countdown;

        if (ignore)
        {
            countdown--;
            ignore = (countdown < 0) ? false : ignore;
        }
        else
        {
            countdown = 22;
        }

        if (toggle && (Mathf.Abs((float)(prevY - gravity[1])) > (float)threshold) && !ignore)
        {
            stepCount++;
            //stepCountText.text = "Step Count: " + stepCount;
            ignore = true;
        }
        prevY = gravity[1];
    }

    protected float[] lowPassFilter(float[] input, float[] output)
    {
        if (output == null) return input;
        for (int i = 0; i < input.Length; i++)
        {
            output[i] = output[i] + 1.0f * (input[i] - output[i]);
        }
        return output;
    }

    //public void implementListeners()
    //{
    //    seek.onValueChanged.AddListener(delegate { OnThresholdChanged(); });
    //    countToggle.onValueChanged.AddListener(delegate { OnCountToggleChanged(); });
    //}

    //public void OnThresholdChanged()
    //{
    //    threshold = ((double)seek.value) * 0.02;
    //    thresholdText.text = "Threshold: " + threshold;
    //}

    //public void OnCountToggleChanged()
    //{
    //    toggle = countToggle.isOn;
    //    if (toggle)
    //    {
    //        stepCount = 0;
    //        countdown = 5;
    //        ignore = true;
    //        stepCountText.text = "Step Count: " + stepCount;
    //    }
    //}

    void OnGUI()
    {
        // Calculate the center of the screen
        float centerX = Screen.width / 2;
        float centerY = Screen.height / 2;

        // Define the size of the text box
        float width = 400;
        float height = 40;

        // Calculate the position of the text box
        float x = centerX - (width / 2);
        float y = centerY - (height / 2);

        // Make a text field that modifies stringToEdit
        string stringToEdit = GUI.TextField(new Rect(x, y, width, height), stepCount.ToString(), 25);
    }
}
