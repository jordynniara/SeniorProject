/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package appdatapoc;

import com.google.gson.JsonObject;

/**
 *
 * @author AceForce
 */
public class Entity {
    private String id;
    
    private float speed;
    
    private String spriteName;
    
    private boolean player;
    
    public Entity(String id) {
        this.id = id;
        speed = 0.0f;
        spriteName = new String();
        player = false;
    }

    /**
     * @return the id
     */
    public String getId() {
        return id;
    }

    /**
     * @param id the id to set
     */
    public void setId(String id) {
        this.id = id;
    }

    /**
     * @return the speed
     */
    public float getSpeed() {
        return speed;
    }

    /**
     * @param speed the speed to set
     */
    public void setSpeed(float speed) {
        this.speed = speed;
    }

    /**
     * @return the spriteName
     */
    public String getSpriteName() {
        return spriteName;
    }

    /**
     * @param spriteName the spriteName to set
     */
    public void setSpriteName(String spriteName) {
        this.spriteName = spriteName;
    }

    /**
     * @return the player
     */
    public boolean isPlayer() {
        return player;
    }

    /**
     * @param player the player to set
     */
    public void setPlayer(boolean player) {
        this.player = player;
    }
}
