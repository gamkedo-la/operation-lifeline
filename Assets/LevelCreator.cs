using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCreator : MonoBehaviour
{
	[Header("Parameters")]
	[SerializeField] float height = 7000;
	[SerializeField] float width = 488 * 2;
	[SerializeField] int amtRocks = 22;
	[Header("References")]
	[SerializeField] GameObject rightBoundary;
	[SerializeField] GameObject leftBoundary;
	[SerializeField] GameObject rockPrefab;
	[SerializeField] GameObject hospital;
	[SerializeField] string starsScene;
	
	List<GameObject> rocks = new List<GameObject>();
	float rockRadius = 50f;
	int currentRockAmt= 0;

	void Start()
    {
		LoadStars();
		float x = width / 2;
		float midY = height / 2;
		rightBoundary.transform.position = new Vector3(x, midY, 0f);
		leftBoundary.transform.position = new Vector3(-x, midY, 0f);
		foreach (Transform boundary in rightBoundary.transform)
		{
			boundary.localScale = new Vector3(height*100, boundary.localScale.y, boundary.localScale.z);
		}
		foreach (Transform boundary in leftBoundary.transform)
		{
			boundary.localScale = new Vector3(height*100, boundary.localScale.y, boundary.localScale.z);
		}
		hospital.transform.position = new Vector3(0f, height+200f, 0f);
		do
		{
			MakeRock();
			if (currentRockAmt >= amtRocks || Input.anyKey) 
			{ 
				return; 
			}
		} while (currentRockAmt < amtRocks);
	}

    void LoadStars()
    {
        if (!SceneManager.GetSceneByName(starsScene).isLoaded)
		{
			SceneManager.LoadScene(starsScene, LoadSceneMode.Additive);
		}
    }

	private void MakeRock()
	{
		float x = Random.Range(-(width/2) + rockRadius, (width/2) - rockRadius);
		float y = Random.Range(600, height - rockRadius);
		Vector3 pos = new Vector3(x, y, 0f);
		RaycastHit hitInfo;
		int layer = LayerMask.NameToLayer("Rocks");
		bool hit = Physics.SphereCast(pos, rockRadius, Vector3.zero, out hitInfo, 0f, layer, QueryTriggerInteraction.Collide);
		if (hit) { return; }
		Instantiate(rockPrefab, pos, Quaternion.identity);
		currentRockAmt += 1;
	}
}
