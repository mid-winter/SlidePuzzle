using UnityEngine;
using UnityEngine.SceneManagement;

public class cSceneMove : MonoBehaviour {

    ///<summary> タイトルへシーン遷移移行処理 </summary>
    public void SceneMove(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
