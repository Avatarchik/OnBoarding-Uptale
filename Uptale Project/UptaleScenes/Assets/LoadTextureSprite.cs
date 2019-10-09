using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTextureSprite : MonoBehaviour
{
	public Material material;
	public Sprite sprite;

    void Start()
    {

	}

	private void Update()
	{
		/*material = this.GetComponent<Renderer>().material;
		sprite = Resources.Load<Sprite>("SpriteTableau/sprite.png");
		material.mainTexture = sprite.texture;*/
	}

}
