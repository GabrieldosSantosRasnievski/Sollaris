using UnityEngine;

public class AbrirInventario : MonoBehaviour
{
    public GameObject inventario;
    void Update(){
        if(Input.GetKeyDown(KeyCode.B)){
        AlternarInventario();
        }
    }
    public void AlternarInventario(){
        if(inventario != null){
            bool ativar = !inventario.activeSelf;
            inventario.SetActive(ativar);
            if(ativar){
                Time.timeScale = 0f;
            }
            else{
                Time.timeScale = 1f;
            }
        }
    }
}
