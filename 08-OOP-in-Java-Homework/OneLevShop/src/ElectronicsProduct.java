import enumerations.AgeRestriction;

public abstract class ElectronicsProduct extends Product {
    private int guaranteePeriodInMonths;

    protected ElectronicsProduct(String name, double price, int quantity,
            AgeRestriction ageRestriction) {
        super(name, price, quantity, ageRestriction);
    }

    protected void setGuaranteePeriodInMonths(int guaranteePeriodInMonths) {
        this.guaranteePeriodInMonths = guaranteePeriodInMonths;
    }

    public int getGuaranteePeriodInMonths() {
        return guaranteePeriodInMonths;
    }

    @Override
    public String toString() {
        return super.toString() + ", guarantee period: " +
                this.getGuaranteePeriodInMonths() + " months.";
    }
}
