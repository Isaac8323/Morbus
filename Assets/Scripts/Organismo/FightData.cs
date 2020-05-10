using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightData : MonoBehaviour
{
    public string[] Organisms = { "Sistema Nervioso", "Sistema Respiratorio", "Sistema Digestivo", "Sistema Inmunológico" };
    public int[] Exp = new int[21];
    public string[] NameBoss = new string[17];
    public string[] DescBoss = new string[17];
    public int[] LifeBoss = new int[17];
    public int[] atckBoss = new int[17];
    void Start()
    {
        //Asignación de valores de xp requerida por nivel
        Exp[0] = 0;
        Exp[1] = 50;
        Exp[2] = 100;
        Exp[3] = 550;
        Exp[4] = 600;
        Exp[5] = 1000;
        Exp[6] = 2000;
        Exp[7] = 3000;
        Exp[8] = 4000;
        Exp[9] = 5000;
        Exp[10] = 14000;
        Exp[11] = 15000;
        Exp[12] = 19000;
        Exp[13] = 23000;
        Exp[14] = 27000;
        Exp[15] = 31000;
        Exp[16] = 35000;
        Exp[17] = 39000;
        Exp[18] = 47000;
        Exp[19] = 55000;
        Exp[20] = 63000;
        //Asignación de nombres de jefes
        NameBoss[0] = "Cefalea";
        NameBoss[1] = "Adenopatía";
        NameBoss[2] = "Linfedema";
        NameBoss[3] = "Linfangitis";
        NameBoss[4] = "Linfoma";
        NameBoss[5] = "Rinosinusitis";
        NameBoss[6] = "Faringoamigdalitis";
        NameBoss[7] = "Difteria";
        NameBoss[8] = "Bronquitis";
        NameBoss[9] = "ERGE";
        NameBoss[10] = "Hemorroides";
        NameBoss[11] = "Colitis Ulcerosa";
        NameBoss[12] = "Cálculos Biliares";
        NameBoss[13] = "Lupus Erimatroso Sistémico";
        NameBoss[14] = "Artritis Reumatoide";
        NameBoss[15] = "Esclerósis múltiple";
        NameBoss[16] = "Anemia perniciosa";
        //Asignación de descripciones de jefe
        DescBoss[0] = "Dolor de cabeza intenso y persistente que va acompañado de sensación de pesadez. Las cefaleas pueden estar relacionadas con la tensión nerviosa.";
        DescBoss[1] = "Glándulas del sistema inmunológico que, por lo general, se agrandan en respuesta a una infección bacteriana o viral.";
        DescBoss[2] = "Inflamación en un brazo o una pierna ocasionada por una obstrucción del sistema linfático.";
        DescBoss[3] = "La linfangitis es una inflamación de los canales linfáticos que ocurre como resultado de una infección en un sitio distal del canal.";
        DescBoss[4] = "El linfoma es un tipo de cáncer del sistema linfático, que es parte de la red del organismo que combate los gérmenes.";
        DescBoss[5] = "La rinosinusitis es una inflamación de las fosas nasales y de los senos paranasales caracterizada por el bloqueo, la obstrucción y/o la congestión nasal sumado a la secreción nasal o rinorrea que puede drenar por la parte anterior o posterior de la nariz.";
        DescBoss[6] = "La faringoamigdalitis es la infección aguda de la faringe o las amígdalas palatinas.";
        DescBoss[7] = "Enfermedad infecciosa aguda, provocada por un bacilo, que afecta a la nariz, la garganta y la laringe y produce fiebre y dificultad para respirar.";
        DescBoss[8] = "Inflamación del revestimiento de los conductos bronquiales que transportan el aire dentro y fuera de los pulmones.";
        DescBoss[9] = "La enfermedad por reflujo gastroesofágico (ERGE) es una afección en la cual los contenidos estomacales se devuelven desde el estómago hacia el esófago (tubo de deglución).";
        DescBoss[10] = "Las hemorroides, también llamadas almorranas, son venas hinchadas en el ano y la parte inferior del recto, similares a las venas varicosas.";
        DescBoss[11] = "La colitis ulcerosa es una enfermedad inflamatoria del colon (el intestino grueso) y del recto.";
        DescBoss[12] = "Los cálculos biliares son acumulaciones sólidas de bilis cristalizada que es producida en el hígado, guardada en la vesícula biliar y secretada hacia el intestino a través de los ductos biliares para ayudar a digerir las grasas.";
        DescBoss[13] = "El lupus eritematoso sistémico (LES) es una enfermedad autoinmunitaria. En esta enfermedad, el sistema inmunitario del cuerpo ataca por error el tejido sano. Este puede afectar la piel, las articulaciones, los riñones, el cerebro y otros órganos.";
        DescBoss[14] = "La artritis reumatoide es una forma de artritis que causa dolor, inflamación, rigidez y pérdida de la función de las articulaciones. Puede afectar cualquier articulación, pero es común en las muñecas y los dedos.";
        DescBoss[15] = "Esclerosis múltiple (o esclerosis en placas) Enfermedad progresiva del sistema nervioso central que provoca lesiones múltiples en la mielina que recubre los axones de las neuronas y constituye la sustancia blanca, en forma de placas diseminadas; se manifiesta con diversos síntomas como la parálisis de las extremidades inferiores, hormigueo, pérdida de la sensibilidad, etc.";
        DescBoss[16] = "La anemia es una afección en la cual el cuerpo no tiene suficientes glóbulos rojos, los cuales le suministran el oxígeno a los tejidos corporales. Hay muchos tipos de anemia. La anemia perniciosa es una disminución en los glóbulos rojos que ocurre cuando los intestinos no pueden absorber apropiadamente la vitamina B12.";
        //Asignación de vida de los jefes 
        LifeBoss[0] = 25000;
        LifeBoss[1] = 150000;
        LifeBoss[2] = 200000;
        LifeBoss[3] = 250000;
        LifeBoss[4] = 300000;
        LifeBoss[5] = 400000;
        LifeBoss[6] = 575000;
        LifeBoss[7] = 650000;
        LifeBoss[8] = 725000;
        LifeBoss[9] = 850000;
        LifeBoss[10] = 975000;
        LifeBoss[11] = 1100000;
        LifeBoss[12] = 1225000;
        LifeBoss[13] = 1450000;
        LifeBoss[14] = 1675000;
        LifeBoss[15] = 1900000;
        LifeBoss[16] = 2500000;
        //Asignación de daño de los jefes
        for (int x = 0; x < 5; x++)
        {
            atckBoss[x] = 8333;
        }
        for (int g = 5; g < 13; g++)
        {
            atckBoss[g] = 30000;
        }
        for (int b = 13; b < 17; b++)
        {
            atckBoss[b] = 200000;
        }
    }
}
