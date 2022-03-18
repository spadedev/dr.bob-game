using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager Instance;
    
    public GameObject LoadingPanel;
    public Slider slider;
            
    private string targetScene;
	    
    private void Awake()
    {
    	if (Instance == null)
    	{
    		Instance = this;
    		DontDestroyOnLoad(gameObject);		
    	}
    	
    LoadingPanel.SetActive(false);
    }
    	
    public void LoadScene(string sceneName)
    {
    	targetScene = sceneName;
    	StartCoroutine(LoadSceneRoutine());
    }
    
    private IEnumerator LoadSceneRoutine()
    {
    	LoadingPanel.SetActive(true);
    	
    	AsyncOperation op = SceneManager.LoadSceneAsync(targetScene);
    	    	
    	while(!op.isDone)
    	{
    		float progress = Mathf.Clamp01(op.progress / .9f);
    		slider.value = progress;
    		yield return null;
    	}
    	
    	LoadingPanel.SetActive(false);
    }
}
