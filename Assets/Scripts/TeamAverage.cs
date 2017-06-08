using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamAverage : Singleton<TeamAverage> {

	public Image[] stars;
	public void Average()
	{
		ResetStars();
		int starAmount = 0;
		for (int i = 0; i < CurrentTeam.Instance.athletes.Count; i++) {
			starAmount += CurrentTeam.Instance.athletes [i].starRating;
		}
		if(starAmount > 0)starAmount = Mathf.CeilToInt (starAmount / CurrentTeam.Instance.athletes.Count);
		for (int i = 0; i < starAmount; i++) 
		{
			stars [i].color = Color.yellow;
		}
	}

	public void ResetStars()
	{
		for (int i = 0; i < stars.Length; i++) 
		{
			stars [i].color = Color.white;
		}
	}

}
