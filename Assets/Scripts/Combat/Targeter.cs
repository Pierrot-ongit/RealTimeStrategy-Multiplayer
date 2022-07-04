using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Targeter : NetworkBehaviour
{
    private Targetable target;

    #region Server
    public override void OnStartServer()
    {
        GameOverHandler.ServerOnGameOver += ServerHandleGameOver;
    }

    public override void OnStopServer()
    {
        GameOverHandler.ServerOnGameOver -= ServerHandleGameOver;
    }

    [Server]
    private void ServerHandleGameOver()
    {
        ClearTarget();
    }


    [Command]
    public void CmdSetTarget(GameObject targetGameObject)
    {
        if (!targetGameObject.TryGetComponent<Targetable>(out Targetable newTarget)) { return; }

        target = newTarget;
    }


    [Server]
    public void ClearTarget()
    {
        target = null;
    }

    public Targetable GetTarget()
    {
        return target;
    }


    #endregion

    #region Client

    #endregion
}
