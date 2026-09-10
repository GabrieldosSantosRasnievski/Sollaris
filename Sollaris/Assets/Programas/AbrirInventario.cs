using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class AbrirInventario : MonoBehaviour
{
    public GameObject painelInventario;
    public List<TextMeshProUGUI>textosSlotsRapidos;
    public List<Image> imagensSlotsRapidos;
    public List<TextMeshProUGUI>textosSlotsInventario;
    public List<Image> imagensSlotsInventario;
    void Update(){
        if(Input.GetKeyDown(KeyCode.B)){
        AlternarInventario();
        }
        AtualizarUI();
    }
    public void AlternarInventario(){
        if(painelInventario != null){
            bool ativar = !painelInventario.activeSelf;
            painelInventario.SetActive(ativar);
            if(ativar){
                Time.timeScale = 0f;
            }
            else{
                Time.timeScale = 1f;
            }
        }
    }
    public void AtualizarUI(){
        if(InventarioJogador.Instance == null){
            return;
        }
        for(int i = 0; i < textosSlotsRapidos.Count; i++){
            if(i < InventarioJogador.Instance.slotsRapidos.Count){
                var slot = InventarioJogador.Instance.slotsRapidos[i];
                if(slot.quantidadeItem > 1){
                    textosSlotsRapidos[i].text = slot.nomeItem + "\nx" + slot.quantidadeItem;
                }
                else{
                    textosSlotsRapidos[i].text = slot.nomeItem;
                }
                if(i < imagensSlotsRapidos.Count && imagensSlotsRapidos[i] != null){
                    imagensSlotsRapidos[i].sprite = slot.iconeItem;
                    imagensSlotsRapidos[i].enabled = true;
                }
            }
            else{
                if(textosSlotsRapidos[i] != null){
                    textosSlotsRapidos[i].text = "";
                }
                if(i < imagensSlotsRapidos.Count && imagensSlotsRapidos[i] != null){
                    imagensSlotsRapidos[i].sprite = null;
                    imagensSlotsRapidos[i].enabled = false;
                }
            }
        }
        for(int i = 0; i < InventarioJogador.Instance.inventario.Count; i++){
            if(i < InventarioJogador.Instance.inventario.Count){
                var slot = InventarioJogador.Instance.inventario[i];
                if(slot.quantidadeItem > 1){
                textosSlotsInventario[i].text = slot.nomeItem + "\nx" + slot.quantidadeItem;
                }
                else{
                    textosSlotsInventario[i].text = slot.nomeItem;
                }
                if(i < imagensSlotsInventario.Count && imagensSlotsInventario != null)
                {
                    imagensSlotsInventario[i].sprite = slot.iconeItem;
                    imagensSlotsInventario[i].enabled = true;
                }
            }
            else{
                if(textosSlotsInventario[i] != null){
                    textosSlotsInventario[i].text = "";
                }
                if(i < imagensSlotsInventario.Count && imagensSlotsInventario[i] != null){
                    imagensSlotsInventario[i].sprite = null;
                    imagensSlotsInventario[i].enabled = false;
                }
            }
        }
    }
}
