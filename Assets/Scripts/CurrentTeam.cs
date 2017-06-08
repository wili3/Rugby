using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentTeam : Singleton<CurrentTeam> {


	public List<Athlete> athletes;

	public void AddMember(Athlete athlete)
	{
		athletes.Add (athlete);
	}

	public void RemoveMember(Athlete athlete)
	{
		athletes.Remove (athlete);
	}

	public void ResetTeam()
	{
		for (int i = 0; i < athletes.Count; i++) 
		{
			athletes [i].transform.SetParent (ParentLayer.Instance.allAthletesContainer);
			RemoveMember (athletes [i]);
		}
		TeamAverage.Instance.Average ();
	}
}
