import enumerations.AgeRestriction;
import interfaces.Buyable;

public abstract class Product implements Buyable {
    private String name;
    private double price;
    private int quantity;
    private AgeRestriction ageRestriction;

    public Product(String name, double price, int quantity, AgeRestriction ageRestriction) {
        this.setName(name);
        this.setPrice(price);
        this.setQuantity(quantity);
        this.ageRestriction = ageRestriction;
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        if (name.isEmpty()){
            throw new IllegalArgumentException("Name can not be empty!");
        }
        
        this.name = name;
    }

    protected double getOriginalPrice() {
        return this.price;
    }

    public void setPrice(double price) {
        if (price <= 0) {
            throw new IllegalArgumentException("Price can not be negative or zero!");
        }

        this.price = price;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        if (quantity <= 0) {
            throw new IllegalArgumentException("Quantity can not be negative or zero!");
        }
        this.quantity = quantity;
    }

    public AgeRestriction getAgeRestriction() {
        return ageRestriction;
    }

    @Override
    public String toString() {
        String product = "Product name: " + this.getName() + ", price: " + this.getPrice() +
                ", quantity: " + this.getQuantity() + ", age restriction: " + this.getAgeRestriction();
        return product;
    }
}
