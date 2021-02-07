using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    // HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    // 初期の傾き
    private float defaultAngle = 20;

    //弾いた時の傾き
    private float flickAngle = -20;

    // Start is called before the first frame update
    void Start()
    {
        // HingeJointコンポーネント宇徳
        this.myHingeJoint = GetComponent<HingeJoint>();

        // フリッパーの傾きを設定
        SetAngle(this.defaultAngle);


    }

    // Update is called once per frame
    void Update()
    {
        // 左フリッパーを動かす
        if ((Input.GetKeyDown(KeyCode.LeftArrow)    // 左矢印キーを押したとき
             || Input.GetKeyDown(KeyCode.A)         // Aを押したとき
             || Input.GetKeyDown(KeyCode.S)          // Sを押したとき
             || ( Input.GetMouseButton(0) && Input.mousePosition.x < Screen.width / 2) )   // 画面右側をクリック(タップ)した時
             && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        // 右フリッパーを動かす
        if((Input.GetKeyDown(KeyCode.RightArrow)    // 右矢印キーを押したとき
             || Input.GetKeyDown(KeyCode.D)         // Dを押したとき
             || Input.GetKeyDown(KeyCode.S)         // Sを押したとき
             || ( Input.GetMouseButton(0) && Input.mousePosition.x >= Screen.width / 2) )    // 画面左側をクリック(タップ)した時
            && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        // キーが離されたときフリッパーを元に戻す
        if ((Input.GetKeyUp(KeyCode.LeftArrow)
             || Input.GetKeyUp(KeyCode.A)         // Aを押したとき
             || Input.GetKeyUp(KeyCode.S)         // Sを押したとき
             || Input.GetMouseButtonUp(0))        // クリック(タップ)を離したとき
             && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if((Input.GetKeyUp(KeyCode.RightArrow)
             || Input.GetKeyUp(KeyCode.D)         // Dを押したとき
             || Input.GetKeyUp(KeyCode.S)         // Sを押したとき
             || Input.GetMouseButtonUp(0))        // クリック(タップ)を離したとき
             && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
    }

    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
