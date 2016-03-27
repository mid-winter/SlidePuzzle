using UnityEngine;
using UnityEngine.SceneManagement;

public class cTitle : MonoBehaviour
{
    ///<summary> シーン遷移 </summary>
    private cSceneMove _sceneMove;

    ///<summary> 初期化 </summary>
    void Awake()
    {
        _sceneMove = GetComponent<cSceneMove>();
    }

    ///<summary> 画面更新 </summary>
    void Update()
    {
        if (Input.touchCount > 0)
        {
            _sceneMove.SceneMove("MainMenu");
        }
    }
}
