﻿namespace BookStore.Contractors;

public class PostamateDeliveryService : IDeliveryService
{
    private static IReadOnlyDictionary<string, string> cities = new Dictionary<string, string>
    {
        { "1", "Москва" },
        { "2", "Санкт-Петербург" }
    };

    private static IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> postamates
        = new Dictionary<string, IReadOnlyDictionary<string, string>>
    {
        {
            "1",
            new Dictionary<string, string>
            {
                { "1", "Казанский вокзал" },
                { "2", "Охотный ряд" },
                { "3", "Савёловский рынок" },
            }
        },
        {
            "2",
            new Dictionary<string, string>
            {
                { "4", "Московский вокзал" },
                { "5", "Гостиный двор" },
                { "6", "Петропавловская крепость" },
            }
        }
    };
    
    public string UniqueCode => "Postamate";

    public string Title => "Доставка через постаматы";
    
    public Form CreateForm(Order order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));

        return new Form(UniqueCode, order.Id, 1, false, new[]
        {
            new SelectionField("Город", "city", "1", cities)
        });
    }

    public Form MoveNext(int orderId, int step, IReadOnlyDictionary<string, string> values)
    {
        switch (step)
        {
            case 1:
            {
                switch (values["city"])
                {
                    case "1":
                        return new Form(UniqueCode, orderId, 2, false, new Field[]
                        {
                            new HiddenField("Город", "city", "1"),
                            new SelectionField("Постамат", "postamate", "1", postamates["1"])
                        });
                
                    case "2":
                        return new Form(UniqueCode, orderId, 2, false, new Field[]
                        {
                            new HiddenField("Город", "city", "2"),
                            new SelectionField("Постамат", "postamate", "4", postamates["2"])
                        });
                    default:
                        throw new InvalidOperationException("Invalid postamate city.");
                }
            }

            case 2:
            {
                return new Form(UniqueCode, orderId, 3, true, new Field[]
                {
                    new HiddenField("Город", "city", values["city"]),
                    new HiddenField("Постамат", "postamate", values["postamate"])
                });
            }
                
            default:
                throw new InvalidOperationException("Invalid postamate step.");
        }
    }
}