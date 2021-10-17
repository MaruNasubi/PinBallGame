using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
        //HingeJointコンポーネントを入れる
        private HingeJoint myHingeJoint;

        //初期の傾き
        private float defaultAngle = 20;
        //弾いた時の傾き
        private float flickAngle = -20;

        // Use this for initialization
        void Start ()
        {
                //HingeJointコンポーネント取得
                this.myHingeJoint = GetComponent<HingeJoint>();

                //フリッパーの傾きを設定
                SetAngle(this.defaultAngle);
        }

        // Update is called once per frame
        void Update ()
        {
                if(Input.touchCount == 0)
                {
                        Debug.Log("離れている");
                        if(tag == "LeftFripperTag" || tag == "RightFripperTag")
                        {
                                SetAngle (this.defaultAngle);
                        }
                }
                else if (Input.touchCount > 0)
                {
                        //このフレームでのタッチ情報を取得
                        Touch[] myTouches = Input.touches;

                        //検出されている指の数だけ回して
                        for (int i = 0; i < myTouches.Length; i++)
                        {
                                Debug.Log(myTouches[i].position.x);
                                if((myTouches[i].position.x <= Screen.width / 2) && tag == "LeftFripperTag")
                                {
                                        Debug.Log("左");
                                        SetAngle(this.flickAngle);
                                }
                                else if((myTouches[i].position.x >= Screen.width / 2) && tag == "RightFripperTag")
                                {
                                        Debug.Log("右");
                                        SetAngle(this.flickAngle);
                                }
                        }
                }
        }

         //フリッパーの傾きを設定
        public void SetAngle (float angle)
        {
                JointSpring jointSpr = this.myHingeJoint.spring;
                jointSpr.targetPosition = angle;
                this.myHingeJoint.spring = jointSpr;
        }
}