using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	private WeaponScript[] weapons;
	private MoveScript movescript;
	private bool hasSpawn;

	void Awake() {
		weapons = GetComponentsInChildren<WeaponScript> ();
		movescript = GetComponent<MoveScript> (); 
	}
	
	// Use this for initialization
	void Start () {
		Spawn (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (hasSpawn == false){
			if( renderer.IsVisibleFrom (Camera.main)) {
				Spawn (true);
			}
		} else {
			foreach (WeaponScript weapon in weapons) {
				if (weapon != null && weapon.CanAttack) {
					weapon.Attack (true);
					SoundEffectsHelper.Instance.makeEnemyShotSound();
				}
			}

			if (!renderer.IsVisibleFrom (Camera.main)) {
				Destroy (gameObject);
			}
		}


	}

	private void Spawn(bool spawn){
		hasSpawn = spawn;
		collider2D.enabled = spawn;
		movescript.enabled = spawn;
		foreach (WeaponScript weapon in weapons) {
			weapon.enabled = spawn;
		}
	}
}
