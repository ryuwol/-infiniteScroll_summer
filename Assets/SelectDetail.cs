using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;
using Unity.VisualScripting;

public class SelectDetail : MonoBehaviour
{
    [SerializeField]
    private Var var;
    private TMP_Dropdown dropdown;
    private TextMeshProUGUI text;
    private bool select = false;
    List<TMP_Dropdown.OptionData> optionList = new List<TMP_Dropdown.OptionData>();
    int base_s;
    public void inputvalue(int num_s)
    {
        base_s = num_s;
        dropdown.ClearOptions();
        optionList.Clear();
        optionList.Add(new TMP_Dropdown.OptionData("±âº»"));
        switch (num_s)
        {
            case 0:
                var.buttongen();
                break;
            case 1:
                foreach (string str in var.genders)
                    optionList.Add(new TMP_Dropdown.OptionData(str));
                break;
            case 2:
                foreach (string str in var.jobs)
                    optionList.Add(new TMP_Dropdown.OptionData(str));
                break;
            case 3:
                var.buttongen();
                break;
            case 4:
                foreach (string str in var.hobbies)
                    optionList.Add(new TMP_Dropdown.OptionData(str));
                break;
        }
        select = true;
        dropdown.AddOptions(optionList);
        dropdown.value = 0;
    }
    public void OnDropDownEvent(int num)
    {
        num--;
        if (select == true)
        {
            switch (base_s)
            {
                case 1:
                    var.buttongen_gen(num);
                    break;
                case 2:
                    var.buttongen_job(num);
                    break;
                case 4:
                    var.buttongen_hobby(num); 
                    break;
            }
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
    }


}
