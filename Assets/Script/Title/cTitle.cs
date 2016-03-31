using UnityEngine;
using UnityEngine.SceneManagement;

public class cTitle : MonoBehaviour
{
    ///<summary> シーン遷移 </summary>
    private FadeManager _fadeManager;
    
    ///<summary> 初期化 </summary>
    void Awake()
    {
        _fadeManager = 
            GameObject.Find("FadeCanvas").
            GetComponent<FadeManager>();
    }

    ///<summary> 画面更新 </summary>
    void Update()
    {
        
        if (TouchManager.TouchBegin()) {
            _fadeManager.SceneChange(GameScene.MAINMENU);
        }
    }
}
