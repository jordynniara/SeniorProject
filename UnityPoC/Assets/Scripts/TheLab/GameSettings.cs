using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {

	public int speed;
	public int shootStyle;
	public int lives;
	public Sprite sprite;
	public static List<AudioClip> music = new List<AudioClip>();
    public static Shoot playerShootStyle;
	//public static List<Sprite> background = new List<Sprite>();
	public static List<Sprite> player = new List<Sprite>();
    public static List<Shoot.BulletDef> playerBullets = null;
	public static List<Sprite> bodyIcon = new List<Sprite>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
