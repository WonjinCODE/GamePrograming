using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUI_work : MonoBehaviour
{
    Rigidbody rigid;
    public float JumpPower;

    public TMP_InputField input_Mass;
    public TextMeshProUGUI output_Mass_1;
    public TextMeshProUGUI output;

    float mass;
    public TextMeshProUGUI Score;
    int count = 0;
    Vector3 target = new Vector3(11, 1.7f, 0); // Vector3 클래스의 인스턴스 변수 target 선언
    Vector3 velo = Vector3.zero; // (0,0,0) 으로 속도를 0으로 가정 , new 가 붙지 않음

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    public void jump()
    {
        rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    public void Calc_1() // 버튼 UI를 위한 매서드
    {
        if (float.TryParse(input_Mass.text, out mass))
            rigid.mass = mass + 5.0f;
        else
            rigid.mass = 1.0f;
        output_Mass_1.text = rigid.mass.ToString();
        output.text = "+";
    }

    public void Calc_2() // 버튼 UI를 위한 매서드
    {
        if (float.TryParse(input_Mass.text, out mass))
            rigid.mass = mass - 5.0f;
        else
            rigid.mass = 1.0f;
        output_Mass_1.text = rigid.mass.ToString();
        output.text = "-";
    }

    public void Calc_3() // 버튼 UI를 위한 매서드
    {
        if (float.TryParse(input_Mass.text, out mass))
            rigid.mass = mass * 5.0f;
        else
            rigid.mass = 1.0f;
        output_Mass_1.text = rigid.mass.ToString();
        output.text = "X";
    }

    public void Calc_4() // 버튼 UI를 위한 매서드
    {
        if (float.TryParse(input_Mass.text, out mass))
            rigid.mass = mass / 5.0f;
        else
            rigid.mass = 1.0f;
        output_Mass_1.text = rigid.mass.ToString();
        output.text = "/";
    }
    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 vec1 = new Vector3(h, 0, v);
        rigid.AddForce(vec1, ForceMode.Impulse);

        //Score.text = count.ToString();
        //++count;


        if (Input.GetButtonDown("Jump"))
        {
            Vector3 vec = new Vector3(0, JumpPower, 0);
            rigid.AddForce(vec, ForceMode.Impulse);
        }

        else if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Vector3 vec = new Vector3(0, JumpPower, 0);
            rigid.AddForce(vec, ForceMode.Impulse);
        }


    }


}
