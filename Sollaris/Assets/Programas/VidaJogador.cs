using UnityEngine;
using UnityEngine.Events;

public class VidaJogador : MonoBehaviour
{
    public float vidaMaxima = 100f;
    public float vidaAtual;
    public UnityEvent<float, float> OnVidaAlterada;
    public TelaMorte telaMorte;
    public Transform pontoRespawn;
    private void Start(){
        vidaAtual = vidaMaxima;
        OnVidaAlterada?.Invoke(vidaAtual, vidaMaxima);
    }
    public void TomarDano(float quantidade){
            vidaAtual = vidaAtual - quantidade;
            vidaAtual = Mathf.Clamp(vidaAtual, 0, vidaMaxima);

            OnVidaAlterada?.Invoke(vidaAtual, vidaMaxima);

            if (vidaAtual <= 0){
                Morrer();
            }
    }
        public void Curar(float quantidade){
            vidaAtual = vidaAtual + quantidade;
            vidaAtual = Mathf.Clamp(vidaAtual, 0, vidaMaxima);

            OnVidaAlterada?.Invoke(vidaAtual, vidaMaxima);
        }
        private void Morrer(){
            Debug.Log("O jogador morreu!");
            if(telaMorte != null){
            telaMorte.ExibirTelaMorte(this);
        }
        }
        public void Respawnar(){
            transform.position = pontoRespawn.position;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if(rb != null){
                rb.linearVelocity = Vector2.zero;
            }
            Curar(vidaMaxima/2);
        }


        private void Update(){
            if(Input.GetKeyDown(KeyCode.Space)){
                TomarDano(20f);
            }
        }
    }

