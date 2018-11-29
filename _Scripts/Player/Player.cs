using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  玩家
/// </summary>
namespace InsectVillage
{
    public class Player : RoleBase
    {
        public override void PlayerUpdate()
        {
            base.PlayerUpdate();

            if (Input.GetKeyDown(KeyCode.P))
            {
                int step = Random.Range(1, 7);
                StartMoveInit(step);
            }
        }
    }
}
