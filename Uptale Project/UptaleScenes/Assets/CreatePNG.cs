using System.IO;
using UnityEngine;

public class CreatePNG : MonoBehaviour
{
	public int imageWidth = 1024;
	public bool saveAsJPEG = true;
	public Camera cam;
	public string cheminSauvegarde; //= "D:\\UNITY\\OnBoarding - Uptale\\screenshots";

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			Debug.Log("Screen en sauvegarde.");
			byte[] bytes = I360Render.Capture(imageWidth, saveAsJPEG, cam);
			if (bytes != null)
			{
				string path = Path.Combine(cheminSauvegarde, "360render" + (saveAsJPEG ? ".jpeg" : ".png"));
				File.WriteAllBytes(path, bytes);
				Debug.Log("360 render saved to " + path);
			}
		}
	}
}