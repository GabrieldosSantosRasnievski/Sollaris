using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InventarioJogador : MonoBehaviour
{
    public static InventarioJogador Instance;
    public class ItemSlot{
        public string nomeItem;
        public int quantidadeItem;
        public Sprite iconeItem;
    }
    public List<ItemSlot> slotsRapidos = new List<ItemSlot>();
    public int limiteTiposSlotsRapidos = 9;
    public List<ItemSlot> inventario = new List<ItemSlot>();
    public int limiteTiposInventario = 20;
    private void Awake(){
        if(Instance == null){
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public bool TentarAdicionar(string nomeDoItem, Sprite icone){
        foreach (ItemSlot slot in slotsRapidos){
            if(slot.nomeItem == nomeDoItem){
                slot.quantidadeItem++;
                return true;
            }
        }
        foreach (ItemSlot slot in inventario){
            if(slot.nomeItem == nomeDoItem){
                slot.quantidadeItem++;
                return true;
            }
        }
        if (slotsRapidos.Count < limiteTiposSlotsRapidos){
            ItemSlot novoSlot = new ItemSlot {nomeItem = nomeDoItem, quantidadeItem = 1, iconeItem = icone};
            slotsRapidos.Add(novoSlot);
            return true;
        }
        if(inventario.Count < limiteTiposInventario){
            ItemSlot novoSlot = new ItemSlot {nomeItem = nomeDoItem, quantidadeItem = 1, iconeItem = icone};
            inventario.Add(novoSlot);
            return true;
        }
        return false;
    }
}
