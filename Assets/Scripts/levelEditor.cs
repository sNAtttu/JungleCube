using UnityEngine;
using System.Collections;
using System.IO;

public class levelEditor : MonoBehaviour
{

    public string levNumber;
    string runtimeLevels;

    // Use this for initialization
    void Start()
    {

    }

    public void serLevelNumber(string nr)
    {
        levNumber = nr;
    }

    public void ClearButton()
    {
        for (int i = 1; i < 26; i++)
        {
            if (GameObject.Find(i.ToString()).GetComponent<lightSwitch>().isOn)
            {
                GameObject.Find(i.ToString()).GetComponent<lightSwitch>().Change();
            }
        }
    }

    public void SaveButton()
    {
        string levelString = string.Empty;

        for (int i = 1; i < 26; i++)
        {
            if (GameObject.Find(i.ToString()).GetComponent<lightSwitch>().isOn)
            {
                if (levelString.Length == 0)
                {
                    levelString = i.ToString();
                }
                else
                {
                    levelString += "," + i;
                }
            }
        }
        runtimeLevels += @"\n\n<level>\n<levelname>" + levNumber + "</levelname>\n" + "<setup>" + levelString + "</setup></level>";
        System.IO.File.WriteAllText("/Users/SNousiainen/Documents/HackathonQuick/Assets/Resources/editor.txt", runtimeLevels);
    }

}
