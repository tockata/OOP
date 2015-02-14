import enumerations.AgeRestriction;

import java.util.Date;

public final class PurchaseManager {
    public static void processPurchase(Product product, Customer customer) {
        if (product.getQuantity() <= 0) {
            throw new RuntimeException("Product out of stock!");
        }

        if (product instanceof FoodProduct) {
            if (((FoodProduct)product).getExpirationDate() != null){
                Date now = new Date();
                Date expDate = ((FoodProduct)product).getExpirationDate();
                if (expDate.before(now)) {
                    throw new RuntimeException("The product expiry date has been passed!");
                }
            }
        }

        if (customer.getBalance() < product.getPrice()) {
            throw new RuntimeException("You do not have enough money to buy this product!");
        }

        if (product.getAgeRestriction() == AgeRestriction.TEENAGER && customer.getAge() < 13) {
            throw new RuntimeException("You are too young to buy this product! Age must be above 12!");
        } else if (product.getAgeRestriction() == AgeRestriction.ADULT && customer.getAge() < 18) {
            throw new RuntimeException("You are too young to buy this product! Age must be above 17!");
        }

        customer.setBalance(customer.getBalance() - product.getPrice());
        product.setQuantity(product.getQuantity() - 1);
    }
}
