using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class AthleteParser : Singleton<AthleteParser> 
{
	[Serializable]
	public class AthleteInfosCollection
	{
		public AthleteInfo[] athletes;
	}

	public AthleteInfosCollection athletesInfo;

	void Start()
	{
		string athletesJson = Resources.Load<TextAsset> ("athletes").text;

		if (athletesJson != string.Empty) 
		{
		 	athletesInfo = JsonUtility.FromJson<AthleteInfosCollection> (athletesJson);
			AthleteCreator.Instance.Create ();
		}
	}
}
