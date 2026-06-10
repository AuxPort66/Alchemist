//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class TextFinalsSpanish : MonoBehaviour
//{
//    internal string finalizardia = "Empieza a ser un poco tarde asi que decides irte a dormir";
//    internal string finalizardiamedicina = "Te sientes exausto, tanto que podrias estar tirado en la cama por un par de dias";

//    internal string demasiadamedicina = "Te has pasado bebiendo ese mejunge, tu vista se ve borrosa y tus temblores son mayores a lo normal, tu estomago está revuelto y no puedes " +
//        "notar tus pies. El miedo se apodera de ti, un miedo peor que el que te llevaba a beber la medicina a un nivel enfermizo. " +
//        "\n\nPero ya es demasiado tarde. Fuiste imprudente";

//    internal string sicksolotrabajar = "Te despiertas pero tan siquiera puedes levantarte, sudores fríos, vista borrosa y una palidez propia de un fantasma " +
//        "te acompañan esta mañana.  Al parecer la enfermedad ha empezado a hacer mella en ti por no tomar la medicina. Justo cuando estabas tan cerca, tantas " +
//        "noches en vela investigando, tanto trabajo para acercarte más a la cura." +
//        "\nAl principio te frustras, pero poco a poco lo asumes, quizás fuera el destino.El cansancio te puede y te vuelves a dormir no sabiendo si despertaras.";

//    internal string sicksocializando = "Te despiertas pero tan siquiera puedes levantarte, sudores fríos, vista borrosa y una palidez propia de un fantasma " +
//        "te acompañan esta mañana.  Al parecer la enfermedad ha empezado a hacer mella en ti por no tomar la medicina. Sin embargo no parece preocuparte, " +
//        "prefieres este resultado que pasar día tras día en la cama, drogado por la medicina." +
//        "\nA veces es mejor un relato corto que uno largo y aburrido.Aunque en el fondo esperas que mereciese la pena. El cansancio te puede y te vuelves a " +
//        "dormir no sabiendo si despertaras.";

//    internal string NosickSoloTrabajar = "Te despiertas pero tan siquiera puedes levantarte, sudores fríos, vista borrosa y una palidez propia de un fantasma " +
//        "te acompañan esta mañana.  Al parecer la enfermedad ha empezado a hacer mella en ti incluso tomando la medicina. Justo cuando estabas tan cerca, " +
//        "tantas noches en vela investigando, tanto trabajo para acercarte más a la cura, tantas noches postrado en la cama por la medicina." +
//        "\nAl principio te frustras, pero poco a poco lo asumes, quizás fuera el destino.El cansancio te puede y te vuelves a dormir no sabiendo si despertaras.";

//    internal string NosickSocializando = "Te despiertas pero tan siquiera puedes levantarte, sudores fríos, vista borrosa y una palidez propia de un fantasma " +
//        "te acompañan esta mañana.  Al parecer la enfermedad ha empezado a hacer mella en ti incluso tomando la medicina. Te decepciona un poco," +
//        " y recuerdas todos los dias postrado en la cama." +
//        "\nAún asi te alegras de haber podido pasar mas tiempo con tus cosas. El cansancio te puede y te vuelves a " +
//        "dormir no sabiendo si despertaras.";

//    internal string finalGatoyCartero = "El cartero encuentra tu cuerpo y a tu gato acurrucado al lado al irte a entregar las peticiones del día a mano. " +
//        "Al día siguiente realiza un pequeño entierro y decide limpiar tu casa y adoptar a Raki. Cada semana lleva flores de tu jardín a tu tumba, " +
//        "no falla ni una, al fin y al cabo es un cartero.";

//    internal string finalNosuficienteGatoySiCartero = "El cartero encuentra tu cuerpo al irte a entregar las peticiones del día a mano. " +
//        "Al día siguiente realiza un pequeño entierro y decide limpiar tu casa y adoptar a Raki. Cada semana lleva flores de tu jardín a tu tumba, " +
//        "no falla ni una, al fin y al cabo es un cartero.";

//    internal string finalNoGatoySiCartero = "El cartero encuentra tu cuerpo al irte a entregar las peticiones del día a mano. " +
//        "Al día siguiente realiza un pequeño entierro y decide limpiar tu casa. Cada semana lleva flores de tu jardín a tu tumba, " +
//        "no falla ni una, al fin y al cabo es un cartero.";

//    internal string finalSiGatoyNoCartero = "El cartero encuentra tu cuerpo tras escuchar a tu gato maullar desesperadamente. " +
//        "Al día siguiente realiza un pequeño entierro y decide adoptar a Raki. Tu jardín y tu casa son abandonados a su suerte.";

//    internal string finalNoGatoyNoCartero = "El cartero encuentra tu cuerpo una semana después, te da entierro pero no hay mucha ceremonia";

//    internal string finalNosuficienteGatoyNoCartero = "El cartero encuentra tu cuerpo una semana después,tu gato se ha escapado ya hace tiempo, " +
//        "te da entierro pero no hay mucha ceremonia.";


//    private string gato1 = "1 encuentro con el gato";
//    private string gato2 = "2 encuentro con el gato";
//    private string gato3 = "3 encuentro con el gato";
//    private string gato4 = "4 encuentro con el gato";

//    private string medicina1 = "1 encuentro con el medicina";
//    private string medicina2 = "2 encuentro con el medicina";
//    private string medicina3 = "3 encuentro con el medicina";

//    private string freetime1 = "1 encuentro con el tiempo libre";
//    private string freetime2 = "2 encuentro con el tiempo libre";
//    private string freetime3 = "3 encuentro con el tiempo libre";
//    private string freetime4 = "4 encuentro con el tiempo libre";

//    private string carteroinit1 = "1 inicio cartero";
//    private string carteroinit2 = "2 inicio cartero";
//    private string carteroinit3 = "3 inicio cartero";
//    private string carteroinit4 = "4 inicio cartero";
//    private string carteroinit5 = "5 inicio cartero";

//    internal string carterooption1_1 = "Opcion 1.1 cartero";
//    internal string carterooption1_2 = "Opcion 1.2 cartero";
//    internal string carterooption2_1 = "Opcion 2.1 cartero";
//    internal string carterooption2_2 = "Opcion 2.2 cartero";
//    internal string carterooption3_1 = "Opcion 3.1 cartero";
//    internal string carterooption3_2 = "Opcion 3.2 cartero";
//    internal string carterooption4_1 = "Opcion 4.1 cartero";
//    internal string carterooption4_2 = "Opcion 4.2 cartero";
//    internal string carterooption5_1 = "Opcion 5.1 cartero";
//    internal string carterooption5_2 = "Opcion 5.2 cartero";

//    private string carterofinishpositive1 = "1 final positivo cartero";
//    private string carterofinishpositive2 = "2 final positivo cartero";
//    private string carterofinishpositive3 = "3 final positivo cartero";
//    private string carterofinishpositive4 = "4 final positivo cartero";
//    private string carterofinishpositive5 = "5 final positivo cartero";

//    private string carterofinishnegative1 = "1 final negativo cartero";
//    private string carterofinishnegative2 = "2 final negativo cartero";
//    private string carterofinishnegative3 = "3 final negativo cartero";
//    private string carterofinishnegative4 = "4 final negativo cartero";
//    private string carterofinishnegative5 = "5 final negativo cartero";
//}
