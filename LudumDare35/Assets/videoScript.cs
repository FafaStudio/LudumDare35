using UnityEngine;
using System.Collections;

public class videoScript : MonoBehaviour {

	public MovieTexture movieclips;
	private MeshRenderer meshRenderer;


	void Start(){
		meshRenderer = GetComponent<MeshRenderer>();
		meshRenderer.material.mainTexture = movieclips;

		//AudioSource audio = GetComponent<AudioSource>();
		//audio.Play();

		movieclips.Play ();
	}
}
