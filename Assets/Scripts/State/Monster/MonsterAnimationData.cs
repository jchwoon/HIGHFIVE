using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimationData
{
    private string isIdleParameterName = "isIdle";
    private string isLeftParameterName = "isLeft";
    private string isRightParameterName = "isRight";
    private string isUpParameterName = "isUp";
    private string isDownParameterName = "isDown";
    private string isAttackParameterName = "isAttack";
    private string isDieParameterName = "isDie";

    private string isMoveParameterName = "isMove";

    public int IdleParameterHash { get; private set; }
    public int LeftParameterHash { get; private set; }
    public int RightParameterHash { get; private set; }
    public int UpParameterHash { get; private set; }
    public int DownParameterHash { get; private set; }
    public int AttackParameterHash { get; private set; }
    public int DieParameterHash { get; private set; }

    public int MoveParameterHash { get; private set; }

    public void GetParameterHash()
    {
        IdleParameterHash = Animator.StringToHash(isIdleParameterName);

        LeftParameterHash = Animator.StringToHash(isLeftParameterName);
        RightParameterHash = Animator.StringToHash(isRightParameterName);
        UpParameterHash = Animator.StringToHash(isUpParameterName);
        DownParameterHash = Animator.StringToHash(isDownParameterName);

        AttackParameterHash = Animator.StringToHash(isAttackParameterName);
        DieParameterHash = Animator.StringToHash(isDieParameterName);

        MoveParameterHash = Animator.StringToHash(isMoveParameterName);
    }
}

