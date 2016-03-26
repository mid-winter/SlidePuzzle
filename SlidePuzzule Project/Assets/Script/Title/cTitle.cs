using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class cTitle : MonoBehaviour
{

    ///<summary> タッチ </summary>
    private Touch _touch;

    ///<summary> 初期化 </summary>
    void Awake()
    {
    }

    ///<summary> 画面更新 </summary>
    void Update()
    {
        _touch = Input.GetTouch(0);

        if (Input.touchCount > 0)
        {
            if (_touch.phase == TouchPhase.Began)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
