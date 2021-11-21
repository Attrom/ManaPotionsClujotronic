using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : Object
{
    public enum Type : short
    {
        Duration = 0,   // Duration/Size
        Pain = 1,       // Pain/Pleasure 
        Special = 2,  
        Loss = 3,       // Loss/Gain
        Confusion = 4   // Confusion/Clarity
    }
    public enum Target : short
    {
        Hear = 0,
        Visual = 1,
        Smell = 2,
        Taste = 3,
        Life = 4,
        Mind = 5
    }

    public enum Side : short
    {
        Bad = 0,
        Good = 1
    }

    public enum Effects : short
    {
        //Duration
        PartialHearing = 0, // On/Off master volume every few seconds
        PrelongedHearing = 1, // If you have PartialHearing, prelongs the duration in which you hear sounds

        TunnelVision = 2, // Reduces the visual field
        WideVision = 3, // Switch the camera to wide angle

        PersistentStink = 4, // Persistent stink smell, can't drink anymore potions unless they are of Type Loss
        PersistentGoodSmell = 5, // Can drink any potion, overrides the Type Special restriction

        PersistentBadTaste = 6, // Throwup after every drank potion
        PersistentGoodTaste = 7, // Eager to try potions, so eager he will try at random by himself if for 10 seconds you didn't choose any

        ShortLife = 8, // Life Timer is /5
        LongLife = 9, // Life Timer * 2

        ShortMemory = 10, // No longer displays the effects, but they remain active
        GoodMemory = 11, // Every few potions it tells the Target of that potion like "Hmm, I think... I drank this somewhere before... oh, right, I didn't feel my <NOSE> for a week after that!"
        



        //Pain
        AhMyEars = 12, // Emits a continous static noise 
        ASMR = 13, // Plays an ASMR on loop(something nice, not desgusting twitch streamers)

        StrobeLights = 14, // Emits strong flashlights on different random spots on the screen (don't implement, no time, and we have to make sure no epyleptic people play)
        ImYoungAgain = 15, // The mirror reflects only the young version of the character

        BloodyNose = 16, // Cuts down the timer to 3 minutes
        FreshAir = 17, // Adds 1 minute to lifespan left

        BurntTongue = 18, // Refuses to drink anything not BLUE enough, that is Type 3 or above
        GoodTaste = 19, // Has a good taste in mouth and wants to keep it, refuses to drink any potion for the next 20 seconds

        Depressive = 20, // If the next 3 potions have all negative effects he commits sepuku
        Successful = 21, // Happy with what he got so far, doesn't want to find the eternal youth anymore(can walk around the room for the next 10 seconds, after which the game resets(loss))

        Headache = 22, // After every drank potion with Side = Bad, he throws that potion away
        Euphoria = 23,





        //Special //requires PersistentGoodSmell or SmellLess to be able to drink
        SpecialHearingBad = 24,
        SpecialHearingGood = 25,

        OldView = 26, //See spooky stuff
        JackpotView = 27, // All potions with effects that are either, Special, or Life related or Good, shine in a distinct glow

        SpecialSmellBad = 28,
        SpecialSmellGood = 29,

        SpecialTasteBad = 30, 
        SpecialGoodTaste = 31,

        Zombify = 32, //Zombie sounds and gameover
        EternalYouthLife = 33, //Returns to 1st age, timer goes away, all effects dissipate, you win after 15 seconds of free movement in the room

        SpecialBadMind = 34,
        SpecialGoodMind = 35,





        //Loss
        Deaf = 36, //Lose all sounds :(
        Echo = 37, //Hear an echo for all sounds

        Blindness = 38, //Lights out! Can still see UI to reset the game
        ThirdEye = 39, // A third eye appears on the forehead, no real effect, but can be seen in the mirror

        SmellLess = 40, // Allows drinking special Type potions
        StrongSmell = 41, 

        Tasteless = 42,
        Tasteful = 43,

        Die = 44, //Lethal potion
        SecondChance = 45, //Timer resets

        Mindless = 46, //All UI and all dialogues dissapear(except the reset button)
        Mindful = 47, //Gain extra UI containing the R G B values for each color




        //Confusion
        ConfusedSound = 48, // Some SFX on top of all the sounds? like muffled sounds
        ClearSound = 49, // 

        Dizziness = 50, // Dizziness, blur
        ClearVision = 51, //Clear focused vision... on one thing only. Strong magnifier effect

        MixedSmells = 52, // Random potions will gain the "Special" smell restriction
        TheChosenOne = 53, // You are allowed to drink only 1 potion chosen at random

        ConfusedTaste = 54,
        ClearTaste = 55, // After each potion drank say: "Yea, that tasted <Red,Green,Blue>(based on color.maxColorComponent()) !"

        Unsure = 56, //Won't combine 2 potions until you tasted both
        Sure = 57, // Picks 3 potions at random and drinks them in order, if you have the winner potion it prioritzes that one

        Hallucinogenics = 58, //The potions with this Effect could have mushrooms growing on them even before drinking. After drinking, all kinds of rainbow hallucinogenics effects
        Calm = 59, // For 5 seconds all effects go away
    }

    public Target redComponent;
    public Side greenComponent;
    public Type blueComponent;

    public Effects effectName;
}
