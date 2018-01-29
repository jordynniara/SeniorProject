using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	private Transform enemies;
	public float speed;

	public GameObject pellet;
	public float fireRate = 0.997f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("MoveEnemy", 0.1f, 0.3f);
		enemies = GetComponent<Transform> ();
	}

	void MoveEnemy()
	{
		enemies.position += Vector3.right * speed;

		foreach (Transform enemy in enemies) {
			if (enemy.position.x < -10.5 || enemy.position.x > 10.5) {
				speed = -speed;
				return;
			}
		}
	}
}