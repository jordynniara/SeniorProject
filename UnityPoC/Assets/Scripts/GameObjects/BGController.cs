using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
	
	}

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, speed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update ()
    {
        while (transform.position.y < -10.0f) transform.position += new Vector3(0, 10.0f);
        while (transform.position.y > 10.0f) transform.position -= new Vector3(0, 10.0f);
    }
}
