import java.util.ArrayList;

public class Circle extends PlaneShape {
    private double radius;

    public Circle(ArrayList<Vertex> vertices2D, double radius) {
        super(vertices2D);
        this.setRadius(radius);
        this.setVertex(vertices2D);
    }

    public void setVertex(ArrayList<Vertex> vertexList) {
        if (vertexList.size() != 1) {
            throw new IllegalArgumentException("Circle must have only one vertex!");
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
        return Math.PI * this.getRadius() * this.getRadius();
    }

    @Override
    public double getPerimeter() {
        return 2 * Math.PI * this.getRadius();
    }
}
