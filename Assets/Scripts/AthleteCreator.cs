using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AthleteCreator : Singleton<AthleteCreator> {

	public List<Athlete> athletes;
	public GameObject athletePrefab;
	public Transform mainDropZone;

	// Use this for initialization
	public void Create () 
	{
		for (int i = 0; i < AthleteParser.Instance.athletesInfo.athletes.Length; i++) 
		{
			athletes.Add (Instantiate (athletePrefab).GetComponent<Athlete> ());
			athletes [i].Initialize (AthleteParser.Instance.athletesInfo.athletes [i]);
			athletes [i].transform.SetParent (mainDropZone);
		}
	}
}
