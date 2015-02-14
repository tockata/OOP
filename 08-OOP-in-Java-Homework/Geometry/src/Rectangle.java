import java.util.ArrayList;

public class Rectangle extends PlaneShape {
    private double width;
    private double height;

    public Rectangle(ArrayList<Vertex> vertices2D, double width, double height) {
        super(vertices2D);
        this.setWidth(width);
        this.setHeight(height);
        this.setVertex(vertices2D);
    }


    public void setVertex(ArrayList<Vertex> vertexList) {
        if (vertexList.size() != 1) {
            throw new IllegalArgumentException("Rectangle must have only one vertex!");
        }
    }

    public double getWidth() {
        return this.width;
    }

    public void setWidth(double width) {
        if (width <= 0) {
            throw new IllegalArgumentException("Width must be positive number!");
        }

        this.width = width;
    }

    public double getHeight() {
        return this.height;
    }

    public void setHeight(double height) {
        if (width <= 0) {
            throw new IllegalArgumentException("Height must be positive number!");
        }

        this.height = height;
    }

    @Override
    public double getArea() {
        return this.getWidth() * this.getHeight();
    }

    @Override
    public double getPerimeter() {
        return this.getWidth() * 2 + this.getHeight() * 2;
    }
}
