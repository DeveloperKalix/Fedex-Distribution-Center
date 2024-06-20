using System;
using System.Collections;

//Console.WriteLine("Hello, World!");

class Fedex {
    
    public enum Destinations {
        ORD,
        EWR,
        JFK,
        LGA,
        LAX,
        IAH,
        ATL,
        SEA,
    }

    private static string airportCodeToString(Destinations airport) {
        switch(airport) {
            case Destinations.EWR: 
                return "Newark Intl. Airport";
            case Destinations.SEA:
                return "Seattle Intl. Airport";
            case Destinations.ATL: 
                return "Atlanta Intl. Airport";
            case Destinations.JFK:
                return "John F. Kennedy Intl. Airport";
            case Destinations.IAH: 
                return "George Bush Intl. Airport";
            case Destinations.LAX: 
                return  "Los Angeles Intl. Airport";
            case Destinations.LGA: 
                return "LaGuardia Intl. Airport";
            case Destinations.ORD: 
                return "Chicago O'Hare Intl. Airport";
            default: 
                return "ERROR: Unrecognized Airport.";
        }
    }

    // Basic recursive function that swaps values from one stack to another.
    static Stack<Crate> shiftInventory(Stack<Crate> warehouseA, Stack<Crate> warehouseB) {
        if(warehouseA.Count() == 0) {
            return warehouseB;
        }
        else
        {
            Console.WriteLine("Moving " + warehouseA.Peek().Identifier + ".");
            warehouseB.Push(warehouseA.Pop());
            return shiftInventory(warehouseA, warehouseB);
        }
    }

    static Arraylist<Crate> createManifest(Stack<Crate> warehouse, Arraylist<Crate> manifest) {
        if(warehouse.Count() == 0) {
            return manifest;
        }
        else {
            
        }
    }

    static string generateCrateIdentifier() {
        
        return "CRT-" + Guid.NewGuid().ToString().ToUpper().Substring(0, 5);
    }

    static void Main() {
        Stack<Crate> WarehouseOne = new Stack<Crate>();
        Stack<Crate> WarehouseTwo = new Stack<Crate>();

        

        Crate myCrate = new Crate("Bars of Soap", generateCrateIdentifier(), 100, 1000.00m, 250, Destinations.EWR, false);
        Crate SanitizerCrate = new Crate("Hand Sanitizer Bottles", generateCrateIdentifier(), 250, 2500.00m, 150, Destinations.LGA, false);
        WarehouseOne.Push(myCrate);
        WarehouseOne.Push(SanitizerCrate);
        shiftInventory(WarehouseOne, WarehouseTwo);
        Console.WriteLine("YO TAKE A LOOK: " + WarehouseTwo.Count());
        Console.WriteLine(myCrate);
    }

    public struct Crate {
        
        public string Product { get; }
        public string Identifier { get; }
        public int Quantity { get; }
        public decimal Value { get; }

        public float Weight { get; }
        public Destinations Destination { get; }
        public bool IsSpoiled { get; }
        
        public Crate(string product, string identifier, int quantity, decimal value, float weight, Destinations destination, bool isSpoiled) {
            Product = product;
            Identifier = identifier;
            Quantity = quantity;
            Weight = weight;
            Destination = destination;
            Value = value;
            IsSpoiled = isSpoiled;
        }

        public override string ToString() {
            return $"[----------------]\nCrate Number: " + Identifier + "\nContains: " + Product + ". \nQuantity: " + Quantity + "\nValue: $" + Value + "\nWeight: " + Weight + " lbs" + "\nDestination: " + airportCodeToString(Destination) + "\n[----------------]";
        }  
    }
}
