using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditor.Build.Content;
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
        if (ran == true)
        {
            SaveInfo(500);
        }
        else
            LoadInfo();
    }

    //void Randominfo(int num)
    //{
    //    info.Clear();
    //    for (int i = 0; i < num; i++)
    //    {
    //        Info newInfo = new Info();
    //        newInfo.gender = RandomGender();
    //        newInfo.name = RandomName(newInfo.gender);
    //        newInfo.hobby = RandomHobby();
    //        newInfo.age = Random.Range(20, 61);
    //        newInfo.job = RandomJob();
    //        info.Add(newInfo);
    //        GameObject newButton = Instantiate(Button);
    //        newButton.transform.SetParent(Content.transform);
    //        newButton.GetComponent<PersonInfo>().Info = newInfo;
    //    }
    //}

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
    void SaveInfo(int num)
    {
        StringBuilder peopleContent = new StringBuilder();
        peopleContent.AppendLine("name, gender, hobby, age, job");
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
        foreach (var info in info)
        {
            string infoline = $"{info.name},{info.gender},{info.hobby},{info.age},{info.job}";
            peopleContent.AppendLine(infoline);
        }
        string filePath = Path.Combine(Application.dataPath, "PersonInfo.csv");
        File.WriteAllText(filePath, peopleContent.ToString());
    }
    void LoadInfo()
    {
        string filePath = Path.Combine(Application.dataPath, "PersonInfo.csv");
        info.Clear();
        string[] Infocsv = File.ReadAllLines(filePath);
        bool isFirstLine = true;

        foreach (var csv in Infocsv)
        {
            if (isFirstLine)
            {
                isFirstLine = false;
                continue;
            }
            string[] values = csv.Split(',');
            Info newInfo = new Info();
            newInfo.name = values[0];
            newInfo.gender = values[1];
            newInfo.hobby = values[2];
            newInfo.age = int.Parse(values[3]);
            newInfo.job = values[4];

            info.Add(newInfo);
            GameObject newButton = Instantiate(Button);
            newButton.transform.SetParent(Content.transform);
            newButton.GetComponent<PersonInfo>().Info = newInfo;
        }
    }
    public void Start()
    {
        
    }
}
