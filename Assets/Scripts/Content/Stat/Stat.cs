using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    public List<int> levelExpList = new List<int>();

    private readonly int killExp = 5;
    private int _attack;
    private int _defence;
    private float _attackRange;
    private float _attackSpeed;
    private float _moveSpeed;
    private int _curHp;
    private int _maxHp;
    private float _sightRange;
    private int _exp;
    private int _maxExp;
    private float _attackDelay;
    [HideInInspector]
    public StatController _statController;
    public int CurHp
    {
        get { return _curHp; }
        set 
        {
            if (gameObject == Main.GameManager?.SpawnedCharacter?.gameObject && value == 0)
            {
                _statController.CallDieEvent();
            }
            _statController.CallChangeHpEvent(value, MaxHp);
            _curHp = value; 
        }
    }
    public int MaxHp 
    {
        get { return _maxHp; }
        set { _maxHp = value; }
    }
    public int Attack
    {
        get { return _attack; }
        set { _statController.CallChangeAttackEvent(value); _attack = value; }
    }
    public int Defence
    {
        get { return _defence; }
        set { _statController.CallChangeDefenceEvent(value); _defence = value; }
    }
    public float AttackRange
    {
        get { return _attackRange; }
        set { _attackRange = value; }
    }
    public float AttackSpeed
    {
        get { return _attackSpeed; }
        set {_statController.CallAttackSpeedEvent(value); _attackSpeed = value; }
    }
    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _statController.CallChangeMoveSpeedEvent(value); _moveSpeed = value; }
    }
    public float SightRange
    {
        get { return _sightRange; }
        set { _sightRange = value; }
    }
    public int MaxExp
    {
        get { return _maxExp; }
        set { _maxExp = value; }
    }
    public int Exp 
    {
        get { return _exp; }
        set { _statController.CallChangeExpEvent(value, MaxExp); _exp = value; }
    }
    public float AttackDelay
    {
        get { return _attackDelay; }
        set { _attackDelay = value; }
    }
    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        _statController = Util.GetOrAddComponent<StatController>(gameObject);
        InitializeExp();
    }

    public void Heal(int healAmount)
    {
        Stat myStat = GetComponent<Stat>();
        PhotonView pv = myStat.gameObject.GetComponent<PhotonView>();

        if (myStat.CurHp + healAmount >= myStat.MaxHp)
        {
            myStat.CurHp = myStat.MaxHp;
        }
        else
        {
            myStat.CurHp += healAmount;
        }
        pv.RPC("SetHpRPC", RpcTarget.All, myStat.CurHp, myStat.MaxHp);
    }

    public void TakeDamage(int damage, GameObject shooter, bool isTrueDamage = false) // virtual을 빼봤음
    {
        Stat myStat = GetComponent<Stat>();
        PhotonView pv = myStat.gameObject.GetComponent<PhotonView>();

        int realDamage = Mathf.Max(0, damage - myStat.Defence);
        if (isTrueDamage) { realDamage = Mathf.Max(0, damage); }
        if (myStat.CurHp - realDamage <= 0)
        {
            if (gameObject.tag != "Player")
            {
                shooter.GetComponent<CharacterStat>().AddExp(myStat.Exp, shooter);
                _statController.CallAddBuffEvent(shooter); //레드, 블루, 엘리트 버프 이벤트 실행(구독 되어있는게 있다면)
            }
            if (gameObject.tag == "Player")
            {
                shooter.GetComponent<CharacterStat>().AddExp(GetComponent<CharacterStat>().Level * killExp, shooter);
            }
            myStat.CurHp = 0;
        }
        else
        {
            myStat.CurHp -= realDamage;
        }
        pv.RPC("SetHpRPC", RpcTarget.All, myStat.CurHp, myStat.MaxHp);
    }

    public virtual void TakeDamage(int damage, bool isTrueDamage = false)
    {
        Stat myStat = GetComponent<Stat>();
        
        PhotonView pv = myStat.gameObject.GetComponent<PhotonView>();
        if (pv.IsMine)
        {
            int realDamage = Mathf.Max(0, damage - myStat.Defence);
            if (isTrueDamage) { realDamage = Mathf.Max(0, damage); }
            if (myStat.CurHp - realDamage <= 0)
            {
                myStat.CurHp = 0;
            }
            else
            {
                myStat.CurHp -= realDamage;
            }
            pv.RPC("SetHpRPC", RpcTarget.All, myStat.CurHp, myStat.MaxHp);
        }
    }

    private void InitializeExp()
    {
        int baseExperience = 10;

        // 0번째 인덱스에 0값 추가
        levelExpList.Add(0);

        for (int level = 1; level <= 10; level++)
        {
            levelExpList.Add(baseExperience);
            baseExperience *= 2; // 각 레벨마다 경험치를 2배로 증가
        }
    }
}