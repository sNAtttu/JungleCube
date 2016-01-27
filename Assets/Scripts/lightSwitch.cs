using UnityEngine;
using System.Collections;

public class lightSwitch : MonoBehaviour {

    public bool isOn = false;
    AudioSource audio;
 // Use this for initialization
    void Start () {

	    }
    public void Change()
    {
        if (isOn)
        {
            isOn = false;
            transform.localEulerAngles = new Vector3(0, 90, 0);
            audio = GetComponent<AudioSource>();
            audio.Play();
        }
        else
        {
            isOn = true;
            transform.localEulerAngles = Vector3.zero;
            audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }
}

