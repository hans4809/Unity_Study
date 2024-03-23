using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public abstract class UI_Scene : UI_Base
    {
        public override void Init()
        {
            base.Init();
            GameManager.UI.SetCanvas(gameObject, false);
        }
    }
}
