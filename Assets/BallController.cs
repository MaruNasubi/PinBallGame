using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

        //ボールが見える可能性のあるz軸の最大値
        private float visiblePosZ = -6.5f;

        //ゲームオーバを表示するテキスト
        private GameObject gameoverText;

        //得点
        private int text = 0;
        private GameObject　pointText;

        // Use this for initialization
        void Start ()
        {
                //シーン中のGameOverTextオブジェクトを取得
                this.gameoverText = GameObject.Find("GameOverText");
        }



        //衝突時に呼ばれる関数
        void OnCollisionEnter(Collision other)
        {
                /*this.text += 10;
                Debug.Log(this.text);
                this.pointText.GetComponent<Text>().text = this.text.ToString();*/

                // 物理判定の判別
                if (other.gameObject.tag == "SmallStarTag")
                {
                        this.text += 10;
                        Debug.Log("ああああああああああああ");
                        this.pointText.GetComponent<Text>().text = this.text.ToString();
                }
                else if (other.gameObject.tag == "LargeStarTag")
                {
                        this.text += 30;
                        Debug.Log("いいいいいいいいいいいい");
                        this.pointText.GetComponent<Text>().text = this.text.ToString();
                }
                else if(other.gameObject.tag == "SmallCloudTag" || tag == "LargeCloudTag")
                {
                        this.text += 5;
                        Debug.Log("うううううううううううう");
                        this.pointText.GetComponent<Text>().text = this.text.ToString();
                }
        }



        // Update is called once per frame
        void Update ()
        {
                //ボールが画面外に出た場合
                if (this.transform.position.z < this.visiblePosZ)
                {
                        //GameoverTextにゲームオーバを表示
                        this.gameoverText.GetComponent<Text> ().text = "Game Over";
                }

                this.pointText = GameObject.Find("Point");
                /*his.text += 10;
                Debug.Log(this.text);
                this.pointText.GetComponent<Text>().text = this.text.ToString();*/
        }
}