using System.ComponentModel.Design;
using WarehousingMockUp;

internal class Program
{

    private static void Main(string[] args)
    {
        //Initialize data lists.
        Data databaseMockUp = new Data();
        int[,] chairComponents = new int[3, 2];
        int[,] tableComponents = new int[3, 2];
        //Fill in data lists.
        databaseMockUp.AddToMasterList(new MaterialMaster(0, "screw", "screws to hold things together", true));
        databaseMockUp.AddToMasterList(new MaterialMaster(1, "leg", "legs to keep a platform elevated", true));
        databaseMockUp.AddToMasterList(new MaterialMaster(2, "seat", "seat to hold a person", true));
        databaseMockUp.AddToMasterList(new MaterialMaster(3, "tabletop", "the main component for a table, or a stool for a giant", true));
        databaseMockUp.AddToMasterList(new MaterialMaster(4, "dining chair", "a seat for a person", false));
        databaseMockUp.AddToMasterList(new MaterialMaster(5, "dining table", "a table meant for the kitchen", false));
        databaseMockUp.AddToStockList(new ComponentStock(1, databaseMockUp.getMasterReference(0), 17));
        databaseMockUp.AddToStockList(new ComponentStock(2, databaseMockUp.getMasterReference(1), 12));
        databaseMockUp.AddToStockList(new ComponentStock(3, databaseMockUp.getMasterReference(2), 2));
        databaseMockUp.AddToStockList(new ComponentStock(4, databaseMockUp.getMasterReference(3), 1));
        databaseMockUp.AddToStockList(new ProductStock(1, databaseMockUp.getMasterReference(4), 4));
        databaseMockUp.AddToStockList(new ProductStock(2, databaseMockUp.getMasterReference(5), 2));
        chairComponents[0, 0] = 1; chairComponents[0, 1] = 8;
        chairComponents[1, 0] = 2; chairComponents[1, 1] = 4;
        chairComponents[2, 0] = 3; chairComponents[2, 1] = 1;
        tableComponents[0, 0] = 1; tableComponents[0, 1] = 8;
        tableComponents[1, 0] = 2; tableComponents[1, 1] = 4;
        tableComponents[2, 0] = 4; tableComponents[2, 1] = 1;


        databaseMockUp.AddToRecipeList(0, databaseMockUp.getProduct(1).getItemID, chairComponents);
        databaseMockUp.AddToRecipeList(1, databaseMockUp.getProduct(2).getItemID, tableComponents);


        OptionSelect selection = new OptionSelect();

        //todo: Add explanations in OptionSelect
        Console.WriteLine("Welcome. Choose between the following options:");
        Console.WriteLine("1: ");

        selection.MainSelect(Console.ReadKey().KeyChar);
    }
}