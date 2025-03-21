using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class stratagems : MonoBehaviour
{
    public List<StratagemSO> stratagemList = new List<StratagemSO>();
    
    public TextMeshProUGUI castingText;
    public KeyCode activationKey = KeyCode.LeftControl;
    public KeyCode strataKey1 = KeyCode.Mouse0;
    public KeyCode strataKey2 = KeyCode.Mouse1;
    public bool entering = false; 
    public string currentCode = ""; 
    
    void Update()
    {
        if (CheckIfCasted())
        {
            entering = false;
            currentCode = "";
            castingText.color = new Color(1, 1, 1, 0);
        }
        
        if (Input.GetKeyDown(activationKey))
        {
            entering = true;
            castingText.color = new Color(1, 1, 1, 1);
        }
        if(Input.GetKeyUp(activationKey))
        {
            entering = false;
            currentCode = "";
            castingText.color = new Color(1, 1, 1, 0);
        }
        if(entering){
            if (Input.GetKeyDown(strataKey1))
            {
                currentCode = currentCode + "0";
            }
            if (Input.GetKeyDown(strataKey2))
            {
                currentCode = currentCode + "1";
            }
        }

        castingText.text = "Currently casting\n   |     " + currentCode;
    }

    private bool CheckIfCasted()
    {
        foreach (StratagemSO sg in stratagemList)
        {
            if (currentCode.Equals(sg.castCode)) return true;
        }
        return false;
    }
}
