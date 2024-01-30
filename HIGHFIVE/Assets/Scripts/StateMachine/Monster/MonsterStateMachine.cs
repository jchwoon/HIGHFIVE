using UnityEngine;

public class MonsterStateMachine : StateMachine
{
    public Monster _monster { get; }
    public GameObject targetObject;
    public float Speed;

    public float moveSpeedModifier { get; set; } = 0.5f;
    public MonsterIdleState _monsterIdleState { get; }
    public MonsterMoveState _monsterMoveState { get; }
    public MonsterAttackState _monsterAttackState { get; }
    public MonsterDieState _monsterDieState { get; }
    public MonsterAnimationData _monsterAnimationData { get; }

    public MonsterStateMachine(Monster monster)
    {
        _monster = monster;
        _monsterIdleState = new MonsterIdleState(this);
        _monsterMoveState = new MonsterMoveState(this);
        _monsterAttackState = new MonsterAttackState(this);
        _monsterDieState = new MonsterDieState(this);
        Speed = _monster.stat.MoveSpeed * moveSpeedModifier;
    }
}
