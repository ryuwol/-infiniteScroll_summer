using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class Info
{
    public string name;
    public string gender;
    public string hobby;
    public int age;
    public string job;
}

public class Var : MonoBehaviour
{
    public List<Info> info = new List<Info>();
    public bool ran;
    public List<string> genders = new List<string>();
    public List<string> firstnames = new List<string>();
    public List<string> hobbies = new List<string>();
    public List<string> femaleNames = new List<string>();
    public List<string> maleNames = new List<string>();
    public List<string> jobs = new List<string>();
    public GameObject Button;
    public GameObject Content;
    public void Awake()
    {
        if (ran)
        {
            Randominfo(500);
        }
    }

    void Randominfo(int num)
    {
        info.Clear();
        for (int i = 0; i < num; i++)
        {
            Info newInfo = new Info();
            newInfo.gender = RandomGender();
            newInfo.name = RandomName(newInfo.gender);
            newInfo.hobby = RandomHobby();
            newInfo.age = Random.Range(20, 61);
            newInfo.job = RandomJob();
            info.Add(newInfo);
            GameObject newButton = Instantiate(Button);
            newButton.transform.SetParent(Content.transform);
            newButton.GetComponent<PersonInfo>().Info = newInfo;
        }
    }

    string RandomGender()
    {
        return genders[Random.Range(0, genders.Count)];
    }
    string RandomName(string gender)
    {
        string first = firstnames[Random.Range(0, firstnames.Count)];
        if (gender == "¿©")
        {
            return first + femaleNames[Random.Range(0, femaleNames.Count)];
        }
        else if (gender == "³²")
        {
            return first + maleNames[Random.Range(0, maleNames.Count)];
        }
        else
        {
            return first + femaleNames.Concat(maleNames).ToArray()[Random.Range(0, femaleNames.Count + maleNames.Count)];
        }
    }

    string RandomHobby()
    {
        return hobbies[Random.Range(0, hobbies.Count)];
    }
    string RandomJob()
    {
        return jobs[Random.Range(0, jobs.Count)];
    }

    public void Start()
    {
        
    }
}
