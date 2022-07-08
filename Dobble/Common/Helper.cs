// Include namespace system
using System;
using System.Collections.Generic;



// This class are provide by kalkicode.com
public class Settlement
{
    // Get random number between [0.0 to 1.0]
    public static double MathRandom()
    {
        return (new Random()).NextDouble();
    }
}

// *
// * @author Cristopher Angulo
// * @implNote Helper to use in all application to do generic operations
public class Helper
{
    // *
    //     * @implNote static method to generate random number
    //     * @param min minimum integer value
    //     * @param max maximum integer value
    //     * @return a random number between inputs number
    public static int generateRandomNumber(int min, int max)
    {
        return (int)(Settlement.MathRandom() * (max - min + 1) + min);
    }
    // *
    //     * @implNote static method to generate random elements with a database in memory defined in list of objects
    //     * @param total number of elements
    //     * @return element list generated randomly
    public static List<Object> generateRandomElements(int total)
    {
        var elements = new List<Object>();
        var baseElements = new List<Object>();
        baseElements.Add("Bear\'s");
        baseElements.Add("Tiger\'s");
        baseElements.Add("Wolf\'s");
        baseElements.Add("Bee\'s");
        baseElements.Add("Car\'s");
        baseElements.Add("Dog\'s");
        baseElements.Add("Snake\'s");
        baseElements.Add("Python\'s");
        baseElements.Add("Lion\'s");
        baseElements.Add("Spider\'s");
        var positions = new List<Object>();
        positions.Add("with");
        positions.Add("on");
        positions.Add("in");
        positions.Add("beside");
        positions.Add("above");
        positions.Add("in front of");
        positions.Add("under");
        positions.Add("behind");
        positions.Add("next to");
        var objects = new List<Object>();
        objects.Add("Computer");
        objects.Add("Book");
        objects.Add("Ball");
        objects.Add("Guitar");
        objects.Add("Jacket");
        objects.Add("Shirt");
        objects.Add("Sweater");
        objects.Add("Table");
        objects.Add("Chair");
        objects.Add("Flower");
        for (int i = 0; i < total; i++)
        {
            var baseElement = baseElements[generateRandomNumber(0, 9)];
            var position = positions[generateRandomNumber(0, 8)];
            var element = objects[generateRandomNumber(0, 9)];
            elements.Add(generateRandomNumber(1, 10).ToString() + " " + string.Join(", ", baseElement) + " " +
                string.Join(", ", position) + " " + string.Join(", ", element));
        }
        return elements;
    }
    // *
    //     * @implNote static method to validate total cards to create dobble cards
    //     * @param totalCards number of cards
    //     * @param elementsPerCard number of distinct elements that we identify for each card
    //     * @param totalCardsAuxiliary  number of cards auxiliary
    //     * @return return true if is valid total cards or  false if is the opposite
    public static bool isValidTotalCards(int totalCards, int elementsPerCard, int totalCardsAuxiliary)
    {
        return (totalCardsAuxiliary >= totalCards && totalCards > 0) ? true : false;
    }


    // *
    //     * @implNote static method to validate the order of projective plane in order to create cardsSet
    //     * the result It must be prime integer to return true
    //     * @param order number of order
    //     * @return valid if order of deck is valid
    public static bool isValidOrder(int order)
    {
        if (order <= 1)
        {
            return false;
        }
        for (int i = 2; i <= (int)(order / 2); i++)
        {
            if ((order % i) == 0)
            {
                return false;
            }
        }
        return true;
    }
}