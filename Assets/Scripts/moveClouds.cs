using UnityEngine;
using System.Collections;

public class moveClouds : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.x < 6)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(-3.5f, 3.7f, -4);
        }
    }
}
