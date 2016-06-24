using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour {

    #region Public And protected Members
    
    public float m_timeBeforeLoadingLevel= 0.5f;
    #endregion

    #region Main Methods

    #endregion
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex+1;
        print( nextSceneIndex );
        if( nextSceneIndex< SceneManager.sceneCountInBuildSettings - 1 )
        {
            m_indexToLoad = nextSceneIndex;
            print( "LoadNextScene "+ m_indexToLoad );
            Invoke( "ExecuteLoadingScene", m_timeBeforeLoadingLevel );
        }
        
    }

    public void LoadSceneByIndex(int _index)
    {

        bool indexIsInRangeOfScene = _index >=0 && _index < SceneManager.sceneCountInBuildSettings;
        if( indexIsInRangeOfScene )
        {
            m_indexToLoad = _index;
            Invoke( "ExecuteLoadingScene", m_timeBeforeLoadingLevel );
        }
        int currentSceneIndex = _index;
        
    }
    public void LoadSceneByName(string _name)
    {
        Scene sceneToLoad = SceneManager.GetSceneByName(_name);

        bool sceneExists = sceneToLoad !=null;

        if( sceneExists )
        {
            m_indexToLoad = sceneToLoad.buildIndex;
            Invoke( "ExecuteLoadingScene", m_timeBeforeLoadingLevel );
        }       
        
    }

    private void ExecuteLoadingScene()
    {
        print( "go "+ m_indexToLoad );
        SceneManager.LoadScene( m_indexToLoad );
    }
    
    #region Private Members
    private int m_indexToLoad;
    
    #endregion
}
