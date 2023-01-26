using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

	private bool canPause = true;
	public GameObject menuPause;

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown("escape"))
		{
			if (canPause)
			{
				menuPause.SetActive(true);
				Time.timeScale = 0;
				canPause = !canPause;
			}
			else
			{
				menuPause.SetActive(false);
				Time.timeScale = 1;
				canPause = !canPause;
			}
		}
	}

	public void ResumeGame()
    {
		if (canPause)
		{
			menuPause.SetActive(true);
			Time.timeScale = 0;
			canPause = !canPause;
		}
		else
		{
			menuPause.SetActive(false);
			Time.timeScale = 1;
			canPause = !canPause;
		}
	}

	public void ExitGame()
    {
		SceneManager.LoadScene(0);
	}
}
