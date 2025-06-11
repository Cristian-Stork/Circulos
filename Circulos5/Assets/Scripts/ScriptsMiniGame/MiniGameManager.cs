using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    public Transform pontoA;
    public Transform pontoB;
    public Transform clickArea;
    public GameObject painelMinigame;

    [SerializeField] private Image light1;
    [SerializeField] private Image light2;
    [SerializeField] private Image light3;

    public float velocidadeNormal = 4f;
    public float velocidadeMedia = 7f;
    public float velocidadeRapida = 10f;

    private Transform alvoAtual;
    private int cliquesRestantes = 3;
    private bool velocidadeAumentada = false;
    [SerializeField] private bool jogoAtivo = false;
    private GameObject objMov;
    private Collider2D clickAreaCollider;

    void Start()
    {
        clickAreaCollider = clickArea?.GetComponent<Collider2D>();
        alvoAtual = pontoA;

        // Verificações somente dos elementos fixos na cena
        if (pontoA == null || pontoB == null)
            Debug.LogError("Ponto A ou B não estão atribuídos no Inspector.");
        if (clickArea == null)
            Debug.LogError("ClickArea não foi atribuída no Inspector.");
        if (painelMinigame == null)
            Debug.LogError("PainelMinigame não foi atribuído no Inspector.");
    }

    void Update()
    {
        if (jogoAtivo && objMov != null)
        {
            MoverObjeto();
        }

        if (cliquesRestantes == 3)
        {
            light1.color = Color.red;
            light2.color = Color.red;
            light3.color = Color.red;
        }

        if (cliquesRestantes == 2)
            light1.color = Color.green;

        if (cliquesRestantes == 1)
            light2.color = Color.green;

        if (cliquesRestantes == 0)
            light3.color = Color.green;
    }

    void MoverObjeto()
    {
        float velocidade = 0;

        switch (cliquesRestantes)
        {
            case 3:
                velocidade = velocidadeNormal;
                break;

            case 2:
                velocidade = velocidadeMedia;
                break;

            case 1:
                velocidade = velocidadeRapida;
                break;
        }


        objMov.transform.position = Vector2.MoveTowards(
            objMov.transform.position,
            alvoAtual.position,
            velocidade * Time.deltaTime
        );

        if (Vector2.Distance(objMov.transform.position, alvoAtual.position) < 0.1f)
        {
            alvoAtual = (alvoAtual == pontoA) ? pontoB : pontoA;
        }
    }

    void DetectarClique()
    {
        if (clickAreaCollider != null && clickAreaCollider.OverlapPoint(objMov.transform.position))
        {
            velocidadeAumentada = true;

            float t = Random.Range(0f, 1f);
            clickArea.position = Vector2.Lerp(pontoA.position, pontoB.position, t);

            cliquesRestantes--;
        }

        if (cliquesRestantes == 0)
        {
            jogoAtivo = false;
            VenceuJogo();
        }
    }

    public void AbrirMinigame()
    {
        painelMinigame.SetActive(true);
        ResetarJogo(false); // Apenas prepara, não inicia
    }

    public void Calibrar()
    {
        if (jogoAtivo == false)
        {
            IniciarJogo();
        }

        else
        {
            DetectarClique();
        }
    }

    public void IniciarJogo()
    {
        objMov = GameObject.FindWithTag("ObjMov");

        if (objMov == null)
        {
            Debug.LogError("ObjMov ainda não foi instanciado ou ativado na cena. Verifique se ele existe e tem a tag correta.");
            return;
        }

        ResetarJogo(true); // Agora começa o jogo
    }

    public void FecharMinigame()
    {
        painelMinigame.SetActive(false);
        jogoAtivo = false;
        Manager.instance.ToggleInteracting(true);
    }

    private void ResetarJogo(bool ativar)
    {
        jogoAtivo = ativar;
        cliquesRestantes = 3;
        velocidadeAumentada = false;
        alvoAtual = pontoA;

        if (objMov != null)
            objMov.transform.position = pontoA.position;

        if (clickArea != null)
            clickArea.position = pontoA.position;
    }

    private void VenceuJogo()
    {
        FecharMinigame();
        GetComponent<GameInteraction>().CheckRequirements();
        Debug.Log("Venceu");
    }
}
