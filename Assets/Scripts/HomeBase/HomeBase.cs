using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{
    [SerializeField] private string nextLevelSceneName = null;
	[SerializeField] Transform[] emitters = null;
	[SerializeField] Material beamMaterial = null;
	[SerializeField] Transform landingZone = null;
	private List<LineRenderer> tractorBeams = new List<LineRenderer>();
    private BoxCollider2D colHomeBase;
	private bool tractorBeamsAreActive = false;
	private GameObject player = null;
	private float tractorSpeed = 85f;
	private float arrivalThreshold = 50f;
	

	
    // Start is called before the first frame update
    void Start()
    {
        colHomeBase = gameObject.GetComponent<BoxCollider2D>();
		player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D colliderHit)
    {
        if (colliderHit.gameObject.CompareTag("Player"))
		{
			ActivateTractorBeams();
		}
		
    }

	void ActivateTractorBeams()
	{
		ActivatePlayerDockingProtocol();
		FreezePlayer();
		foreach (Transform emitter in emitters)
		{
			GameObject tractorSystem = new GameObject();
			tractorSystem.transform.position = emitter.position;
			LineRenderer tractorBeam = tractorSystem.AddComponent<LineRenderer>();
			//GradientColorKey colorKeyLight = new GradientColorKey(Color.cyan, 0);
			//GradientColorKey colorKeyDark = new GradientColorKey(Color.blue, 1);
			//Gradient beamColor = new Gradient();
			//beamColor.colorKeys = new GradientColorKey[2] { colorKeyLight, colorKeyDark};
			//tractorBeam.colorGradient = beamColor;
			tractorBeam.material = beamMaterial;
			tractorBeam.startColor = Color.cyan;
			tractorBeam.endColor = Color.blue;
			tractorBeam.endWidth = player.GetComponentInChildren<Renderer>().bounds.extents.y * 1.5f;
			tractorBeam.startWidth = 0.01f;
			tractorBeam.positionCount = 2;
			tractorBeam.SetPosition(0, emitter.position);
			tractorBeam.SetPosition(1, player.transform.position);
			tractorBeams.Add(tractorBeam);
		}
		tractorBeamsAreActive = true;
		PlayMusicFX();
	}

	private void Update()
	{
		if (!tractorBeamsAreActive)
		{
			if (player && player.transform.position.y >= this.transform.position.y) { ActivateTractorBeams(); }
		}

		if (tractorBeamsAreActive) 
		{
			DrawTractorBeams();
			FreezePlayer();
			TractorPlayer();
			CheckForLevelAdvance();
		}
	}

	private void PlayMusicFX()
	{
		//play a happy "you beat the level" sound effect or music
	}

	private void FreezePlayer()
	{
		Rigidbody2D rbody2D = player.GetComponent<Rigidbody2D>();
		rbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
		rbody2D.velocity = Vector2.zero;
		rbody2D.angularVelocity = 0f;
		rbody2D.isKinematic = true;
		rbody2D.simulated = false;
	}

	private void ActivatePlayerDockingProtocol()
	{
		PlayerController playerController = player.GetComponent<PlayerController>();
		if (playerController)
		{
			playerController.ActivateDockingProtocol();
		}
	}
	private void TractorPlayer()
	{
		if (!landingZone) return;
        float distanceToPlayer = Vector2.Distance(landingZone.position, player.transform.position);
		float tractingAmount = Mathf.Clamp(tractorSpeed * Time.deltaTime, 0f, distanceToPlayer);
		Vector2 vectorTowardLandingZone = landingZone.position - player.transform.position;
		Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
		Debug.DrawLine(player.transform.position, playerPos + vectorTowardLandingZone, Color.yellow, Time.deltaTime);
		vectorTowardLandingZone = vectorTowardLandingZone.normalized * tractingAmount;
		playerPos = playerPos + vectorTowardLandingZone;
		player.transform.position = new Vector3(playerPos.x, playerPos.y, 0f);
	}

	private void DrawTractorBeams()
	{
		foreach (LineRenderer beam in tractorBeams)
		{
			beam.SetPosition(1, player.transform.position);
		}
	}

	private void CheckForLevelAdvance()
	{
		float distanceToPlayer = Vector3.Distance(landingZone.position, player.transform.position);
		if (distanceToPlayer < arrivalThreshold) 
		{
			GameManager.Instance.LoadScene(nextLevelSceneName);
		}
	}
}