using UnityEngine;
using System.Collections;

public class cExit : MonoBehaviour
{
    //ダイアログオブジェクト
    private GameObject _dialogObj = null;

    //初期化
    void Awake()
    {
        //オブジェクトが消えないようにする
        DontDestroyOnLoad(gameObject);
        //ダイアログオブジェクトを見つけて消す
        _dialogObj = GameObject.Find("Dialog");
        _dialogObj.SetActive(false);
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
                _dialogObj.SetActive(true);
                return;
            }
        }
    }

    public void YesButton()
    {
        Application.Quit();
    }

    public void NoButton()
    {
        _dialogObj.SetActive(false);
    }
}
