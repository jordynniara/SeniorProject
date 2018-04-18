using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour {

    public float speed;
    public SpriteRenderer background;

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
        float height = background.bounds.size.y;
        

        while (transform.position.y < -height) transform.position += new Vector3(0, height);
        while (transform.position.y > height) transform.position -= new Vector3(0, height);
    }
}
