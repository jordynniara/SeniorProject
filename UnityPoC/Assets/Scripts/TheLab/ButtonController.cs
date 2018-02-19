using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

	public void ExitMethod() {
		SceneManager.LoadScene("MainMenu");
	}

}