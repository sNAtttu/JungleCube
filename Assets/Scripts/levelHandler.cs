using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;

public class levelHandler : MonoBehaviour {

    XmlDocument levelDoc;
    XmlNodeList levelList;
    List<string> levelArray;

	// Use this for initialization
	void Start () {

        levelArray = new List<string>();
        levelDoc = new XmlDocument();
        TextAsset xmlfile = Resources.Load("levels", typeof(TextAsset)) as TextAsset;
        levelDoc.LoadXml(xmlfile.text);
        levelList = levelDoc.GetElementsByTagName("level");
        foreach(XmlNode level in levelList)
        {
            XmlNodeList levelInfo = level.ChildNodes;
            foreach(XmlNode data in levelInfo)
            {
                if(data.Name == "setup")
                {
                    levelArray.Add(data.InnerText);
                    Debug.Log(data.InnerText);
                }
            }
        }
	}

    public void LoadLevel(int nr)
    {
        string[] levelStrings = levelArray[nr - 1].Split(',');
        foreach(string brick in levelStrings)
        {
            GameObject.Find(brick).GetComponent<lightSwitch>().Change();
        }
    }
}
