using UnityEngine;
using System.Collections;
using System.IO;
using System;

[Serializable]
public class AthleteInfo 
{
	public string name;
	public string country;
	public int star_rating;
	public string[] positions;
	public bool is_injured;
	public int id;
	public string avatar_url;
	public DateTime last_played;
}
