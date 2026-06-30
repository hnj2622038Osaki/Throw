using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ライブラリの追加
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // 始まった時に実行する関数
    void Start()
    {
        // ボタンが押された時、StartGame関数を実行
        gameObject.GetComponent<Button>().onClick.AddListener(ReStartGame);
    }
    // StartGame関数
    void Update()
    {

    }
    public void ReStartGame()
    {
        // GameSceneをロード
        SceneManager.LoadScene("GameScene");
    }
}
