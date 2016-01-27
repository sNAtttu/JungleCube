using UnityEngine;
using System.Collections;
using System;

public class turnManager : MonoBehaviour {

	// Use this for initialization
	    void Start () {

            int count = 1;
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    GameObject tempObject = Instantiate(Resources.Load("Cube", typeof(GameObject))) as GameObject;
                    tempObject.transform.position = new Vector3(j * 1.1f - 2, i * -1.1f + 5, 0);
                    tempObject.name = count.ToString();
                    count++;
                }
            }
            this.gameObject.GetComponent<levelHandler>().LoadLevel(1);
	    }
	
	    // Update is called once per frame
	    void Update () {
            if (Input.GetMouseButtonUp(0))
            {
                int count = 1;
                RaycastHit hit = new RaycastHit();
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out hit, 100))
                {
                    makeMove(int.Parse(hit.collider.gameObject.name));
                    for (int i = 1; i < 26; i++)
                    {
                        if (!GameObject.Find(i.ToString()).GetComponent<lightSwitch>().isOn)
                        {
                            count++;
                            Debug.Log(count);
                            if (count == 26)
                            {
                                Application.Quit();
                            }
                        }
                    }
                }
            }
	    }

    public void ClearLevel()
    {
        for (int i = 1; i < 26; i++)
        {
            GameObject.Find(i.ToString()).GetComponent<lightSwitch>().isOn = true;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void makeMove(int name)
    {
        turn(name);
        turn(name + 5);
        turn(name - 5);
        if(name % 5 != 0)
        {
            turn(name + 1);
        }
        if(name % 5 != 1)
        {
            turn(name - 1);
        }
    }

    private void turn(int name)
    {
        if (name < 1 || name > 25) return;
        GameObject currentGO = GameObject.Find(name.ToString()).gameObject;
        currentGO.GetComponent<lightSwitch>().Change();
    }
}
