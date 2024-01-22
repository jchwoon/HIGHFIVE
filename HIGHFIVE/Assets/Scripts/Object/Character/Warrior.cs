using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Character
{
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
        stat = Util.GetOrAddComponent<WarriorStat>(gameObject);
    }
    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
