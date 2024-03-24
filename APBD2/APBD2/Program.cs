using System.Collections.Generic;

namespace Containers
{
    public class Program
    {
        static void Main(string[] args)
        {
            Container containerGas1 = new GasContainer(0, 350, 250, 1000, 35, true);
            Container containerGas2 = new GasContainer(0, 350, 250, 1000, 35, false);
            Container containerLiquid1 = new LiquidContainer(0, 350, 250, 1000, 35, false);
            Container containerLiquid2 = new LiquidContainer(0, 350, 250, 1000, 35, false);
            Container containerRefrigerated1 = new RefrigeratedContainer(0, 350, 250, 1000, 35, "fish", 2);
            Container containerRefrigerated2 = new RefrigeratedContainer(0, 350, 250, 1000, 35, "frozen pizza", -15);
            Container containerRefrigerated3 = new RefrigeratedContainer(0, 350, 250, 1000, 35, "meat", -15);
            Container containerRefrigerated4 = new RefrigeratedContainer(0, 350, 250, 1000, 35, "bananas", 10);
            Container containerRefrigerated5 = new RefrigeratedContainer(0, 350, 250, 1000, 35, "chocolate", 18);
            Container containerRefrigerated6 = new RefrigeratedContainer(0, 350, 250, 1000, 35, "ice cream", -17);
            Container containerRefrigerated7 = new RefrigeratedContainer(0, 350, 250, 1000, 35, "cheese", 8);
            Container containerRefrigerated8 = new RefrigeratedContainer(0, 350, 250, 1000, 35, "sausages", 5);
            Container containerRefrigerated9 = new RefrigeratedContainer(0, 350, 250, 1000, 35, "butter", 20);
            Container containerRefrigerated10 = new RefrigeratedContainer(0, 350, 250, 1000, 35, "eggs", 19.1);
            ContainerShip containerShip1 = new ContainerShip(20, 100, 20);
            ContainerShip containerShip2 = new ContainerShip(15, 50, 10);
            containerGas1.LoadCargo(50);
            containerGas1.LoadCargo(30);
            containerGas2.LoadCargo(50);
            containerGas2.LoadCargo(30);
            containerLiquid1.LoadCargo(50);
            containerLiquid1.LoadCargo(30);
            containerLiquid2.LoadCargo(50);
            containerLiquid2.LoadCargo(30);
            containerRefrigerated1.LoadCargo(30);
            containerRefrigerated2.LoadCargo(30);
            containerRefrigerated3.LoadCargo(30);
            containerRefrigerated4.LoadCargo(30);
            containerRefrigerated5.LoadCargo(30);
            containerRefrigerated6.LoadCargo(30);
            containerRefrigerated7.LoadCargo(30);
            containerRefrigerated8.LoadCargo(30);
            containerRefrigerated9.LoadCargo(30);
            containerRefrigerated10.LoadCargo(30);
            containerShip1.AddContainer(containerGas1);
            containerShip2.AddContainer(containerGas1);
            containerShip2.AddContainer(containerGas2);
            List<Container> liquids = new List<Container>();
            liquids.Add(containerLiquid1);
            liquids.Add(containerLiquid2);
            containerShip1.AddContainer(liquids);
            containerShip2.AddContainer(containerRefrigerated1);
            containerShip2.AddContainer(containerRefrigerated2);
            containerShip2.AddContainer(containerRefrigerated3);
            containerShip2.AddContainer(containerRefrigerated4);
            containerShip2.AddContainer(containerRefrigerated5);
            containerShip2.AddContainer(containerRefrigerated6);
            containerShip2.AddContainer(containerRefrigerated7);
            containerShip2.AddContainer(containerRefrigerated8);
            containerShip2.AddContainer(containerRefrigerated9);
            containerShip2.PrintInfo();
            containerShip1.PrintInfo();
            containerShip1.ReplaceContainer("KON-G-1", containerRefrigerated10);
            containerShip1.PrintInfo();
        
            containerShip1.TransferContainer("KON-C-14", containerShip2);
            containerShip2.PrintInfo();
            containerShip1.PrintInfo();
            containerShip1.RemoveContainer("KON-L-3");
            containerShip1.PrintInfo();
        }
    }
}
