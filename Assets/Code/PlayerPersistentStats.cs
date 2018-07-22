using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPersistentStats {

    private static PlayerPersistentStats playerPersistentStats;

    private float pX,pY;

    public static PlayerPersistentStats GetPlayerPersistentStats() {
        if(playerPersistentStats == null) {
            playerPersistentStats = new PlayerPersistentStats();
        }
        return playerPersistentStats;
    }

	public float GetPX() {
        return pX;
    }

    public float GetPY() {
        return pY;
    }

    public void SetPX(float pX) {
        this.pX = pX;
    }

    public void SetPY(float pY) {
        this.pY = pY;
    }
}
