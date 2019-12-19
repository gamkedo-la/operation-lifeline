using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingText : MonoBehaviour
{
	[Header("Scrolling Text")]
	private bool scrolling = true;
	private float scrollingSpeed = 0.25f;
	private float arrivalThreshold = 0.1f;
	[SerializeField] Transform startPoint;
	[SerializeField] Transform endPoint;
	private float timer = 0;
	private float timerStopValue = 0.78f;
	private float timerStartValue = 0.25f;
	private float percent = 2f;
	private bool stopped = false;
	void Update()
    {
		ScrollText();
    }

	void ScrollText()
	{
		if (scrolling)
		{
			if (!stopped)
			{
				transform.position += Vector3.up * (Time.deltaTime * scrollingSpeed * percent);
				startPoint.position += Vector3.down * (Time.deltaTime * scrollingSpeed * percent);
				timer = timer + (Time.deltaTime * scrollingSpeed * percent);
				if (timer >= (timerStopValue)) { stopped = true; timer = (timerStopValue); }
			}
			else if (stopped)
			{
				timer = timer - (Time.deltaTime * scrollingSpeed * percent);
				if (timer <= (timerStartValue)) { stopped = false; timer = 0f; }
			}

			if (endPoint.position.y > (startPoint.position.y - arrivalThreshold))
			{
				scrolling = false;
			}
		}
	}
}
