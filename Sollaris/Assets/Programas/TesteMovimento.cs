using UnityEngine;

public class TesteMovimento : MonoBehaviour

{
    public float velocidade = 5f;
    public SpriteRenderer spriteRenderer;
    public Sprite spriteHomem;
    public Sprite spriteMulher;

    void Start(){
        AtualizarGenero();
    }
    public void AtualizarGenero(){
        string generoEscolhido = PlayerPrefs.GetString("GeneroPlayer", "Homem");
        if(generoEscolhido == "Homem"){
            spriteRenderer.sprite = spriteHomem;
        }
        else if (generoEscolhido == "Mulher"){
            spriteRenderer.sprite = spriteMulher;
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W)){
            transform.Translate(Vector2.up * Time.deltaTime * velocidade);
        }
                if (Input.GetKey(KeyCode.S)){
            transform.Translate(Vector2.down * Time.deltaTime * velocidade);
        }
                if (Input.GetKey(KeyCode.D)){
            transform.Translate(Vector2.right * Time.deltaTime * velocidade);
        }
                if (Input.GetKey(KeyCode.A)){
            transform.Translate(Vector2.left * Time.deltaTime * velocidade);
        }
    }
}
