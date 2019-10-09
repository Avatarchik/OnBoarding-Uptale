using UnityEngine;
using System.Collections;
using System.IO;

public class ConvertPng : MonoBehaviour
{
	public RenderTexture rt;

	[Header("Path pour la sauvegarde. Exemple -> D:\\UNITY\\Uptale\\TextureName.png")]
	[Header("Touche pour générer le rendu en .png : L")]
	[Header("Touche pour générer la cubemap : M")]
	public string cheminSauvegarde; //Example : "D:\\UNITY\\Uptale Project\\UptaleScenes\\Assets\\screenshots\\1Texture.png";

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("Screened");
			Capture();
		}
	}

	public void Capture()
	{
		Texture2D captureTexture = Texture2DGetRenderTexture(rt);

		byte[] data = captureTexture.EncodeToJPG();
		FileStream fs = new FileStream(@cheminSauvegarde, FileMode.OpenOrCreate);

		fs.Write(data, 0, data.Length);
		fs.Close();

		Debug.Log("PNG Image Created.");
	}

	public void Capture(RenderTexture equirect)
	{
		Texture2D captureTexture = Texture2DGetRenderTexture(equirect);

		byte[] data = captureTexture.EncodeToPNG();
		FileStream fs = new FileStream(@cheminSauvegarde, FileMode.OpenOrCreate);

		fs.Write(data, 0, data.Length);
		fs.Close();
		//Texture2D.DestroyImmediate(captureTexture, true);
		Debug.Log("PNG Image Created.");
	}

	public Texture2D Texture2DGetRenderTexture(RenderTexture rt)
	{
		RenderTexture.active = rt;


		Texture2D tempTexture = new Texture2D(rt.width, rt.height);
		tempTexture.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);

		tempTexture.Apply();

		return tempTexture;
	}

}