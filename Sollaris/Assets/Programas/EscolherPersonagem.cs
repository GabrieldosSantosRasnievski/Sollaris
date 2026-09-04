using UnityEngine;

public class EscolherPersonagem : MonoBehaviour
{
    public GameObject painelSelecao;

    void Start()
    {
        if (PlayerPrefs.GetInt("Personagem Escolhido", 0) == 1){
            painelSelecao.SetActive(true);
        } 
        else{
           painelSelecao.SetActive(true); 
        }
    }
    public void SelecionarHomem(){
        SalvarEscolha("Homem");
    }

    public void SelecionarMulher(){
        SalvarEscolha("Mulher");
    }

    private void SalvarEscolha(string genero){
        PlayerPrefs.SetString("GeneroPlayer", genero);
        PlayerPrefs.SetInt("PersonagemEscolhido", 1);
        PlayerPrefs.Save();
        painelSelecao.SetActive(false);

        TesteMovimento jogador = FindFirstObjectByType<TesteMovimento>();
        if (jogador != null){
            jogador.AtualizarGenero();
        }
        painelSelecao.SetActive(false);
    }
}
