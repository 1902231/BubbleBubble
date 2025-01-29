using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//״̬����ö��
public enum Estate
{
    None,
    Idel,
    
}

//<summary>
//Player����
//<summary>
[System.Serializable]
public class Player_State_Paramter : FSM_Parameter
{
    public float idelTime;//����ʱ��
    public float speed;//�ƶ��ٶ�

    public Transform transformP;//��ǰλ��

}

public class PlayerController : MonoBehaviour
{
    FSM fsm;//״̬��ʵ��

    public Player_State_Paramter p = new Player_State_Paramter();//���˲���ʵ��


    PlayerController()
    {

        //��ʼ��״̬��
        fsm = new FSM(p);

        //���״̬
        fsm.AddState(Estate.Idel, new Enemy_State_Idel(fsm));
        fsm.AddState(Estate.Patrol, new Enemy_State_Patrol(fsm));
        fsm.AddState(Estate.Chase, new Enemy_State_Chase(fsm));


        //��ʼ��״̬
        fsm.SwitchState(Estate.Idel);
    }

    private void Update()
    {

        fsm.OnUpdate();
    }

}
