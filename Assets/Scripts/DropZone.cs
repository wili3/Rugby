using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler 
{

	public int maxNumOfAthletes, numOfAthletes;
	public string position;
	public Transform currentAthlete;

    public void OnPointerEnter(PointerEventData eventData) 
	{
        if (eventData.pointerDrag == null)
            return;
		if (eventData.pointerDrag.name == "Scrollbar Horizontal") // avoid errors when dragging the scrollbar out form the editor
			return;
		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

		if (position == "all") // main container has position set to "all"
		{
			if (d != null)
			{
				d.parentToReturnTo = this.transform;
				return;
			}
		}
    }

    public void OnPointerExit(PointerEventData eventData)
	{
		if (eventData.pointerDrag == null)
			return;
		if (eventData.pointerDrag.name == "Scrollbar Horizontal") // avoid errors when dragging the scrollbar out form the editor
			return;
		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

		if (position == "all") // main container has position set to "all"
		{
			if (d != null)
			{
				d.parentToReturnTo = this.transform;
				return;
			}
		}
	}

	public void OnDrop(PointerEventData eventData) 
	{
		if (eventData.pointerDrag.name == "Players Scroll View" || eventData.pointerDrag.name == "Scrollbar Horizontal") // avoid errors when dragging the scrollbar out form the editor
			return;
        Debug.Log(eventData.pointerDrag.name + " dropped on " + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

		if (position == "all") // main container has position set to "all"
		{
			if (d != null)
			{
				d.parentToReturnTo = this.transform;
				CurrentTeam.Instance.RemoveMember (d.GetComponent<Athlete> ());
				TeamAverage.Instance.Average ();
				return;
			}
		}

		if (numOfAthletes >= maxNumOfAthletes)
			return;

		Athlete athlete = eventData.pointerDrag.GetComponent<Athlete> ();
		for (int i = 0; i < athlete.positions.Length; i++) 
		{
			if (athlete.positions [i] == position) 
			{
				if (d != null)
				{
					d.parentToReturnTo = this.transform;
					if (currentAthlete) {
						currentAthlete.transform.SetParent (ParentLayer.Instance.allAthletesContainer);
						currentAthlete.transform.SetAsFirstSibling ();
						CurrentTeam.Instance.RemoveMember (currentAthlete.GetComponent<Athlete> ());
					}
					currentAthlete = eventData.pointerDrag.transform;
					CurrentTeam.Instance.AddMember (currentAthlete.GetComponent<Athlete> ());
					TeamAverage.Instance.Average ();
				}
			}
		}
    }
}
