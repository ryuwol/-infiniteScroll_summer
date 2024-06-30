using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class SelectDetail : MonoBehaviour
{
    [SerializeField]
    private Var var;
    private TMP_Dropdown dropdown;
    private TextMeshProUGUI text;
    List<TMP_Dropdown.OptionData> optionList = new List<TMP_Dropdown.OptionData>();
    public void inputvalue(int num)
    {
        dropdown.ClearOptions();
        switch (num)
        {
            case 0:
                {
                   
                }
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        foreach (string str in var.genders) 
        {
            optionList.Add(new TMP_Dropdown.OptionData(str));
        }
        dropdown.AddOptions(optionList);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
