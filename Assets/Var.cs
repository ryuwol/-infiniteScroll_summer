using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Info
{
    public string name;
    public string gender;
    public string hobby;
    public int age;
    public string job;

    public Info()
    {
        
    }
    public Info(Info i)
    {
        name = i.name;
        gender = i.gender;
        hobby = i.hobby;
        age = i.age;
        job = i.job;
    }
}

public class Var : MonoBehaviour
{
    Info Info;
    public List<Info> info = new List<Info>();
    public List<Info> subinfo = new List<Info>();
    public Scrollbar scrollbar;
    public bool ran;
    PersonInfo person;
    public List<string> genders = new List<string>();
    public List<string> firstnames = new List<string>();
    public List<string> hobbies = new List<string>();
    public List<string> femaleNames = new List<string>();
    public List<string> maleNames = new List<string>();
    public List<string> jobs = new List<string>();
    public GameObject Button;
    public GameObject Content;
    private int max = 10;
    private int state = 0;
    private float timer = 0f;
    private float delay = 0.1f;
    private bool isLoading = false;
    bool isFirstLine = true;
    int a=0;
    private void Update()
    {
        if (isFirstLine==false)
        {
            isFirstLine = true;
            for (int i = 0; i < 10; i++)
            {
                GameObject newButton = Instantiate(Button);
                newButton.transform.SetParent(Content.transform, false);
                newButton.GetComponent<PersonInfo>().Info = subinfo[i];
            }
        }
        if (isLoading)
        {
            timer += Time.deltaTime;
            if (timer >= delay)
            {
                timer = 0f;
                isLoading = false;
            }
        }
        if (scrollbar.value <= 0.00001f && !isLoading)
        {
            state = max;
            max += 10;
            if (max < subinfo.Count)
            {
                for (; state < max; state++)
                {
                    GameObject newButton = Instantiate(Button);
                    newButton.transform.SetParent(Content.transform, false);
                    newButton.GetComponent<PersonInfo>().Info = subinfo[state];
                }
                isLoading = true;
            }
        }
    }
    public void Awake()
    {
        if (ran == true)
            SaveInfo(500);
        else
        { 
            LoadInfo();
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
    void SaveInfo(int num)
    {
        StringBuilder peopleContent = new StringBuilder();
        peopleContent.AppendLine("name, gender, hobby, age, job");
        info.Clear();
        for (int i = 0; i < num; i++)
        {
            isFirstLine = false;
            Info newInfo = new Info();
            newInfo.gender = RandomGender();
            newInfo.name = RandomName(newInfo.gender);
            newInfo.hobby = RandomHobby();
            newInfo.age = Random.Range(20, 61);
            newInfo.job = RandomJob();
            info.Add(newInfo);
            subinfo.Add(newInfo);
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
            subinfo.Add(newInfo);
        }
    }
    public void buttongen_gen(int num)
    {
        if (num == -1)
            buttongen();
        else
        {
            a = 0;
            DeleteAllButtons();
            subinfo.Clear();
            string str = genders[num];
            subinfo.Clear();
            for (int i = 0; i < info.Count; i++)
            {
                if (info[i].gender == str)
                {
                    Info newInfo = new Info(info[i]);
                    subinfo.Add(newInfo);
                    Debug.Log(subinfo[subinfo.Count - 1].name);
                    a++;
                }
            }
            scrollbar.value = 1;
            isFirstLine = false;
        }
    }
    public void buttongen()
    {
        DeleteAllButtons();
        subinfo.Clear();
        scrollbar.value = 1;
        LoadInfo();
    }
    public void buttongen_job(int num)
    {
        if (num == -1)
            buttongen();
        else
        {
            DeleteAllButtons();
            string str = jobs[num];
            subinfo.Clear();
            for (int i = 0; i < info.Count; i++)
            {
                if (info[i].job == str)
                {
                    Info newInfo = new Info(info[i]);
                    subinfo.Add(newInfo);
                }
            }
            scrollbar.value = 1;
            isFirstLine = false;
        }
    }


    public void buttongen_hobby(int num)
    {
        if (num == -1)
            buttongen();
        else
        {
            DeleteAllButtons();
            string str = hobbies[num];
            subinfo.Clear();
            for (int i = 0; i < info.Count; i++)
            {
                if (info[i].hobby == str)
                {
                    Info newInfo = new Info(info[i]);
                    subinfo.Add(newInfo);
                }
            }
            scrollbar.value = 1;
            isFirstLine = false;
        }
    }

    private void DeleteAllButtons()
    {
        PersonInfo[] personInfos = FindObjectsOfType<PersonInfo>();
        foreach (var personInfo in personInfos)
        {
            Destroy(personInfo.gameObject);
        }
    }
    public void findname(string str)
    {
        PersonInfo[] personInfos = FindObjectsOfType<PersonInfo>();
        foreach (var personInfo in personInfos)
        {
            if (!personInfo.Info.name.Contains(str))
            {
                Destroy(personInfo.gameObject);
            }
        }
    }
}