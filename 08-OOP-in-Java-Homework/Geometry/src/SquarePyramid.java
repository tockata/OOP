import java.util.ArrayList;

public class SquarePyramid extends SpaceShape {
    private double width;
    private double height;

    public SquarePyramid(ArrayList<Vertex> vertices, double width, double height) {
        super(vertices);
        this.setWidth(width);
        this.setHeight(height);
        this.setVertex(vertices);
    }

    private void setVertex(ArrayList<Vertex> verticesList) {
        if (verticesList.size() != 1) {
            throw new IllegalArgumentException("Square Pyramid must have only one vertex!");
        }
    }

    public double getWidth() {
        return width;
    }

    public void setWidth(double width) {
        if (width <= 0) {
            throw new IllegalArgumentException("Width must be positive number!");
        }

        this.width = width;
    }

    public double getHeight() {
        return height;
    }

    public void setHeight(double height) {
        if (height <= 0) {
            throw new IllegalArgumentException("Height must be positive number!");
        }

        this.height = height;
    }

    @Override
    public double getArea() {
        double triangleHeight = Math.sqrt(
                this.getHeight() * this.getHeight() +
                (this.getWidth() / 2) * (this.getWidth() / 2));
        return 2 * this.getWidth() * triangleHeight + this.getWidth() * this.getWidth();
    }

    @Override
    public double getVolume() {
        return (this.getWidth() * this.getWidth() * this.getHeight()) / 3;
    }
}
