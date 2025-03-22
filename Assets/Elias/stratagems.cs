using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class stratagems : MonoBehaviour
{
    public List<StratagemSO> stratagemList = new List<StratagemSO>();
    public List<GameObject> stratagemUIList = new List<GameObject>();

    public GameObject stratagemUIPrefab;
    public Transform contentParent;
    
    public TextMeshProUGUI castingText;
    public KeyCode activationKey = KeyCode.LeftControl;
    public KeyCode strataKey1 = KeyCode.Mouse0;
    public KeyCode strataKey2 = KeyCode.Mouse1;
    public bool entering = false; 
    public string currentCode = "";

    public List<String> applicableCodes = new List<string>();
    
    void Update()
    {
        if (CheckIfCasted())
        {
            entering = false;
            currentCode = "";
            applicableCodes = new List<string>();
            foreach (GameObject go in stratagemUIList)
            {
                Destroy(go);
            }
            stratagemUIList.Clear();
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
            applicableCodes = new List<string>();
            foreach (GameObject go in stratagemUIList)
            {
                Destroy(go);
            }
            stratagemUIList.Clear();
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
            
            applicableCodes = new List<string>();
            foreach (GameObject go in stratagemUIList)
            {
                Destroy(go);
            }
            stratagemUIList.Clear();
            foreach (StratagemSO sg in stratagemList)
            {
                if (!sg.castCode.StartsWith(currentCode)) continue;
                applicableCodes.Add(sg.name);
                applicableCodes.Add(sg.name);
                GameObject uiobj = Instantiate(stratagemUIPrefab, contentParent, false) as GameObject;
                stratagemUIList.Add(uiobj);
                uiobj.GetComponentInChildren<Image>().sprite = sg.gemIcon;
                uiobj.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = sg.gemName;
                uiobj.transform.Find("Code").GetComponent<TextMeshProUGUI>().text = sg.castCode;
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