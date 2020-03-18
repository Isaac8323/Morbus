using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    public static string sceneToLoad;

    [SerializeField]
    private Text percentText;

    [SerializeField]
    private Image progressImage;

    [SerializeField]
    private GameObject backmusic;

    Text Title, Hint;

    private string[] titulos = new string[16];
    private string[] consejos = new string[16];

    private void HintGen()
    {
        titulos[0] = "Adenopatía (ganglios inflamados por infeccion).";
        consejos[0] = "Se emplean como farmacos de eleccion cloxacilina o amoxicilina-clavulánico. Otras alternativas son clindamicina , cefalosporinas de primera o segunda generacion.";
        titulos[1] = "Linfedema";
        consejos[1] = "En casos leves se puede administrar el antibiotico: Amoxicilina-Clavulanico(Augmentine® 875 / 8h 8 dias), Cloxacilina(Orbenin® 500 / 6h 8 días). En caso de alergia a penicilinas se pueden dar macrolidos: Claritromicinao, Azitromicina o Eritromicina";
        titulos[2] = "Linfangitis";
        consejos[2] = "La mayoria de las personas se curan rapidamente con antibioticos efectivos contra los estafilococos y los estreptococos, como dicloxacilina, nafcilina u oxacilina.";
        titulos[3] = "Linfoma";
        consejos[3] = "Existen nuevos medicamentos en desarrollo contra el linfoma B. Algunos son farmacos ya comercializados que se han utilizado con exito frente al mieloma multiple, como bortezomib (Velcade®) o lenalidomida (Revlimid®), en otros tumores solidos como bevacizumab (Avastin®) que han de encontrar su lugar en el tratamiento del LBDCG por medio de ensayos clinicos y otros en investigacion como vorinostat, enzastaurina, fostamatinib, etc.";
        titulos[4] = "Rinosinusitis";
        consejos[4] = "El objetivo principal del tratamiento antibiotico de la rinosinusitis aguda bacteriana es acortar la evolucion. Pacientes de bajo riesgo (para resistencia antibiotica) a quienes se les haya iniciado un tratamiento antibiotico a base de amoxicilina a dosis habitual, cambiar el esquema amoxicilina con clavulanato a dosis alta y reevaluar en las siguientes 48 horas. La falta de mejoría justifica la valoración por segundo nivel de atención. 2 Pacientes de alto riesgo (para resistencia antibiotica) a quienes se les haya iniciado amoxicilina con clavulanato a dosis altas ameritan cambio a segunda linea de la enfermedad y disminuir el riesgo de complicaciones supurativas";
        titulos[5] = "Faringoamigdalitis";
        consejos[5] = "El tratamiento de erradicacion sera penicilina benzatinica de 1,200,000 UI cada 21 días a partir de la primera aplicacion de la penicilina compuesta (recomendada en el tratamiento inicial) por 3 meses.";
        titulos[6] = "Difteria";
        consejos[6] = "La difteria tambien se trata con antibioticos, como la penicilina o la eritromicina. Los antibioticos ayudan a eliminar las bacterias del cuerpo y curan las infecciones. Los antibioticos reducen a unos pocos dias el periodo en el que una persona con difteria puede contagiar la enfermedad.";
        titulos[7] = "Bronquitis";
        consejos[7] = "Amoxicilina/acido-clavulanico 500/125 mg/8h, 5-7 dias. Solo en casos de alergia: levofloxacino 500mg/24h, 5 dias";
        titulos[8] = "Reflujo Gastroesofagico";
        consejos[8] = "Segun se ha comprobado, los antibioticos, incluido uno llamado eritromicina, mejoran el vaciamiento gastrico. La eritromicina tiene menos efectos secundarios que el betanecol y la metoclopramida; no obstante, como todos los antibioticos, puede causar diarrea.";
        titulos[9] = "Hemorroides";
        consejos[9] = "Para aliviar las molestias, se puede tomar paracetamol (Tylenol, otros), aspirina o ibuprofeno (Advil, Motrin IB, otros) temporalmente.";
        titulos[10] = "Colitis ulcerosa";
        consejos[10] = "tratamiento de la colitis ulcerosa. Algunos de ellos son: 5-aminosalicilatos. Los ejemplos de este tipo de medicamento son la sulfasalazina(Azulfidine), la mesalazina(Asacol HD, Delzicol, otros), la balsalazida(Colazal) y la olsalazina(Dipentum). El medicamento que tomes, y si lo debes administrar por via oral o como enema o supositorio, dependera de la zona del colon que este afectada. Corticoesteroides. Estos medicamentos, que pueden ser la prednisona y la hidrocortisona, generalmente se reservan para la colitis ulcerosa moderada a grave que no responde a otros tratamientos. Debido a los efectos secundarios, no se suelen administrar a largo plazo";
        titulos[11] = "Calculos Biliares";
        consejos[11] = "Opciones de tratamiento antibiotico empirico para cubrir germenes gram negativos y anaerobios: /Monoterapia/ - Ampicilina - sulbactam(3 g / 6 h). Piperacilina - tazobactam(4, 5 g / 6 h). Ticarcilina - clavulánico(3, 1 g / 4 h). /Terapia combinada/ Cefalosporina de 3.ª gen. (ej: ceftriaxona 1 g / 24 h) + metronidazol(1, 5 g / 24 h iv). /Pautas alternativas(de segunda elección)/.  Fluorquinolona(ej: levofloxacino / 24 h) + Metronidazol(1, 5 g / 24 h iv). /Monoterapia con carbapenem/ (imipenem500 g / 6 h, meropenem 1 g / 8 h o ertapenem 1 g / 24 h).";
        titulos[12] = "Lupus eritematoso sistemico";
        consejos[12] = "Existen muchas clases de medicamentos para el tratamiento del lupus. De todos estos medicamentos, solo algunos han sido aprobados para el tratamiento especifico del lupus por la Administracion de Drogas y Alimentos de los Estados Unidos (Food and Drug Administration, FDA): Los corticosteroides, entre los que se incluyen la prednisona, la prednisolona, la metilprednisolona y la hidrocortisona; Los antipaludicos o antimalarico, hidroxicloroquina (Plaquenil®); El belimumab(un tratamiento biologico)";
        titulos[13] = "Artritis reumatoide";
        consejos[13] = "La sulfasalazina, (Azulfidine) es una combinacion farmacologica de antibiotico y de antiinflamatorio, utilizada para tratar la AR. Los efectos secundarios pueden incluir erupciones cutneas, malestar gastrico, dolores de cabeza, disminucion en el conteo de globulos blancos y plaquetas. Tambien puede tener efectos negativos para el higado. Las personas alergicas a medicamentos con sulfa no pueden tomar sulfasalazina";
        titulos[14] = "Esclerosis multiple";
        consejos[14] = "Tratamiento del brote: El brote es un concepto clinico definido como la aparicion de sintomas o signos de disfuncion neurologica de instauracion aguda y con una duracion minima de 24 horas, o bien un deterioro significativo de sintomas neurologicos preexistentes que habian estado estables o ausentes durante al menos 30 dias en ausencia de fiebre o infeccion. Identificar correctamente el brote es clave para poder establecer el diagnostico y plantear un correcto abordaje terapeutico.La sintomatologia del brote es la expresion de una o varias lesiones fruto de un proceso inflamatorio localizado en el SNC y, por ello, su tratamiento esta enfocado a controlar el proceso inflamatorio, especialmente con corticosteroides; Corticosteroides, Metilprednisolona, ACTH, Dexametasona, Plasmaféresis, Inmunoglobulina G intravenosa";
        titulos[15] = "Anemia Perniciosa";
        consejos[15] = "En este caso el tratamiento definitivo para corregir la deficiencia de vitamina B12 consiste en inyecciones mensuales de la misma. Esta terapia corrige tanto la anemia como posibles complicaciones neurológicas si es administrada a tiempo.";
        System.Random rnd = new System.Random();
        int num = rnd.Next(0, 16);
        Title = GameObject.Find("Title").GetComponentInChildren<Text>();
        Title.text = titulos[num];
        Hint = GameObject.Find("Hint").GetComponentInChildren<Text>();
        Hint.text = consejos[num];
    }

    void Start()
    {
        HintGen();
        backmusic.SetActive(false);
        StartCoroutine(LoadScenes());
    }

    IEnumerator LoadScenes()
    {
        AsyncOperation loading;

        //Iniciamos la carga asíncrona de la escena y guardamos el proceso en 'loading'
        loading = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Single);

        //Bloqueamos el salto automático entre escenas para asegurarnos el control durante el proceso
        loading.allowSceneActivation = false;

        //Cuando la escena llega al 90% de carga, se produce el cambio de escena
        while (loading.progress < 0.9f)
        {

            //Actualizamos el % de carga de una forma optima 
            //(concatenar con + tiene un alto coste en el rendimiento)
            percentText.text = (((int)(loading.progress * 100)).ToString()) + "%";

            //Actualizamos la barra de carga
            progressImage.fillAmount = loading.progress;

            //Esperamos un frame
            yield return null;
        }
        //Mostramos la carga como finalizada
        percentText.text = "100%";
        progressImage.fillAmount = 1;

        yield return new WaitForSeconds(3);

        //Activamos el salto de escena.
        loading.allowSceneActivation = true;
    }
}
