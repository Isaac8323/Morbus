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
    public string[,] HabChar = new string[25, 4]; //Nombres de habilidades
    public int[,] HabChars = new int[25, 4]; //Habilidades contra clave
    public int[,] HabCharsPot = new int[25, 4]; //Habilidades convencionales contra clave
    public int[] HChar = new int[25]; //Habilidad convencional

    void Start()
    {
        //Asignación de daño convencional de personajes
        for (int i = 0; i < 7; i++)
        {
            HChar[i] = 4500;
        }
        for (int o = 7; o < 20; o++)
        {
            HChar[o] = 20000;
        }
        for (int n = 20; n < 25; n++)
        {
            HChar[n] = 80000;
        }
        //Aspirina
        HabChar[0, 3] = "Inhibi COX-1";
        HabChar[0, 2] = "Orto fenol";
        HabChar[0, 1] = "Anti fosforilación";
        HabChar[0, 0] = "Inhibe I2";
        //Paracetamol
        HabChar[1, 3] = "Prostaglan redux";
        HabChar[1, 2] = "Inhibi COX";
        HabChar[1, 1] = "AAS attack";
        HabChar[1, 0] = "Proto AM404";
        //Amoxicilina
        HabChar[2, 3] = "Inhibi peptidog";
        HabChar[2, 2] = "Activ estreptoc";
        HabChar[2, 1] = "Optamoxy";
        HabChar[2, 0] = "Curamium";
        //Cloxacilina
        HabChar[3, 3] = "Inhibi transpept";
        HabChar[3, 2] = "Inhibi carboxi";
        HabChar[3, 1] = "Inhibi peptidog";
        HabChar[3, 0] = "Activ Bacillus";
        //Bortezomib
        HabChar[4, 3] = "Citotoxic";
        HabChar[4, 2] = "Tumoral Destroy";
        HabChar[4, 1] = "Inhibi proteasoma";
        HabChar[4, 0] = "26s Destroy";
        //Lenalidomida
        HabChar[5, 3] = "Tumoral Destroy";
        HabChar[5, 2] = "Antiangionetic";
        HabChar[5, 1] = "Linfocitus plus";
        HabChar[5, 0] = "Killer cells";
        //Vorinostat
        HabChar[6, 3] = "Epigenetic mod";
        HabChar[6, 2] = "Histon complex";
        HabChar[6, 1] = "Cromatin back";
        HabChar[6, 0] = "Acetilis destroy";
        //Clavulanato
        HabChar[7, 3] = "Inhibi lactam";
        HabChar[7, 2] = "Resistance down";
        HabChar[7, 1] = "Antimicro activity";
        HabChar[7, 0] = "Self damage";
        //Penicilina
        HabChar[8, 3] = "Bactericide";
        HabChar[8, 2] = "Osmotic pressure";
        HabChar[8, 1] = "Cell division";
        HabChar[8, 0] = "Spheroplasts";
        //Eritromicina
        HabChar[9, 3] = "Macrolide";
        HabChar[9, 2] = "Filip origin";
        HabChar[9, 1] = "Chlamydia Destroy";
        HabChar[9, 0] = "Gastric void";
        //Levofloxacino
        HabChar[10, 3] = "Inhibi somerasa";
        HabChar[10, 2] = "Unwinding chains";
        HabChar[10, 1] = "Packaging ADN";
        HabChar[10, 0] = "Gram positive";
        //Betanecol
        HabChar[11, 3] = "Selective agonist";
        HabChar[11, 2] = "Non Hydrolyzed";
        HabChar[11, 1] = "Urinary retention";
        HabChar[11, 0] = "Cured atony";
        //Metoclopramida
        HabChar[12, 3] = "Gastric void";
        HabChar[12, 2] = "Estasis";
        HabChar[12, 1] = "Bioavailability redux";
        HabChar[12, 0] = "D2 Antagonist";
        //Ibuprofeno
        HabChar[13, 3] = "Antipiretyc action";
        HabChar[13, 2] = "Isomeration";
        HabChar[13, 1] = "Desprotonated";
        HabChar[13, 0] = "Reprotonated";
        //Sulfasalazina
        HabChar[14, 3] = "Immunomodulator";
        HabChar[14, 2] = "Hepatic reverse";
        HabChar[14, 1] = "Secretion delay";
        HabChar[14, 0] = "Sulfabsorb";
        //Prednisolona
        HabChar[15, 3] = "Synthetic cort";
        HabChar[15, 2] = "Gluco effect";
        HabChar[15, 1] = "Inmunosupressor";
        HabChar[15, 0] = "Abrupt dose";
        //Cortisol
        HabChar[16, 3] = "Steroid horm";
        HabChar[16, 2] = "Stress";
        HabChar[16, 1] = "Osseous disform";
        HabChar[16, 0] = "Insulin destroy";
        //Ampicilina
        HabChar[17, 3] = "Betalactamic";
        HabChar[17, 2] = "Beecham origin";
        HabChar[17, 1] = "Higher spectrum";
        HabChar[17, 0] = "Fenil group";
        //Piperacilina
        HabChar[18, 3] = "Betalactamic";
        HabChar[18, 2] = "Extend spectrum";
        HabChar[18, 1] = "Inhibi lactam";
        HabChar[18, 0] = "Gram positive";
        //Tazobactam
        HabChar[19, 3] = "Inhibi lactam";
        HabChar[19, 2] = "Inhibi SHV-1";
        HabChar[19, 1] = "Resistance down";
        HabChar[19, 0] = "Pseudomonas inf";
        //Metilprednisolona
        HabChar[20, 3] = "Synthetic steroid";
        HabChar[20, 2] = "Inmunosupressor";
        HabChar[20, 1] = "anti-inflammatory";
        HabChar[20, 0] = "Inhibi araqui";
        //Hidroxicloroquina
        HabChar[21, 3] = "antimalarial";
        HabChar[21, 2] = "Hydroxil group";
        HabChar[21, 1] = "Antimalarial action";
        HabChar[21, 0] = "ph elevation";
        //H_Sulfasalazina
        HabChar[22, 3] = "EII special";
        HabChar[22, 2] = "5-ASA";
        HabChar[22, 1] = "Inhibi arth";
        HabChar[22, 0] = "Hepatic cicatrizat";
        //Dexametasona
        HabChar[23, 3] = "Glucocorticoid";
        HabChar[23, 2] = "Tumoral Destroy";
        HabChar[23, 1] = "Virilization";
        HabChar[23, 0] = "HPA Axis";
        //Vitamina B12
        HabChar[24, 3] = "WatSoluble";
        HabChar[24, 2] = "ADN Synth";
        HabChar[24, 1] = "Stomach acid";
        HabChar[24, 0] = "C-Co Link";
        //Asignación de valores de xp requerida por nivel
        Exp[0] = 0;
        Exp[1] = 50;
        Exp[2] = 150;
        Exp[3] = 700;
        Exp[4] = 1300;
        Exp[5] = 2300;
        Exp[6] = 4300;
        Exp[7] = 7300;
        Exp[8] = 11300;
        Exp[9] = 16300;
        Exp[10] = 30300;
        Exp[11] = 45300;
        Exp[12] = 64300;
        Exp[13] = 87300;
        Exp[14] = 114300;
        Exp[15] = 145300;
        Exp[16] = 180300;
        Exp[17] = 219300;
        Exp[18] = 266300;
        Exp[19] = 321300;
        Exp[20] = 384300;
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
            atckBoss[x] = 24999; //8333
        }
        for (int g = 5; g < 13; g++)
        {
            atckBoss[g] = 90000; //30000
        }
        for (int b = 13; b < 17; b++)
        {
            atckBoss[b] = 200000; //200000
        }
    }
}
