import enumerations.AgeRestriction;
import interfaces.Expirable;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class FoodProduct extends Product implements Expirable {
    private Date expirationDate;

    public FoodProduct(String name, double price, int quantity,
            AgeRestriction ageRestriction, String expirationDate) {
        super(name, price, quantity, ageRestriction);
        this.setExpirationDate(expirationDate);
    }

    @Override
    public Date getExpirationDate() {
        return this.expirationDate;
    }

    public void setExpirationDate(String expirationDate) {
        SimpleDateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy");
        try {
            this.expirationDate = dateFormat.parse(expirationDate);
        } catch (ParseException pe) {
            System.out.println("Invalid expiration date!");
            pe.printStackTrace();
        }
    }

    @Override
    public double getPrice() {
        if (this.expirationDate == null) {
            return this.getOriginalPrice();
        }

        int days = CalculateDateDifference();
        if (days <= 15) {
            return this.getOriginalPrice() * 0.7;
        } else {
            return this.getOriginalPrice();
        }
    }

    private int CalculateDateDifference(){
        Date currentDate = new Date();
        long currentDateMilliseconds = currentDate.getTime();
        long expDateMilliseconds = this.expirationDate.getTime();
        long differenceInMilliseconds = expDateMilliseconds - currentDateMilliseconds;
        return (int)(differenceInMilliseconds / (1000*60*60*24));
    }

    @Override
    public String toString() {
        if (this.getExpirationDate() != null) {
            SimpleDateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy");
            String expDate = dateFormat.format(this.getExpirationDate());
            return super.toString() + ", expiration date: " + expDate + ".";
        }

        return super.toString();
    }
}
