using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//状态类型枚举
public enum Estate
{
    None,
    Idel,
    
}

//<summary>
//Player参数
//<summary>
[System.Serializable]
public class Player_State_Paramter : FSM_Parameter
{
    public float idelTime;//闲置时间
    public float speed;//移动速度

    public Transform transformP;//当前位置

}

public class PlayerController : MonoBehaviour
{
    FSM fsm;//状态机实例

    public Player_State_Paramter p = new Player_State_Paramter();//敌人参数实例


    PlayerController()
    {

        //初始化状态机
        fsm = new FSM(p);

        //添加状态
        fsm.AddState(Estate.Idel, new Enemy_State_Idel(fsm));
        fsm.AddState(Estate.Patrol, new Enemy_State_Patrol(fsm));
        fsm.AddState(Estate.Chase, new Enemy_State_Chase(fsm));


        //初始化状态
        fsm.SwitchState(Estate.Idel);
    }

    private void Update()
    {

        fsm.OnUpdate();
    }

}
