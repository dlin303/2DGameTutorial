using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ScrollingScript : MonoBehaviour {

	public Vector2 scrollingSpeed = new Vector2(2,2);
	public Vector2 scrollingDirection = new Vector2(-1,0);
	public bool isLinkedToCamera = false;
	public bool isLooping = false;
	private List<Transform> backgroundPart; //list of children with a renderer
	
	// Use this for initialization
	void Start () {
		if (isLooping) {
			backgroundPart = new List<Transform>(); //get all children of the layer with a renderer
			for (int i=0; i < transform.childCount; i++) {
				Transform child = transform.GetChild(i);
				if(child.GetComponent<Renderer>() != null) {
					backgroundPart.Add(child);	
				}
			}

			//sort by position. Get the children from left to right
			backgroundPart = backgroundPart.OrderBy(t => t.position.x).ToList();
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = new Vector3 (scrollingSpeed.x * scrollingDirection.x, 
		                                scrollingSpeed.y * scrollingDirection.y, 
		                                0);
		movement *= Time.deltaTime;
		transform.Translate (movement);
		
		if (isLinkedToCamera) {
			Camera.main.transform.Translate(movement);
		}

		//Looping
		if (isLooping) {
			Transform firstChild = backgroundPart.FirstOrDefault();
			if (firstChild != null) {
				//cheap way to test if child is at least partly in front of camera
				if (firstChild.position.x < Camera.main.transform.position.x) {

					//expensive way to test if renderer is visible from camera
					if(!firstChild.GetComponent<Renderer>().IsVisibleFrom(Camera.main)) {
						Transform lastChild = backgroundPart.LastOrDefault();
						Vector3 lastPosition = lastChild.position;
						Vector3 lastSize = lastChild.GetComponent<Renderer>().bounds.max - lastChild.GetComponent<Renderer>().bounds.min;

						//set position of first child, which is out of view, to be in the position AFTER the last child.
						firstChild.position = new Vector3(
							lastPosition.x + lastSize.x, 
							firstChild.position.y,
							firstChild.position.z);

						backgroundPart.Remove(firstChild);
						backgroundPart.Add(firstChild);
					}
				}
			}
		}
	}
}
