using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FlashScript : MonoBehaviour
{

	public Animator anim;

	public GameObject Vaisseau;
	public GameObject Lights;
	public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(Fade());
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("Trigger");
			anim.SetTrigger("AnimTrigger");
			
			StartCoroutine(Fade());
		}
    }

	IEnumerator Fade()
	{
		yield return new WaitForSeconds(8f);
		//anim.SetTrigger("AnimTrigger");
		yield return new WaitForSeconds(4f);
		//Vaisseau.SetActive(true);
		//videoPlayer.Pause();
	}
}
