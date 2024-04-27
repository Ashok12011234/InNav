using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] Text resultText;
    
    public void ValidateInput()
    {
        string input = inputField.text;

        if (input.Length == 0) 
        {
            resultText.text = "Please enter the number";
            resultText.color = Color.red;
        }
        else
        {
            resultText.text = "";
            SceneManager.LoadScene("SampleScene");
        }
    }
}
