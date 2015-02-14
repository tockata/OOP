import enumerations.AgeRestriction;
import interfaces.Expirable;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class Test {
    public static void main(String[] args) {
        FoodProduct foodProduct1 = new FoodProduct("Bread", 2.5, 2, AgeRestriction.NONE, "14.02.2015");
        FoodProduct foodProduct2 = new FoodProduct("Cheese", 8.45, 20, AgeRestriction.NONE, "10.02.2015");
        FoodProduct foodProduct3 = new FoodProduct("Coffee", 4.78, 100, AgeRestriction.TEENAGER, "12.12.2015");
        FoodProduct foodProduct4 = new FoodProduct("Vodka", 12.50, 82, AgeRestriction.ADULT, "25.03.2015");
        Computer computer1 = new Computer("Lenovo", 1500, 5, AgeRestriction.NONE);
        Computer computer2 = new Computer("HP", 1399, 4, AgeRestriction.NONE);
        Appliance appliance1 = new Appliance("Shaving machine", 90, 49, AgeRestriction.ADULT);
        Appliance appliance2 = new Appliance("Washing machine", 450.99, 2, AgeRestriction.ADULT);
        FoodProduct cigars = new FoodProduct("420 Blaze it fgt", 6.90, 1400, AgeRestriction.ADULT, "30.06.2015");

        Customer pecata = new Customer("Pecata", 19, 30.00);

        System.out.println("Balance before purchase: " + pecata.getBalance());
        System.out.println("Quantities before purchase: " + cigars.getQuantity());
        try {
            PurchaseManager.processPurchase(cigars, pecata);
        } catch (RuntimeException re) {
            System.out.println(re.getMessage());
        }

        System.out.println("Balance after purchase: " + pecata.getBalance());
        System.out.println("Quantities after purchase: " + cigars.getQuantity());
        System.out.println();

        Customer gopeto = new Customer("Gopeto", 18, 0.44);
        try {
            PurchaseManager.processPurchase(cigars, gopeto);
        } catch (RuntimeException re) {
            System.out.println(re.getMessage());
            System.out.println();
        }

        List<Product> products = new ArrayList<Product>();
        products.add(foodProduct1);
        products.add(foodProduct2);
        products.add(foodProduct3);
        products.add(foodProduct4);
        products.add(computer1);
        products.add(computer2);
        products.add(appliance1);
        products.add(appliance2);
        products.add(cigars);

        System.out.println("List of products:");
        for (Product product : products) {
            System.out.println(product);
        }

        System.out.println();

        Product productWithSoonestExpDate = products.stream()
                .filter(p -> p instanceof Expirable)
                .map(p -> (Expirable)p)
                .sorted((p1, p2) -> p1.getExpirationDate().compareTo(p2.getExpirationDate()))
                .map(p -> (Product) p)
                .findFirst()
                .get();

        System.out.println("Product with soonest expiration date: " + productWithSoonestExpDate.getName());
        System.out.println();

        System.out.println("Adult products sorted by price:");
        products.stream()
                .filter(p -> p.getAgeRestriction() == AgeRestriction.ADULT)
                .sorted((p1, p2) -> Double.compare(p1.getPrice(), p2.getPrice()))
                .collect(Collectors.toList())
                .forEach(p -> System.out.println("Product name: " + p.getName() + ", price: " + p.getPrice()));
    }
}
