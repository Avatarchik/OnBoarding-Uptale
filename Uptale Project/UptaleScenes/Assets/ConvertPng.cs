using UnityEngine;
using System.Collections;
using System.IO;

public class ConvertPng : MonoBehaviour
{

	//public Texture2D MyOldText;

	//public int resWidth = 1920;
	//public int resHeight = 1080;

	public RenderTexture rt;
	public Texture2D tempTexture;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("Screened");
			Capture();
		}
	}

	void Capture()
	{
		Texture2D captureTexture = Texture2DGetRenderTexture(rt);

		byte[] data = captureTexture.EncodeToPNG();
		FileStream fs = new FileStream(@"D:\UNITY\Uptale Project\UptaleScenes\Assets\screenshots\texturePNG.png", FileMode.OpenOrCreate);
		fs.Write(data, 0, data.Length);
		fs.Close();
		//Texture2D.DestroyImmediate(captureTexture, true);
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

	/*void Update()
	{

	
		if (Input.GetKeyDown(KeyCode.Space))
		{
			
		}

		Texture2D texture2D = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);

		RenderTexture currentRT = RenderTexture.active;

		//RenderTexture renderTexture = new RenderTexture(mainTexture.width, mainTexture.height, 32);
		//Graphics.Blit(mainTexture, renderTexture);

		RenderTexture.active = mainTexture;
		texture2D.ReadPixels(new Rect(0, 0, mainTexture.width, mainTexture.height), 0, 0);
		texture2D.Apply();

		Color[] pixels = texture2D.GetPixels();

		RenderTexture.active = currentRT;

		string filename = ScreenShotName(resWidth, resHeight);
		byte[] bytes = mainTexture.EncodeToPNG();
		System.IO.File.WriteAllBytes(filename, bytes);
		Debug.Log(string.Format("Took screenshot to: {0}", filename));
		takeHiResShot = false;
	}*/

	/*public static string ScreenShotName(int width, int height)
	{
		return string.Format("{0}/screenshots/screen_{1}x{2}_{3}.png",
							 Application.dataPath,
							 width, height,
							 System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
	}
	public void TakeHiResShot()
	{
		takeHiResShot = true;
	}
}*/

	
/*
	

	void LateUpdate()
	{
		takeHiResShot |= Input.GetKeyDown("k");
		if (takeHiResShot)
		{
			Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
			RenderTexture.active = rt;
			screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
			RenderTexture.active = null; // JC: added to avoid errors
			byte[] bytes = screenShot.EncodeToPNG();
			string filename = ScreenShotName(resWidth, resHeight);
			System.IO.File.WriteAllBytes(filename, bytes);
			Debug.Log(string.Format("Took screenshot to: {0}", filename));
			takeHiResShot = false;
		}
	}*/
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertPng : MonoBehaviour
{

	public RenderTexture tex;
	public Texture2D myTexture2D;

	void Update()
    {
		myTexture2D = toTexture2D(tex);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("Application texture.");
			myTexture2D = toTexture2D(tex);
		}
	}

	Texture2D toTexture2D(RenderTexture rTex)
	{
		Texture2D tex = new Texture2D(512, 512, TextureFormat.RGB24, false);
		RenderTexture.active = rTex;
		tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
		tex.Apply();
		return tex;
	}
}*/
