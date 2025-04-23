using Simva;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

	public void LoadScene (int level)
	{
        if(level == 0)
        {
            string simvaLanguage=LanguageSelector.instance.GetCurrentLanguage();
	    	Debug.Log("Language : "+simvaLanguage);
    		StartCoroutine(Simva.SimvaPlugin.Instance.ManualStart(simvaLanguage));
        } else {
			SceneManager.LoadScene(level);
		}
	}

    public void LoadSceneIfCnfg(int level)
	{
		if (System.IO.File.Exists("host.cfg"))
		{
			LoadScene(level);
		}
	}

	public void LoadSceneIfNotCnfg(int level)
	{
		if (!System.IO.File.Exists("host.cfg"))
		{
			LoadScene(level);
		}
	}

	public void ExitNoConnected() {
		var simvaPlugin = Simva.SimvaPlugin.Instance;
        if (simvaPlugin)
        {
            DestroyImmediate(simvaPlugin.gameObject);
            SimvaManager.Instance.Bridge = null;
        }
		if (Application.isEditor) {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        } else {
            Application.Quit();
        }
	}
}
