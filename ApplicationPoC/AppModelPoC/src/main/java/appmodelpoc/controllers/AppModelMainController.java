/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package appmodelpoc.controllers;

import appdatapoc.Entity;
import com.google.gson.Gson;
import com.google.gson.stream.JsonReader;
import com.google.gson.stream.JsonWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;
import java.net.URL;
import java.util.HashMap;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.beans.value.ObservableValue;
import javafx.collections.FXCollections;
import javafx.collections.ListChangeListener;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.Node;
import javafx.scene.control.Button;
import javafx.scene.control.ListView;
import javafx.scene.control.MultipleSelectionModel;
import javafx.scene.control.TextField;
import javafx.stage.FileChooser;
import javafx.stage.FileChooser.ExtensionFilter;

/**
 * FXML Controller class
 *
 * @author AceForce
 */
public class AppModelMainController implements Initializable {

    private Gson gson;

    private HashMap<String, Entity> entities;

    @FXML
    private ListView<String> entityList;
    @FXML
    private TextField entityIDField;
    @FXML
    private Button addEntityButton;
    @FXML
    private Button deleteEntityButton;

    public AppModelMainController() {
        this.gson = new Gson();
        this.entities = new HashMap<>();
    }

    /**
     * Initializes the controller class.
     *
     * @param url
     * @param rb
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        entityList.getSelectionModel().getSelectedItems().addListener((new ListChangeListener<String>() {
            @Override
            public void onChanged(ListChangeListener.Change<? extends String> c) {

                ObservableList<String> selectedItems = entityList.getSelectionModel().getSelectedItems();
                deleteEntityButton.setDisable(selectedItems.isEmpty());

                deleteEntityButton.setText("Delete Entit" + (selectedItems.size() <= 1 ? "y" : "ies"));

            }
        }));
        entityIDField.textProperty().addListener((ObservableValue<? extends String> observable, String oldValue, String newValue) -> {
            examineID();
        });

    }

    @FXML
    protected void addEntity(ActionEvent event) {
        String id = entityIDField.getText().trim();
        entities.put(id, new Entity(id));
        entityList.getItems().add(entityIDField.getText().trim());
        addEntityButton.setDisable(true);
        entityList.getSelectionModel().selectLast();
    }

    @FXML
    protected void deleteEntities(ActionEvent event) {
        MultipleSelectionModel<String> selectionModel = entityList.getSelectionModel();
        ObservableList<String> selectedItems = selectionModel.getSelectedItems();
        selectionModel.getSelectedIndices().forEach((Integer i) -> {
            String id = selectedItems.get(i);
            entities.remove(id);
        });
        entityList.getItems().removeAll(selectedItems);

    }

    @FXML
    protected void saveEntities(ActionEvent event) {
        FileChooser fc = new FileChooser();
        fc.setInitialDirectory(new File(System.getProperty("user.dir")));
        fc.getExtensionFilters().add(new ExtensionFilter("Save as txt for easy looking", "*.txt"));
        File saveFile = fc.showSaveDialog(((Node) event.getTarget()).getScene().getWindow());
        if (null == saveFile) {
            return;
        }

        try (JsonWriter jw = gson.newJsonWriter(new PrintWriter(saveFile))) {
            jw.beginObject();
            jw.name("entities");
            jw.beginArray();
            entities.forEach((String s, Entity e) -> {
                try {
                    jw.beginObject();
                    jw.name("id").value(e.getId());
                    jw.name("speed").value(e.getSpeed());
                    jw.name("spriteName").value(e.getSpriteName());
                    jw.name("isPlayer").value(e.isPlayer());
                    jw.endObject();
                } catch (IOException ex) {
                    Logger.getLogger(AppModelMainController.class.getName()).log(Level.SEVERE, null, ex);
                }
            });
            jw.endArray();
            jw.endObject();

        } catch (FileNotFoundException ex) {
            Logger.getLogger(AppModelMainController.class.getName()).log(Level.SEVERE, null, ex);
        } catch (IOException ex) {
            Logger.getLogger(AppModelMainController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    @FXML
    protected void loadEntities(ActionEvent event) {
        FileChooser fc = new FileChooser();
        fc.setInitialDirectory(new File(System.getProperty("user.dir")));
        fc.getExtensionFilters().add(new ExtensionFilter("Save as txt for easy looking", "*.txt"));
        File loadFile = fc.showOpenDialog(((Node) event.getTarget()).getScene().getWindow());
        if (null == loadFile) {
            return;
        }

        try (JsonReader jr = new JsonReader(new FileReader(loadFile))) {
            HashMap<String, Entity> loadedEntities = new HashMap<>();
            ObservableList<String> loadedEntityList = FXCollections.observableArrayList();
            jr.beginArray();
            String id = "", spriteName = "";
            float speed = 0.0f;
            boolean player = false;
            while (jr.hasNext()) {
                jr.beginObject();
                while (jr.hasNext()) {
                    String name = jr.nextName();
                    switch (name) {
                        case "id":
                            id = jr.nextString();
                            break;
                        case "spriteName":
                            spriteName = jr.nextString();
                            break;
                        case "speed":
                            speed = (float) jr.nextDouble();
                            break;
                        case "isPlayer":
                            player = jr.nextBoolean();
                            break;
                        default:
                            break;
                    }
                }
                jr.endObject();
                Entity e = new Entity(id);
                e.setSpriteName(spriteName);
                e.setSpeed(speed);
                e.setPlayer(player);
                System.out.println(gson.toJson(e));
                loadedEntities.put(id, e);
                loadedEntityList.add(id);
            }
            jr.endArray();
            entities = loadedEntities;
            entityList.setItems(loadedEntityList);
        } catch (IOException ex) {
            Logger.getLogger(AppModelMainController.class.getName()).log(Level.SEVERE, null, ex);
        }

    }

    private void examineID() {
        String id = entityIDField.getText().trim();

        addEntityButton.setDisable(!verifyID(id));
    }

    private boolean verifyID(String id) {
        return !id.isEmpty() && !entities.containsKey(id);
    }

}
