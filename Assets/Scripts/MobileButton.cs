using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileButton : MonoBehaviour {

    public Player player;
    public string direction;

	

    private void OnMouseDown() {

        player.Move(direction);
        
    }
}
