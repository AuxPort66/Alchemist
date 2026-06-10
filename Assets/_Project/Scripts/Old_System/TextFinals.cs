using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFinals : MonoBehaviour
{

    internal string finalizardia = "It's getting late, so you decide to go to bed.";
    internal string finalizardiamedicina = "You are so exhausted that you could lie in bed for a couple of days";

    internal string demasiadamedicina = "As a result of drinking that brew, you have blurred vision, strong tremors, an upset stomach, and no feeling in your feet. " +
        "A fear grips you, a fear even more sickening than the one that caused you to abuse of the medicine." +
        "\n\nUnfortunately, it is too late.You were careless.";

    internal string sicksolotrabajar = "When you wake up, you can't even move. Cold sweats, blurred vision, and a ghostly paleness accompany you. " +
        "You've begun to feel the effects of your illness since you stopped taking the medicine. You were so close to finding " +
        "the cure, so many sleepless nights researching, so much work." +
        "\n\nIt is frustrating at first, but little by little you come to accept it, perhaps it was fate. The fatigue overcomes you and you fall asleep again, not knowing if you'll wake up again.";

    internal string sicksocializando = "When you wake up, you can't even move. Cold sweats, blurred vision and a ghostly paleness accompany you. " +
        "You've begun to feel the effects of your illness since you stopped taking the medicine. But you don't seem to mind, because it's better than " +
        "lying in bed for days on end and running yourself full of medication." +
        "\n\nSometimes a short story is better than a long and boring one.Although deep down you hope it was worth it. The fatigue overcomes you and you fall asleep again, not knowing if you'll wake up again.";

    internal string NosickSoloTrabajar = "When you wake up, you can't even move. Cold sweats, blurred vision, and a ghostly paleness accompany you. " +
        "You've begun to feel the effects of your illness since you stopped taking the medicine. You were so close to finding " +
        "the cure, so many sleepless nights researching, so much work, so many days in bed for the medicine" +
        "\n\nIt is frustrating at first, but little by little you come to accept it, perhaps it was fate. The fatigue overcomes you and you fall asleep again, not knowing if you'll wake up again.";

    internal string NosickSocializando = "When you wake up, you can't even move. Cold sweats, blurred vision and a ghostly paleness accompany you. " +
        "You've begun to feel the effects of your illness since you stopped taking the medicine. It disappoints you a little, especially if you remember every day while you're bedridden."+
        "\n\nStill, you're glad that you were able to spend more time with your things. The fatigue overcomes you and you fall asleep again, not knowing if you'll wake up again.";


    internal string finalGatoyCartero = "The postman finds your body and your cat curled up next to you when he delivers the day's orders." +
        "The next day he makes a small funeral and decides to clean your house and adopt Raki." +
        "Every week he brings flowers from your garden to your grave, never too late, he's a postman after all.";

    internal string finalNosuficienteGatoySiCartero = "The postman finds your body when he delivers the day's orders." +
        "The next day he makes a small funeral and decides to clean your house and adopt Raki." +
        "Every week he brings flowers from your garden to your grave, never too late, he's a postman after all.";

    internal string finalNoGatoySiCartero = "The postman finds your body when he delivers the day's orders." +
        "The next day he makes a small funeral and decides to clean your house" +
        "Every week he brings flowers from your garden to your grave, never too late, he's a postman after all.";

    internal string finalSiGatoyNoCartero = "The postman finds your body after hearing your cat meow in despair. " +
        "The next day he holds a small funeral and decides to adopt Raki. Your garden and your house are left to his fate.";

    internal string finalNoGatoyNoCartero = "The postman finds your body a week later and buries you, but there's no great ceremony. Your garden and your house are left to his fate.";

    internal string finalNosuficienteGatoyNoCartero = "The postman finds your body a week later and buries you, but there's no great ceremony. Your cat has long since run away and your garden and your house are left to his fate.";


    private string gato1 = "The cat seems quite calm, but he doesn't trust you. You try to approach him with some food and it seems to work, but he won't let you get close.";
    private string gato2 = "This time you're armed with food and a piece of plant to play with. Raki seems interested and approaches you without much hesitation. He seems to be used to you.";
    private string gato3 = "Without you being able to do too much, Raki climbs onto your table and demands that you scratch him. " +
        "Although you wanted to work, you're very happy and spend the day playing with him.";
    private string gato4 = "Raki climbs on top of you and lies down on your lap, ready to sleep. You decide it's best if you both take a nap and spend the day lying down.";

    private string medicina1 = "The bitter taste of the medicine disgusts you a little, if you find a remedy you'll try to make it a little sweeter. Maybe with a hint of citrus. Besides, it's no fun spending two days in bed either.";
    private string medicina2 = "Your symptoms don't let up, so you drink the medicine again, even though you've barely recovered from the last dose, even if you've to stay in bed for two days.";
    private string medicina3 = "Your symptoms are getting worse, you're more tired every day and you find it harder and harder to get out of bed. " +
        "Assuming the consequences, you go to your bed and with fear open another bottle of medicine. Maybe you calm yourself down with enough of it. " +
        "The bitter taste is no longer unknown to you.";

    private string freetime1 = "You're are a bit tired and would prefer to spend the day reading in your old armchair. Perhaps a cookbook? Or about plants. You've always liked that kind of crafts.";
    private string freetime2 = "With a sigh, you look at your work table and decide to go outside and take care of the garden. Maybe you can apply some of the things you read the other day.";
    private string freetime3 = "You've been thinking for a few days about a kitchen dish you read about the other day. But you don't have all the ingredients. " +
        "It's been a long time since you've been near the town, and the weather is nice. You go for a walk and maybe do some shopping.";
    private string freetime4 = "You spend most of your day cooking. You're an alchemist, but that doesn't mean you can cook everything on the first try. After a few failed attempts, however, you manage to cook something quite good.";

    private string carteroinit1 = "The postman comes to bring you something he'd forgotten. It's not his normal appointment, but he's taken the trouble to bring you in case it was important. He looks a bit tired and it's hot today.";
    private string carteroinit2 = "After a few quiet days you see the postman outside your window. You look out and see that he's playing with a cat. " +
        "Although the cat is in fact clearly attacking his hand, he doesn't seem scared, just grumpy." +
        "\nThe postman looks at you and is happy about his new friend.Apparently this cat has been hanging around your house for days and won't leave, " +
        "no matter how hard the postman tries. He seems worried about whether the cat can take care of itself.";
    private string carteroinit3 = "You got up late and were just about to decide what to do with the rest of the day, " +
        "the postman knocks on your door. He seems to be bringing food. Yesterday he tried to cook a recipe that some ladies in town told him about, " +
        "but he made too much and since he always sees you a bit tired, he decided he could at least give it to you.";
    private string carteroinit4 = "The postman greets you from the window with a smile.";

    internal string carterooption1_1 = "give him water";
    internal string carterooption1_2 = "take your package";
    internal string carterooption2_1 = "keep the cat";
    internal string carterooption2_2 = "you can't take care";
    internal string carterooption3_1 = "invite him in";
    internal string carterooption3_2 = "take the food";
    internal string carterooption4_1 = "invite him in";
    internal string carterooption4_2 = "You're busy";

    private string carterofinishpositive1 = "You invite him in and after serving him something to drink, you tell him a little about the city and he begins with some anecdotes. " +
        "Apparently he once had to deliver a mysterious package. But he leaves the story halfway and promises to finish it another time.";
    private string carterofinishpositive2 = "The postman is very happy and tells you that he's already thought of a name for the cat and that he seems to respond to it. " +
        "Even though it's currently biting the postman's hand. Anyway, you decide to let the cat in and he seems to feel comfortable in his new home. " +
        "He's called Raki.";
    private string carterofinishpositive3 = "You invite him in and you spend the rest of the day talking. He confesses to you that he actually took some herbs from your " +
        "garden because he couldn't find them anywhere and so he brought you some. " +
        "You're a bit annoyed, but the food is so good that in the end you don't care." +
        "\nAfter the meal, you try to treat some of the burns he got from cooking.Maybe you let the cream burn a little more than necessary in revenge for your plants.";
    private string carterofinishpositive4 = "You invite him to spend the day with you, first he wants to do something in the garden, or read a book from your shelf, or even cook. But in the end you talk to each other.";

    private string carterofinishnegative1 = "You are quite busy so you take the package, as soon as you do that the postman leaves without saying too much. It doesn't give you much time to react.";
    private string carterofinishnegative2 = "The postman understands, though he seems a little saddened by the decision. He tries to bring the cat to his house, " +
        "although he'll probably have no luck.";
    private string carterofinishnegative3 = "You take the food and thank him, but I'm too busy to spend the afternoon with him. He doesn't seem to mind though, he seems pleased that you're eating what he's cooked.";
    private string carterofinishnegative4 = "You wave back and he leaves the deliveries for you, not seeming bothered that you're busy.";

    internal string primerdia = "You wake up a little tired, but you want to work for a while. " +
        "You read today's assignments and after making notes on what you need to prepare, you tear up the assignments papers. " +
        "You don't like listening to others talk about their illnesses, it doesn't go well with your own illness, so you prefer this method." +
        "\nYou haven't been to town for a long time, but your orders for ingredients and your medicine have been delayed, maybe it's for the better, " +
        "the medicine always leaves you without energy for two days. You heard a rumour that they changed the postman. " +
        "\nMaybe He can't find your house, it's a bit far away and you don't talk to anyone much lately. But who cares, go to work.";

    public string Gato(int interacciones)
    {
        switch (interacciones)
        {
            case 0:
                return gato1;
            case 1:
                return gato2;
            case 2:
                return gato3;
            default:
                return gato4;
        }
    }

   
    public string Medicina(int interacciones)
    {
        switch (interacciones)
        {
            case 0:
                return medicina1;
            case 1:
                return medicina2;
            default:
                return medicina3;
        }
    }

   
    public string FreeTime(int interacciones)
    {
        switch (interacciones)
        {
            case 0:
                return freetime1;
            case 1:
                return freetime2;
            case 2:
                return freetime3;
            default:
                return freetime4;
        }
    }

    public string Finales(bool sick, bool isgato ,int gato, int cartero, int ocio, int medicina)
    {
        if (isgato)
        {
            if(gato >= 2)
            {
                if (cartero >= 2) return finalGatoyCartero;
                else return finalSiGatoyNoCartero;
            }
            else
            {
                if (cartero >= 2) return finalNosuficienteGatoySiCartero;
                else return finalNosuficienteGatoyNoCartero;
            }
        }
        else
        {
            if (cartero >= 2) return finalNoGatoySiCartero;
            else return finalNoGatoyNoCartero;
        }
    }


    

    public string CarteroInterracionesInicio(int interacciones)
    {
        switch (interacciones)
        {
            case 0: return carteroinit1;
            case 1: return carteroinit2;
            case 2: return carteroinit3;
            default: return carteroinit4;
        }
    }

    public string CarteroOptionsPositive(int interacciones)
    {
        switch (interacciones)
        {
            case 0: return carterooption1_1;
            case 1: return carterooption2_1;
            case 2: return carterooption3_1;
            default: return carterooption4_1;
        }
    }

    public string CarteroOptionsNegative(int interacciones)
    {
        switch (interacciones)
        {
            case 0: return carterooption1_2;
            case 1: return carterooption2_2;
            case 2: return carterooption3_2;
            default: return carterooption4_2;
        }
    }

    public string CarteroInterracionesFinalPositive(int interacciones)
    {
        switch (interacciones)
        {
            case 0: return carterofinishpositive1;
            case 1: return carterofinishpositive2;
            case 2: return carterofinishpositive3;
            default: return carterofinishpositive4;
        }
    }

    public string CarteroInterracionesFinalNegative(int interacciones)
    {
        switch (interacciones)
        {
            case 0: return carterofinishnegative1;
            case 1: return carterofinishnegative2;
            case 2: return carterofinishnegative3;
            default: return carterofinishnegative4;
        }

    }
}
