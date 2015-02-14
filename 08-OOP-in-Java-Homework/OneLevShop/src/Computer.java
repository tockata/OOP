import enumerations.AgeRestriction;

public class Computer extends ElectronicsProduct {
    private static final int GUARANTEE_IN_MONTHS = 24;

    public Computer(String name, double price, int quantity, AgeRestriction ageRestriction) {
        super(name, price, quantity, ageRestriction);
        this.setGuaranteePeriodInMonths(GUARANTEE_IN_MONTHS);
    }

    @Override
    public double getPrice() {
        if (this.getQuantity() > 1000) {
            return this.getOriginalPrice() * 0.95;
        }

        return this.getOriginalPrice();
    }
}
