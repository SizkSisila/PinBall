using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    // ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    // スコア関連
    private float Score;                    // 現在のスコア
    private float SmallStarPoint = 10f;     // SmallStarの得点
    private float LargeStarPoint = 20f;     // LargeStarの得点
    private float SmallCloudPoint = 30f;    // SmallCloudの得点
    private float LargeCloudPoint = 50f;    // LargeCloudの得点
    
    // ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    // スコアを表示するテキスト
    private GameObject ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        // シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.ScoreText = GameObject.Find("ScoreText");

        // スコアを初期化
        this.Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // ボールが画面外に出た場合
        if(this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    // オブジェクトとの衝突時の処理
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            // 衝突相手がSmallStarの場合
            case "SmallStarTag":
                this.Score += this.SmallStarPoint;  // 得点加算
                this.ScoreText.GetComponent<Text>().text = "Score:" + this.Score; // UIを更新
                break;
            // 衝突相手がLargeStarの場合
            case "LargeStarTag":
                this.Score += this.LargeStarPoint;  // 得点加算
                this.ScoreText.GetComponent<Text>().text = "Score:" + this.Score; // UIを更新
                break;
            case "SmallCloudTag":
                this.Score += this.SmallCloudPoint;  // 得点加算
                this.ScoreText.GetComponent<Text>().text = "Score:" + this.Score; // UIを更新
                break;
            case "LargeCloudTag":
                this.Score += this.LargeCloudPoint;  // 得点加算
                this.ScoreText.GetComponent<Text>().text = "Score:" + this.Score; // UIを更新
                break;
        }
    }
}
