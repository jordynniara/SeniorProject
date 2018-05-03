using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {

    public static int[] speedSelections = new int[6];
    public static float[] speedValues = { -1, -1, -1, -1, -1, -1 };
    
	public static int[] lives = { -1, -1, -1, -1, -1, -1 };
    public Sprite sprite;
	public static List<AudioClip> music = new List<AudioClip>();
    public static Shoot playerShootStyle;
	public static List<Sprite> background = new List<Sprite>();
	public static List<Sprite> player = new List<Sprite>();
    public static List<Shoot.BulletDef>[] shotTypes = new List<Shoot.BulletDef>[6];
	public static List<Sprite> bodyIcon = new List<Sprite>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
