import enumerations.AgeRestriction;

public class Appliance extends ElectronicsProduct {
    private static final int GUARANTEE_IN_MONTHS = 6;

    public Appliance(String name, double price, int quantity, AgeRestriction ageRestriction) {
        super(name, price, quantity, ageRestriction);
        this.setGuaranteePeriodInMonths(GUARANTEE_IN_MONTHS);
    }

    @Override
    public double getPrice() {
        if (this.getQuantity() < 50) {
            return this.getOriginalPrice() * 1.05;
        }

        return this.getOriginalPrice();
    }
}
