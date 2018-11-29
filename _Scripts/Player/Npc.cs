using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InsectVillage
{
    public class Npc : RoleBase
    {
        public override void PlayerUpdate()
        {
            base.PlayerUpdate();

            if (isMyMove)
            {
                int step = Random.Range(1, 7);
                StartMoveInit(step);
                isMyMove = false;
            }
        }
    }
}
