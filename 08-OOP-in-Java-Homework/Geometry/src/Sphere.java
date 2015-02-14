import java.util.ArrayList;

public class Sphere extends SpaceShape {
    private double radius;

    public Sphere(ArrayList<Vertex> vertices, double radius) {
        super(vertices);
        this.setRadius(radius);
        this.setVertex(vertices);
    }

    private void setVertex(ArrayList<Vertex> verticesList) {
        if (verticesList.size() != 1) {
            throw new IllegalArgumentException("Square Pyramid must have only one vertex!");
        }
    }

    public double getRadius() {
        return radius;
    }

    public void setRadius(double radius) {
        if (radius <= 0) {
            throw new IllegalArgumentException("Radius must be positive number!");
        }

        this.radius = radius;
    }

    @Override
    public double getArea() {
        return 4 * Math.PI * this.getRadius() * this.getRadius();
    }

    @Override
    public double getVolume() {
        return (4 * Math.PI * Math.pow(this.getRadius(), 3)) / 3;
    }
}
