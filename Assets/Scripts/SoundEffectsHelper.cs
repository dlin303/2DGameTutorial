using UnityEngine;
using System.Collections;

public class SoundEffectsHelper : MonoBehaviour {

	public static SoundEffectsHelper Instance;
	public AudioClip explosionSound;
	public AudioClip enemyShotSound;
	public AudioClip playerShotSound;

	void Awake() {
		if (Instance != null) {
			Debug.LogError ("More than one instance of SpecialEffectsHlper!");
		}

		Instance = this;
	}

	public void makeExplosionSound(){
		MakeSound (explosionSound);
	}

	public void makePlayerShotSound() {
		MakeSound (playerShotSound);
	}

	public void makeEnemyShotSound() {
		MakeSound (enemyShotSound);
	}

	private void MakeSound(AudioClip audioClip) {
		//this isn't a 3D game so position doesn't really matter.
		AudioSource.PlayClipAtPoint (audioClip, transform.position); 
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
