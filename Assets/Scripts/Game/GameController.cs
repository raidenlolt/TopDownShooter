using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VM.TopDown.Game
{
	public class GameController : MonoBehaviour
	{
	    // Start is called before the first frame update
	    void Start()
	    {
			FindObjectOfType<Player.PlayerDeath>().PlayerDied += OnPlayerDeath;
	    }

        private void OnPlayerDeath()
        {
            StartCoroutine(RestartAfterDelay());
        }

        private  IEnumerator RestartAfterDelay()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(0);
        }
    }
}
