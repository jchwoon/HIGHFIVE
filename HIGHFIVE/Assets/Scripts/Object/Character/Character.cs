using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : Creature
{
    private enum CursorType
    {
        None,
        Nomal,
        Attack
    }

    private PhotonView _photonView;
    private Texture2D _attackTexture;
    private Texture2D _normalTexture;
    private CursorType _cursorType = CursorType.None;
    public PlayerStateMachine _playerStateMachine;
    public PlayerInput Input { get; protected set; }
    public PlayerAnimationData PlayerAnimationData { get; set; }
    public Animator Animator { get; set; }
    public BuffController BuffController { get; private set; }
    public SkillController SkillController { get; private set; }
    public CharacterSkill CharacterSkill { get; protected set; }

    protected override void Awake()
    {
        base.Awake();
        _photonView = GetComponent<PhotonView>();
        Rigidbody = GetComponent<Rigidbody2D>();
        Input = GetComponent<PlayerInput>();
        Collider = GetComponent<Collider2D>();
        Animator = GetComponentInChildren<Animator>();
        PlayerAnimationData = new PlayerAnimationData();
        BuffController = GetComponent<BuffController>();
        SkillController = GetComponent<SkillController>();
    }
    protected override void Start()
    {
        base.Start();
        _attackTexture = Main.ResourceManager.Load<Texture2D>("Sprites/Cursor/Attack");
        _normalTexture = Main.ResourceManager.Load<Texture2D>("Sprites/Cursor/Normal");
        PlayerAnimationData.Initialize();
        _playerStateMachine = new PlayerStateMachine(this);
        _playerStateMachine.ChangeState(_playerStateMachine._playerIdleState);
        GetComponent<StatController>().dieEvent += OnDie;
    }
    protected override void Update()
    {
        if (_photonView.IsMine)
        {
            _playerStateMachine.HandleInput();
            _playerStateMachine.StateUpdate();
            UpdateMouseCursor();
        }
    }

    protected override void FixedUpdate()
    {
        if(_photonView.IsMine)
        {
            _playerStateMachine.PhysicsUpdate();
        }
    }

    private void UpdateMouseCursor()
    {
        Vector2 mousePoint = _playerStateMachine._player.Input._playerActions.Move.ReadValue<Vector2>();
        Vector2 raymousePoint = Camera.main.ScreenToWorldPoint(mousePoint);

        int mask = (1 << (int)Define.Layer.Monster) | (1 << (Main.GameManager.SelectedCamp == Define.Camp.Red ? (int)Define.Layer.Blue : (int)Define.Layer.Red));

        RaycastHit2D hit = Physics2D.Raycast(raymousePoint, Camera.main.transform.forward, 100.0f, mask);

        if (hit.collider?.gameObject != null || _playerStateMachine.isAttackReady)
        {
            if (_cursorType != CursorType.Attack)
            {
                Cursor.SetCursor(_attackTexture, new Vector2(_attackTexture.width / 5, _attackTexture.height / 10), CursorMode.Auto);
                _cursorType = CursorType.Attack;
            }
        }
        else
        {
            if (_cursorType != CursorType.Nomal)
            {
                Cursor.SetCursor(_normalTexture, new Vector2(_normalTexture.width / 5, _normalTexture.height / 10), CursorMode.Auto);
                _cursorType = CursorType.Nomal;
            }
        }
    }

    
    public void Revival(float respawnTime)
    {
        StartCoroutine(RespawnDelay(respawnTime));
    }

    IEnumerator RespawnDelay(float respawnTime)
    {
        yield return new WaitForSeconds(respawnTime);
        Respawn();
    }

    private void Respawn()
    {
        if (Main.GameManager.page == Define.Page.Battle) return;
        _playerStateMachine._player.transform.position = Main.GameManager.CharacterSpawnPos;
        _playerStateMachine._player.stat.gameObject.GetComponent<PhotonView>().RPC("SetHpRPC", RpcTarget.All, _playerStateMachine._player.stat.MaxHp);
        int layer = Main.GameManager.SelectedCamp == Define.Camp.Red ? (int)Define.Layer.Red : (int)Define.Layer.Blue;
        GetComponent<PhotonView>().RPC("SetLayer", RpcTarget.All, layer);
        _playerStateMachine._player.Collider.isTrigger = false;
        _playerStateMachine._player.Animator.SetBool(_playerStateMachine._player.PlayerAnimationData.DieParameterHash, false);
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }

    private void OnDie()
    {
        _playerStateMachine.ChangeState(_playerStateMachine._playerDieState);
    }

    [PunRPC]
    public void SetLayer(int layer)
    {
        gameObject.layer = layer;
    }

    [PunRPC]
    public void SetHpBarColor()
    {
        Image fillImage = null;
        foreach (Image component in gameObject.GetComponentsInChildren<Image>())
        {
            if (component.name == "Fill")
            {
                fillImage = component;
            }
        }
        if (fillImage != null)
        {
            if (gameObject.layer == (int)Define.Camp.Red)
            {
                fillImage.color = Define.GreenColor;
            }
            else
            {
                fillImage.color = Define.BlueColor;
            }
        }
    }
}
