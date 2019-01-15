using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	private int health;
	private bool hasDied = false;

    // Update is called once per frame
    void Update()
    {
		if (gameObject.transform.position.y < -6) {
			Die();
		}
    }

	public void Die() {
		DataManagement.dataManagement.deathCount++;
		Debug.Log("Current death count: " + DataManagement.dataManagement.deathCount);
		SceneManager.LoadScene("Level1");
	}

}
