using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Athlete : MonoBehaviour 
{
	public string name, country, avatarUrl;
	public string [] positions;
	public int starRating, id;
	public Texture2D playerImage, placeholderTexture;
	public Text nameText, countryText, positionsText;
	public RawImage profilePic;
	public Image[] stars;
	public Image injuredIcon;
	public bool isInjured;

	// Use this for initialization
	public void Initialize(AthleteInfo athleteInfo)
	{
		name = athleteInfo.name;
		country = athleteInfo.country;
		starRating = athleteInfo.star_rating;
		positions = athleteInfo.positions;
		avatarUrl = athleteInfo.avatar_url;
		id = athleteInfo.id;
		isInjured = athleteInfo.is_injured;
		StartCoroutine (GetImage ());
	}

	public void DisplayInfo () // triggered from GetImage()
	{
		nameText.text = name;
		//countryText.text = country;
		SetStars ();
		SetPositionsText ();
		profilePic.texture = playerImage;
		if (isInjured) {
			injuredIcon.gameObject.SetActive (true);
			Destroy(this.GetComponent<Draggable>());
		}
	
	}

	void SetStars()
	{
		for (int i = 0; i < starRating; i++) 
		{
			stars [i].color = Color.yellow;
		}
	}

	void SetPositionsText()
	{
		for (int i = 0; i < positions.Length; i++) 
		{
			positionsText.text = string.Concat (positionsText.text, positions[i], "\n");
		}
	}

	public IEnumerator GetImage()
	{
		WWW www = new WWW(avatarUrl);

		// Wait for download to complete
		yield return www;

		// assign texture
		if (www.texture != null) 
		{
			playerImage = www.texture;
		}
		else 
		{
			playerImage = placeholderTexture;
		}
		DisplayInfo ();
	}
}
