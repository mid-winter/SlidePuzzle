using UnityEngine;
using System.Collections;

public class cExit : MonoBehaviour
{
    //初期化
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    //画面更新
    void Update()
    {
        //もしプラットフォームがアンドロイドなら
        if(Application.platform == RuntimePlatform.Android)
        {
            //エスケープキーでアプリ終了
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
                return;
            }
        }
    }
}
