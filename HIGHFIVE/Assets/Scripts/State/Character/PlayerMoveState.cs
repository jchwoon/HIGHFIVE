using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMoveState : PlayerBaseState
{
    private Vector2 _targetPosition;
    private float _moveSpeed;

    public PlayerMoveState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        // 기능
        base.Enter();
        _playerStateMachine.moveSpeedModifier = 1.0f;
        Debug.Log("Move Enter");
        // 애니메이션 호출
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Move Exit");
        // 애니메이션 해제
    }

    public override void StateUpdate()
    {
        base.StateUpdate();

        //타겟팅이 있다면 공격 스테이트로 변환
        //없다면 return
        Move();
    }

    private void Move()
    { 
        if (Mouse.current.rightButton.isPressed)
        {
            _targetPosition = GetMoveDirection();
            _moveSpeed = GetMoveSpeed();
        }
        _playerStateMachine._player.transform.position = Vector3.MoveTowards(_playerStateMachine._player.transform.position, _targetPosition, _moveSpeed * Time.deltaTime);

        Debug.Log(_targetObject);
        if (_targetObject != null)
        {
            float distance = (_targetObject.transform.position - _playerStateMachine._player.transform.position).magnitude;

            Debug.Log(distance);
            Debug.Log(_playerStateMachine._player.stat.AttackRange);
            if (_playerStateMachine._player.stat.AttackRange > distance)
            {
                _playerStateMachine.ChangeState(_playerStateMachine._playerAttackState);
            }
        }
        

        if (_targetPosition == (Vector2)_playerStateMachine._player.transform.position)
        {
            _playerStateMachine.ChangeState(_playerStateMachine._playerIdleState);
        }
    }

    private float GetMoveSpeed()
    {
        float movementSpeed = _playerStateMachine._player.stat.MoveSpeed * _playerStateMachine.moveSpeedModifier;
        return movementSpeed;
    }

    private Vector2 GetMoveDirection()
    {
        Vector2 input = _playerStateMachine.moveInput;
        return new Vector2(input.x, input.y);
    }
}
