using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    
    [SerializeField] //Could make the text a public element but this isn't necessary
    Text Screen;

    string inputString;
    int[] number = new int[2];
    string operatorSymbol;
    int i = 0;
    int result;
    bool displayedResults = false;

    public void ButtonPressed()
    {
        
        if (displayedResults == true)
        {
            Screen.text = "";
            inputString = "";
            displayedResults = false;
        }

        UnityEngine.Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        string buttonValue = EventSystem.current.currentSelectedGameObject.name;
        inputString += buttonValue;

        int arg;
        if (int.TryParse(buttonValue, out arg))
        {
            if (i > 1) i = 0;
            number[i] = arg;
            i = i + 1;
        }
        else
        {
            switch (buttonValue)
            {
                case "+":
                    operatorSymbol = buttonValue;
                    break;
                case "-":
                    operatorSymbol = buttonValue;
                    break;
                case "=":
                    switch (operatorSymbol)
                    {
                        case "+":
                            result = number[0] + number[1];
                            break;
                        case "-":
                            result = number[0] - number[1];
                            break;
                    }

                    displayedResults = true;
                    inputString = result.ToString();
                    number = new int[2];
                    break;
            }
        
        }
        
        Screen.text = inputString;
    }
}