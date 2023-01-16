using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

	private bool canPause;
	public GameObject menuPause;

	// Start is called before the first frame update
	void Start()
    {
        canPause = true;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown("Cancel") && canPause)
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
